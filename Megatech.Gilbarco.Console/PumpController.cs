using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Megatech.Gilbarco.Console
{
    internal class PumpController
    {
        public const byte STX = 0xFF;
        public const byte ETX = 0xF0;

        private SerialPort _port;

        public delegate void PumpStatusReceivedHandler(byte pumpId, PUMP_STATUS status);
        public delegate void PumpTransactionDataReceivedHandler(byte pumpId, PumpTransactionData data);
        public delegate void PumpTotalDataReceivedHandler(byte pumpId, PumpTotalData data);
        public delegate void DataSentEventHandler(string data);

        public delegate void DataReceivedEventHandler(string data);


        private PumpStatusReceivedHandler _statusReceived;

        private PumpTransactionDataReceivedHandler _transactionDataReceived;

        private PumpTotalDataReceivedHandler _totalDataReceived;
        public event PumpStatusReceivedHandler StatusReceived
        {
            add { _statusReceived += value; }
            remove { _statusReceived -= value; }
        }

        public event PumpTransactionDataReceivedHandler TransactionDataReceived
        {
            add { _transactionDataReceived += value; }
            remove { _transactionDataReceived -= value; }
        }

        public event PumpTotalDataReceivedHandler TotalDataReceived
        {
            add { _totalDataReceived += value; }
            remove { _totalDataReceived -= value; }
        }

        public event DataReceivedEventHandler DataReceived;
        public event DataSentEventHandler DataSent;


        private System.Timers.Timer timer;
        public PumpController() : this("COM1")
        { }
        public PumpController(string portName)
        {
            _port = new SerialPort();
            _port.BaudRate = 5787;
            _port.Parity = Parity.Even;
            _port.StopBits = StopBits.One;
            _port.PortName = portName;
            //_port.DataReceived += _port_DataReceived;
            //_port.ErrorReceived += _port_ErrorReceived;

            //timer = new System.Timers.Timer();
            //timer.Interval = 500;
            //timer.Elapsed += Timer_Elapsed;
            //timer.Start();


        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            ProcessQueue();
        }

        public bool Open()
        {
            try
            {
                _port.Open();
                return _port.IsOpen;
            }
            catch { return false; }
        }
        public void Close()
        {
            _port.Close();
        }
        private void _port_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            var t = e.EventType;

        }

        private List<byte> _data = new List<byte>();

        private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] bytes = new byte[_port.BytesToRead];
            _port.Read(bytes, 0, _port.BytesToRead);
            bool stop = true;
            _data.AddRange(bytes);
            if (_lastCommand.HasStartStop)
            {
                stop = bytes.Contains( ETX);
            }
            if (stop)
            {
                bytes = _data.ToArray();
                _data.Clear();
                switch (_lastCommand.CommandCode)
                {
                    case COMMAND_CODE.COMMAND_STATUS:
                        ProcessStatusData(bytes); break;

                    case COMMAND_CODE.COMMAND_AUTHORIZE:
                    case COMMAND_CODE.COMMAND_PUMP_TRANSACTION:
                        ProcessTransactionData(bytes);
                        break;
                    case COMMAND_CODE.COMMAND_PUMP_TOTAL:
                        ProcessTotalData(bytes);
                        break;
                    case COMMAND_CODE.COMMAND_REALTIME_MONEY:
                    default:
                        break;
                }

                OnDataReceived(bytes);
            }
        }

        private void OnDataReceived(byte[] bytes)
        {

            if (DataReceived != null)
                DataReceived(Convert.ToHexString(bytes));

        }
        private void OnDataSent(byte[] bytes)
        {

            if (DataSent != null)
                DataSent(Convert.ToHexString(bytes));
        }

        private void ProcessTransactionData(byte[] bytes)
        {
            if (ValidData(bytes))
            {

                PumpTransactionData data = new PumpTransactionData();
                data.PumpId = _lastCommand.PumpId;
                data.UnitPrice = GetValue(bytes, 0xF7, 6, 0);
                data.Volume = GetValue(bytes, 0xF9, 8, 3);
                data.Money = GetValue(bytes, 0xFA, 8, 0);

                OnPumpTransactionDataReceived(data);

            }
        }

        private void ProcessTotalData(byte[] bytes)
        {
            if (ValidData(bytes))
            {

                PumpTotalData data = new PumpTotalData();
                data.PumpId = _lastCommand.PumpId;
                data.UnitPrice = GetValueFromCode(bytes, 0xF4, 6, 0);
                data.Volume = GetValueFromCode(bytes, 0xF9, 8, 3);
                data.Money = GetValueFromCode(bytes, 0xFA, 8, 0);

                OnPumpTotalDataReceived(data);

            }
        }

        private void OnPumpTotalDataReceived(PumpTotalData data)
        {
            if (_totalDataReceived != null)
                _totalDataReceived.Invoke(data.PumpId, data);
        }

        private void OnPumpTransactionDataReceived(PumpTransactionData data)
        {
            if (_transactionDataReceived != null)
                _transactionDataReceived.Invoke(data.PumpId, data);
        }

        private decimal GetValueFromCode(byte[] bytes, byte code, int numOfBytes, int decimalPos)
        {
            var idx = Array.IndexOf(bytes, code);
            if (idx > 0)
            {
                var f = idx + numOfBytes;
                return GetValue(bytes, idx+1, f+1, decimalPos);
            }
            else
                return 0;
        }
        private decimal GetValue(byte[] bytes, int start, int end, int decimalPos)
        {
            var c = 0;
            var val = 0.0M;
            for (int i = end-1; i >=start ; i--)
            {
                var x = GetNible(bytes[i], false);
                val = (val * 10 + x);
                

            }
            val = val /(decimal)Math.Pow(10 , decimalPos);
            return val;
        }
        private byte GetNible(byte b, bool first)
        {
            if (first)
                return (byte)((b & 0xF0) >> 4);
            else
                return (byte)(b & 0x0F);
        }

        private bool ValidData(byte[] bytes)
        {
            return bytes.First() == STX && bytes.Last() == ETX;

        }

        private void ProcessStatusData(byte[] bytes)
        {
            if (bytes.Length == 1)
            {
                byte b = bytes[0];
                var status = (b & 0xF0) >> 4;
                var id = b & 0x0F;
                OnPumpStatusReceived((byte)id, (PUMP_STATUS)status);
            }
        }

        public void OnPumpStatusReceived(byte pumpId, PUMP_STATUS status)
        {
            if (status == PUMP_STATUS.CALL)
                Authorizre(pumpId);
            if (_statusReceived != null)
            {
                _statusReceived.Invoke(pumpId, status);
            }

        }

        public void RequestStatus(byte pumpId)
        {
            QueueCommand(PumpCommand.GetPumpStatus(pumpId));
        }

        public void Authorizre(byte pumpId)
        {
            QueueCommand(PumpCommand.Authorize(pumpId));
            Thread.Sleep(100);
            RequestStatus(pumpId);
        }

        public void GetLastTransaction(byte pumpId)
        {
            QueueCommand(PumpCommand.Transaction(pumpId));

        }


        public void GetTotal(byte pumpId)
        {
            QueueCommand(PumpCommand.PumpTotal(pumpId));

        }

        public void Stop(byte pumpId)
        {
            QueueCommand(PumpCommand.Stop(pumpId));
            Thread.Sleep(100);
            RequestStatus(pumpId);

        }

        public void GetTransactionData(byte pumpId)
        {
            QueueCommand(PumpCommand.Transaction(pumpId));
        }

        private PumpCommand _lastCommand;
        private DateTime _lastSent;
        private void QueueCommand(PumpCommand command)
        {
            _commands.Enqueue(command);
        }

        private void ProcessQueue()
        {
            if (_commands.Count > 0)
            {
                if (_lastSent >= DateTime.Now.AddMicroseconds(-100))
                {
                    Thread.Sleep(100);
                }

                PumpCommand command = _commands.Dequeue();
                SendCommand(command);

            }
        }

        Queue<PumpCommand> _commands = new Queue<PumpCommand>();

        private void SendCommand(PumpCommand command)
        {
            if (_port.IsOpen)
            {

                _lastSent = DateTime.Now;
                _lastCommand = command;
                _port.ReceivedBytesThreshold = command.ReveidBytesThreshold;
                _port.Write(command.CommandData, 0, command.CommandData.Length);
                OnDataSent(command.CommandData);
                Thread.Sleep(100);

                while (_port.BytesToRead>0)
                {
                    byte[] bytes = new byte[_port.BytesToRead];
                    _port.Read(bytes, 0, _port.BytesToRead);
                    bool stop = true;
                    _data.AddRange(bytes);
                    if (_lastCommand.HasStartStop)
                    {
                        stop = bytes.Contains(ETX);
                    }
                    if (stop)
                    {
                        bytes = _data.ToArray();
                        _data.Clear();
                        switch (_lastCommand.CommandCode)
                        {
                            case COMMAND_CODE.COMMAND_STATUS:
                                ProcessStatusData(bytes); break;

                            case COMMAND_CODE.COMMAND_AUTHORIZE:
                            case COMMAND_CODE.COMMAND_PUMP_TRANSACTION:
                                ProcessTransactionData(bytes);
                                break;
                            case COMMAND_CODE.COMMAND_PUMP_TOTAL:
                                ProcessTotalData(bytes);
                                break;
                            case COMMAND_CODE.COMMAND_REALTIME_MONEY:
                            default:
                                break;
                        }

                        OnDataReceived(bytes);
                    }
                }

                ProcessQueue();
            }

        }
    }
}

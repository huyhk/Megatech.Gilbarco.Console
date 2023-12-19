
using System;
using System.ComponentModel;
using System.IO.Ports;
using System.Text;
using System.Transactions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Megatech.Gilbarco.Console
{

    public partial class Form1 : Form
    {
        private SerialPort _port;
        private AutoResetEvent mre = new AutoResetEvent(false);
        private int responseTimeout = 1;
        private Queue<byte[]> commandQueue;

        private PumpController controller;
        public Form1()
        {
            InitializeComponent();
            LoadCOMPorts();
            timer.Enabled = false;
        }

        private void LoadCOMPorts()
        {
            var ports = SerialPort.GetPortNames();
            cboComPortList.Items.AddRange(ports);
            cboComPortList.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var portName = cboComPortList.SelectedItem as string;
            if (controller !=null)
                controller.Close();

            controller = new PumpController(portName);
            controller.StatusReceived += Controller_StatusReceived;
            controller.TotalDataReceived += Controller_TotalDataReceived;
            controller.TransactionDataReceived += Controller_TransactionDataReceived;
            controller.DataReceived += Controller_DataReceived;
            controller.DataSent += Controller_DataSent; ;

            if (!controller.Open())
                MessageBox.Show($"Could not connect to {portName}");

            DetectPumpList();

        }

        private void Controller_DataSent(string data)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                txtSentData.Text += data + "\r\n";
                txtSentData.SelectionStart = txtOutput.TextLength;
                txtSentData.ScrollToCaret();
            }));
        }

        private void Controller_DataReceived(string data)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                txtOutput.Text += data + "\r\n";
                txtOutput.SelectionStart = txtOutput.TextLength;
                txtOutput.ScrollToCaret();
            }));

        }

        private void Controller_TransactionDataReceived(byte pumpId, PumpTransactionData data)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                var pump = lstPump.FirstOrDefault(p => p.Id == pumpId);
                if (pump != null)
                {
                    pump.LastTransaction = data;
                }
                dataGridView1.Update();
            }));
        }

        private void Controller_TotalDataReceived(byte pumpId, PumpTotalData data)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                var pump = lstPump.FirstOrDefault(p => p.Id == pumpId);
                if (pump != null)
                {
                    pump.PumpTotal = data;
                }
                dataGridView1.Update();
            }));
        }

        private void Controller_StatusReceived(byte pumpId, PUMP_STATUS status)
        {
            if (lstPump == null)
            {
                lstPump = new BindingList<Pump>();

            }
            this.Invoke((MethodInvoker)(() =>
            {
                dataGridView1.DataSource = lstPump;
                var pump = lstPump.FirstOrDefault(p => p.Id == pumpId);
                if (pump != null)
                {
                    pump.Status = status;
                }
                else
                { 
                    pump = new Pump { Id = pumpId, Status = status };
                    lstPump.Add(pump);
                    controller.GetTotal(pumpId);
                    controller.GetLastTransaction(pumpId);
                }


                dataGridView1.Update();
                dataGridView1.Refresh();
            }));

        }


        private BindingList<Pump> lstPump;




        private int pumpId;
        private void DetectPumpList()
        {


            for (byte i = 1; i < 16; i++)
            {
                controller.RequestStatus(i);
            }
        }



        StringBuilder sentSB = new StringBuilder();



        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();



    }
}
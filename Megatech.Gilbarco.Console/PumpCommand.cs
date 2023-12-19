using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatech.Gilbarco.Console
{
    public class PumpCommand
    {


        public PumpCommand(byte code, byte pumpId, int threshold = 0, bool hasStartStop = false)
        {

            PumpId = pumpId;

            CommandCode = code;

            CommandData = new byte[] { (byte)((code << 4) | pumpId) };

            ReveidBytesThreshold = threshold;
            HasStartStop = hasStartStop;
        }

        public byte PumpId { get; set; }
        public byte CommandCode { get; set; }
        public byte[] CommandData { get; set; }

        public int ReveidBytesThreshold { get; set; }

        public bool HasStartStop { get; set; }

        public static PumpCommand GetCommand(byte code, byte pumpId, int threshold = 0, bool hasStartStop = false)
        {

            return new PumpCommand(code, pumpId, threshold, hasStartStop);
        }



        public static PumpCommand GetPumpStatus(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_STATUS, pumpId, 1);
        }



        public static PumpCommand Stop(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_STOP, pumpId);
        }

        public static PumpCommand Authorize(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_AUTHORIZE, pumpId);
        }

        public static PumpCommand PumpTotal(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_PUMP_TOTAL, pumpId, 44, true);
        }
        public static PumpCommand Transaction(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_PUMP_TRANSACTION, pumpId, 32, true);
        }

        internal static PumpCommand RealTimeMoney(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_REALTIME_MONEY, pumpId, 8, false);
        }
    }
}

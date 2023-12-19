using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatech.Gilbarco.Console
{
    public class PumpCommand
    {
       

        public PumpCommand(byte code, byte pumpId, int threshold = 0)
        {

            PumpId = pumpId;

            CommandCode = code;

            CommandData = new byte[] { (byte)(code & 0xFF | pumpId) };
            ReveidBytesThreshold = threshold;

        }

        public  byte PumpId { get; set; }
        public byte CommandCode { get; set; }
        public byte[] CommandData { get; set; }

        public int ReveidBytesThreshold { get; set; }

        public static PumpCommand GetCommand( byte code, byte pumpId, int threshold = 0)
        {
           
            return new PumpCommand(code, pumpId, threshold);
        }



        public static PumpCommand GetPumpStatus(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_STATUS , pumpId,1) ;
        }



        public static PumpCommand Stop(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_STOP, pumpId);
        }

        public static PumpCommand Authorize (byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_AUTHORIZE, pumpId);
        }

        public static PumpCommand PumpTotal(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_PUMP_TOTAL, pumpId,88);
        }
        public static PumpCommand Transaction(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_PUMP_TRANSACTION, pumpId,32);
        }

        
    }
}

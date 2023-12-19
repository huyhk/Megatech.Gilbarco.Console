using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatech.Gilbarco.Console
{
    public class PumpCommand
    {
       

        public PumpCommand(byte code, byte pumpId)
        {

            PumpId = pumpId;

            CommandCode = code;

            CommandData = new byte[] { (byte)(code & 0xFF | pumpId) };

        }

        public  byte PumpId { get; set; }
        public byte CommandCode { get; set; }
        public byte[] CommandData { get; set; }



        public static PumpCommand GetCommand( byte code, byte pumpId)
        {
           
            return new PumpCommand(code, pumpId);
        }



        public static PumpCommand GetPumpStatus(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_STATUS , pumpId) ;
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
            return GetCommand(COMMAND_CODE.COMMAND_PUMP_TOTAL, pumpId);
        }
        public static PumpCommand Transaction(byte pumpId)
        {
            return GetCommand(COMMAND_CODE.COMMAND_PUMP_TRANSACTION, pumpId);
        }

        
    }
}

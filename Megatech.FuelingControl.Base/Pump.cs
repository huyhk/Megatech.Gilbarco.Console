using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megatech.FuelingControl.Base
{
    internal class Pump
    {
        public byte Id { get; set; }

        public PUMP_STATUS Status { get; set; }

        public decimal RealTimeMoney { get; set; }

        public PumpTotalData PumpTotal { get; set; }

        public PumpTransactionData LastTransaction { get; set; }
    }
}

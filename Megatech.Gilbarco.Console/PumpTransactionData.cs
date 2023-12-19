namespace Megatech.Gilbarco.Console
{
    public class PumpTransactionData
    {
        public decimal Volume { get; set; }

        public decimal Money { get; set; }

        public decimal UnitPrice { get; set; }
        public byte PumpId { get; internal set; }
    }
}
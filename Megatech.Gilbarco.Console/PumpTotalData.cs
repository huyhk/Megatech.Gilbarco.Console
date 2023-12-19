namespace Megatech.Gilbarco.Console
{
    public class PumpTotalData
    {
        public int Grade { get; set; }

        public decimal Volume { get; set; }

        public decimal Money { get; set; }

        public decimal UnitPrice { get; set; }
        public byte PumpId { get; internal set; }

        public override string ToString()
        {
            return $"Volume : {Volume} \r\n Money: {Money} \r\n  UnitPrice : {UnitPrice}";
        }
    }
}
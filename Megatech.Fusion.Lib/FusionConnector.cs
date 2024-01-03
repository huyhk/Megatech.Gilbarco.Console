using Megatech.FuelingControl.Base;

namespace Megatech.Fusion.Lib
{
    public class FusionConnector: IConnector
    {
        FusionClass.Fusion fc = new FusionClass.Fusion();

        public FusionConnector(string ip)
        {
            fc.Connection(ip);
            
            
        }

        public  void Logon()
        {
            throw new NotImplementedException();
        }

        public void Authorize()
        {
            throw new NotImplementedException();
        }

        public PUMP_STATUS GetStatus(int pumpId)
        {
            string status = null;
            string sub_status = null;
            var ret = fc.PumpStatus(pumpId, ref status, ref sub_status);
            return (PUMP_STATUS)ret;
        }

        public PumpTotalData GetTotal(int pumpId)
        {
            string p_total = string.Empty, p_vol = string.Empty;
            var ret = fc.GetTotalizers(1,3, ref p_total, ref p_vol);

            if (ret > 0)
            {
                return new PumpTotalData { Volume = decimal.Parse(p_vol) };
            }
            else return null;
        }
    }
}
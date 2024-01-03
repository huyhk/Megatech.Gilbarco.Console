namespace Megatech.FuelingControl.Base
{
    public interface IConnector
    {
        void Logon();

        void Authorize();

        PumpTotalData GetTotal(int pumpId);
    }
}
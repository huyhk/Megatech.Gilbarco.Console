
using System;
using System.IO.Ports;
using System.Text;
using System.Transactions;

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
            txtSentData.Text += data + "\n\r";
            txtSentData.SelectionStart = txtOutput.TextLength;
            txtSentData.ScrollToCaret();
        }

        private void Controller_DataReceived(string data)
        {
            txtOutput.Text += data + "\n\r";
            txtOutput.SelectionStart = txtOutput.TextLength;
            txtOutput.ScrollToCaret();
        }

        private void Controller_TransactionDataReceived(byte pumpId, PumpTransactionData data)
        {
            throw new NotImplementedException();
        }

        private void Controller_TotalDataReceived(byte pumpId, PumpTotalData data)
        {
            throw new NotImplementedException();
        }

        private void Controller_StatusReceived(byte pumpId, PUMP_STATUS status)
        {
            if (lstPump == null)
                lstPump = new List<Pump>();
            if (lstPump.Exists(p => p.Id == pumpId))
            {
                lstPump.FirstOrDefault(p => p.Id == pumpId).Status = status;
            }
            else lstPump.Add(new Pump { Id = pumpId, Status = status });
            dataGridView1.DataSource = lstPump;
            dataGridView1.Update();
        }


        private List<Pump> lstPump;

       


        private int pumpId;
        private void DetectPumpList()
        {


            for (byte i = 1; i < 1; i++)
            {
                controller.RequestStatus(i );
            }
        }

      

        StringBuilder sentSB = new StringBuilder();



        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();



    }
}
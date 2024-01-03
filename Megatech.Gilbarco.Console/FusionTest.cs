using Megatech.Fusion.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Megatech.Gilbarco.Console
{
    public partial class FusionTest : Form
    {
        public FusionTest()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            FusionConnector fc = new FusionConnector(txtIP.Text);

            var stat = fc.GetStatus(1);

            var total = fc.GetTotal(1);
        }
    }
}

namespace Megatech.Gilbarco.Console
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            cboComPortList = new ComboBox();
            label1 = new Label();
            btnConnect = new Button();
            label2 = new Label();
            statusStrip1 = new StatusStrip();
            statusBarLabel = new ToolStripStatusLabel();
            dataGridView1 = new DataGridView();
            btnLoop = new Button();
            colName = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            RealTimeMoney = new DataGridViewTextBoxColumn();
            LastTransaction = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // cboComPortList
            // 
            cboComPortList.FormattingEnabled = true;
            cboComPortList.Location = new Point(141, 12);
            cboComPortList.Name = "cboComPortList";
            cboComPortList.Size = new Size(193, 28);
            cboComPortList.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 20);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 1;
            label1.Text = "COM port";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(353, 11);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 63);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Pump List";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusBarLabel });
            statusStrip1.Location = new Point(0, 656);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(902, 22);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusBarLabel
            // 
            statusBarLabel.Name = "statusBarLabel";
            statusBarLabel.Size = new Size(0, 16);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colName, Status, RealTimeMoney, LastTransaction, Total });
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(902, 590);
            dataGridView1.TabIndex = 7;
            // 
            // btnLoop
            // 
            btnLoop.Location = new Point(472, 11);
            btnLoop.Name = "btnLoop";
            btnLoop.Size = new Size(94, 29);
            btnLoop.TabIndex = 8;
            btnLoop.Text = "Loop";
            btnLoop.UseVisualStyleBackColor = true;
            btnLoop.Click += btnLoop_Click;
            // 
            // colName
            // 
            colName.DataPropertyName = "Id";
            colName.HeaderText = "Pump Name";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // RealTimeMoney
            // 
            RealTimeMoney.DataPropertyName = "RealTimeMoney";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            RealTimeMoney.DefaultCellStyle = dataGridViewCellStyle1;
            RealTimeMoney.HeaderText = "Real Time Money";
            RealTimeMoney.MinimumWidth = 240;
            RealTimeMoney.Name = "RealTimeMoney";
            RealTimeMoney.Width = 240;
            // 
            // LastTransaction
            // 
            LastTransaction.DataPropertyName = "LastTransaction";
            LastTransaction.HeaderText = "Last Transaction";
            LastTransaction.MinimumWidth = 480;
            LastTransaction.Name = "LastTransaction";
            LastTransaction.Width = 480;
            // 
            // Total
            // 
            Total.DataPropertyName = "PumpTotal";
            Total.HeaderText = "Total";
            Total.MinimumWidth = 480;
            Total.Name = "Total";
            Total.Width = 480;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 678);
            Controls.Add(btnLoop);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip1);
            Controls.Add(btnConnect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboComPortList);
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboComPortList;
        private Label label1;
        private Button btnConnect;
        private Label label2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusBarLabel;
        private DataGridView dataGridView1;
        private Button btnLoop;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn RealTimeMoney;
        private DataGridViewTextBoxColumn LastTransaction;
        private DataGridViewTextBoxColumn Total;
    }
}
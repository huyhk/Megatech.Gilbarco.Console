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
            cboComPortList = new ComboBox();
            label1 = new Label();
            btnConnect = new Button();
            label2 = new Label();
            txtOutput = new TextBox();
            label3 = new Label();
            label5 = new Label();
            txtSentData = new TextBox();
            statusStrip1 = new StatusStrip();
            statusBarLabel = new ToolStripStatusLabel();
            dataGridView1 = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Action = new DataGridViewButtonColumn();
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
            // txtOutput
            // 
            txtOutput.Location = new Point(460, 423);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.Size = new Size(293, 230);
            txtOutput.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(339, 423);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 1;
            label3.Text = "Response Data";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 426);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 1;
            label5.Text = "Data Sent";
            // 
            // txtSentData
            // 
            txtSentData.Location = new Point(141, 420);
            txtSentData.Multiline = true;
            txtSentData.Name = "txtSentData";
            txtSentData.Size = new Size(193, 230);
            txtSentData.TabIndex = 4;
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colName, Status, Action });
            dataGridView1.Location = new Point(141, 63);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(612, 351);
            dataGridView1.TabIndex = 7;
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
            // Action
            // 
            Action.HeaderText = "";
            Action.MinimumWidth = 6;
            Action.Name = "Action";
            Action.Width = 125;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 678);
            Controls.Add(dataGridView1);
            Controls.Add(statusStrip1);
            Controls.Add(txtSentData);
            Controls.Add(txtOutput);
            Controls.Add(btnConnect);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboComPortList);
            Name = "Form1";
            Text = "Form1";
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
        private TextBox txtOutput;
        private Label label3;
        private Label label5;
        private TextBox txtSentData;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusBarLabel;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewButtonColumn Action;
    }
}
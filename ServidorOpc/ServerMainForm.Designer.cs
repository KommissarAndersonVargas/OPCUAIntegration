namespace ServidorOpc
{
    partial class ServerMainForm
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
            components = new System.ComponentModel.Container();
            btnConnect = new Button();
            label1 = new Label();
            lblVariableValue = new Label();
            panel1 = new Panel();
            label2 = new Label();
            opcListView = new ListView();
            columnOpcValue = new ColumnHeader();
            panel2 = new Panel();
            lblServerName = new Label();
            modbusTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.FlatStyle = FlatStyle.Flat;
            btnConnect.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConnect.ForeColor = SystemColors.ButtonFace;
            btnConnect.Location = new Point(64, 17);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(275, 64);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Conectar Servidor Opc";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(9, 237);
            label1.Name = "label1";
            label1.Size = new Size(119, 17);
            label1.TabIndex = 3;
            label1.Text = "Valor da variavel: ";
            // 
            // lblVariableValue
            // 
            lblVariableValue.AutoSize = true;
            lblVariableValue.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblVariableValue.ForeColor = SystemColors.ButtonFace;
            lblVariableValue.Location = new Point(124, 237);
            lblVariableValue.Name = "lblVariableValue";
            lblVariableValue.Size = new Size(81, 17);
            lblVariableValue.TabIndex = 4;
            lblVariableValue.Text = "[valor_aqui]";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnConnect);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 359);
            panel1.Name = "panel1";
            panel1.Size = new Size(401, 91);
            panel1.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(9, 268);
            label2.Name = "label2";
            label2.Size = new Size(59, 17);
            label2.TabIndex = 6;
            label2.Text = "Cliente: ";
            // 
            // opcListView
            // 
            opcListView.BackColor = SystemColors.InactiveCaptionText;
            opcListView.Columns.AddRange(new ColumnHeader[] { columnOpcValue });
            opcListView.Dock = DockStyle.Fill;
            opcListView.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            opcListView.ForeColor = Color.White;
            opcListView.Location = new Point(0, 0);
            opcListView.Name = "opcListView";
            opcListView.Size = new Size(401, 216);
            opcListView.TabIndex = 7;
            opcListView.UseCompatibleStateImageBehavior = false;
            opcListView.View = View.Details;
            // 
            // columnOpcValue
            // 
            columnOpcValue.Text = "Opc Value";
            // 
            // panel2
            // 
            panel2.Controls.Add(opcListView);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(401, 216);
            panel2.TabIndex = 8;
            // 
            // lblServerName
            // 
            lblServerName.AutoSize = true;
            lblServerName.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblServerName.ForeColor = SystemColors.ButtonFace;
            lblServerName.Location = new Point(64, 268);
            lblServerName.Name = "lblServerName";
            lblServerName.Size = new Size(81, 17);
            lblServerName.TabIndex = 9;
            lblServerName.Text = "[valor_aqui]";
            // 
            // ServerMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(401, 450);
            Controls.Add(lblServerName);
            Controls.Add(panel2);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(lblVariableValue);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ServerMainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receptor OPC UA";
            Load += ServerMainForm_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private Label label1;
        private Label lblVariableValue;
        private Panel panel1;
        private Label label2;
        private ListView opcListView;
        private Panel panel2;
        private ColumnHeader columnOpcValue;
        private Label lblServerName;
        private System.Windows.Forms.Timer modbusTimer;
    }
}

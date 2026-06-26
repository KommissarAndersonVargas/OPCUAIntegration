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
            lblVariable = new Label();
            lblVariableValue = new Label();
            panel1 = new Panel();
            lblClient = new Label();
            opcListView = new ListView();
            columnOpcValue = new ColumnHeader();
            panel2 = new Panel();
            lblServerName = new Label();
            modbusTimer = new System.Windows.Forms.Timer(components);
            comboBoxSerialPorts = new ComboBox();
            lblSerialPorts = new Label();
            lblModBus = new Label();
            radioBtnEnableModbus = new RadioButton();
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
            btnConnect.Text = "Conectar Servidor OPC UA";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblVariable
            // 
            lblVariable.AutoSize = true;
            lblVariable.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblVariable.ForeColor = SystemColors.ButtonFace;
            lblVariable.Location = new Point(9, 237);
            lblVariable.Name = "lblVariable";
            lblVariable.Size = new Size(119, 17);
            lblVariable.TabIndex = 3;
            lblVariable.Text = "Valor da variavel: ";
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
            // lblClient
            // 
            lblClient.AutoSize = true;
            lblClient.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblClient.ForeColor = SystemColors.ButtonFace;
            lblClient.Location = new Point(9, 268);
            lblClient.Name = "lblClient";
            lblClient.Size = new Size(59, 17);
            lblClient.TabIndex = 6;
            lblClient.Text = "Cliente: ";
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
            // comboBoxSerialPorts
            // 
            comboBoxSerialPorts.FormattingEnabled = true;
            comboBoxSerialPorts.Location = new Point(77, 322);
            comboBoxSerialPorts.Name = "comboBoxSerialPorts";
            comboBoxSerialPorts.Size = new Size(154, 23);
            comboBoxSerialPorts.TabIndex = 10;
            // 
            // lblSerialPorts
            // 
            lblSerialPorts.AutoSize = true;
            lblSerialPorts.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblSerialPorts.ForeColor = SystemColors.ButtonFace;
            lblSerialPorts.Location = new Point(12, 322);
            lblSerialPorts.Name = "lblSerialPorts";
            lblSerialPorts.Size = new Size(55, 17);
            lblSerialPorts.TabIndex = 11;
            lblSerialPorts.Text = "Portas: ";
            // 
            // lblModBus
            // 
            lblModBus.AutoSize = true;
            lblModBus.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblModBus.ForeColor = SystemColors.ButtonFace;
            lblModBus.Location = new Point(12, 297);
            lblModBus.Name = "lblModBus";
            lblModBus.Size = new Size(124, 17);
            lblModBus.TabIndex = 12;
            lblModBus.Text = "Habilitar Modbus: ";
            // 
            // radioBtnEnableModbus
            // 
            radioBtnEnableModbus.AutoSize = true;
            radioBtnEnableModbus.Location = new Point(137, 297);
            radioBtnEnableModbus.Name = "radioBtnEnableModbus";
            radioBtnEnableModbus.Size = new Size(94, 19);
            radioBtnEnableModbus.TabIndex = 13;
            radioBtnEnableModbus.TabStop = true;
            radioBtnEnableModbus.Text = "radioButton1";
            radioBtnEnableModbus.UseVisualStyleBackColor = true;
            // 
            // ServerMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(401, 450);
            Controls.Add(radioBtnEnableModbus);
            Controls.Add(lblModBus);
            Controls.Add(lblSerialPorts);
            Controls.Add(comboBoxSerialPorts);
            Controls.Add(lblServerName);
            Controls.Add(panel2);
            Controls.Add(lblClient);
            Controls.Add(panel1);
            Controls.Add(lblVariableValue);
            Controls.Add(lblVariable);
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
        private Label lblVariable;
        private Label lblVariableValue;
        private Panel panel1;
        private Label lblClient;
        private ListView opcListView;
        private Panel panel2;
        private ColumnHeader columnOpcValue;
        private Label lblServerName;
        private System.Windows.Forms.Timer modbusTimer;
        private ComboBox comboBoxSerialPorts;
        private Label lblSerialPorts;
        private Label lblModBus;
        private RadioButton radioBtnEnableModbus;
    }
}

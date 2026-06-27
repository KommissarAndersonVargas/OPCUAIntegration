using Opc.Ua;
using Opc.Ua.Client;
using ServidorOpc.Factories;
using System.IO.Ports;
using Modbus.Device;


namespace ServidorOpc
{
    public partial class ServerMainForm : Form
    {

        private Session Session;
        private Subscription Subscription;
        private MonitoredItem MonitoredItemValue;

        // MODBUS NMODBUS4
        private SerialPort serialPort;
        private IModbusSerialMaster modbusMaster;
        private readonly object modbusLock = new object();
        private bool isSending = false; // evita sobreposição de envios


        public ServerMainForm()
        {
            InitializeComponent();
            LoadSerialPorts();
        }

        private void LoadSerialPorts()
        {
            string[] ports = SerialPort.GetPortNames();

            comboBoxSerialPorts.Items.Clear();

            foreach (string port in ports)
            {
                comboBoxSerialPorts.Items.Add(port);
            }

            if (comboBoxSerialPorts.Items.Count > 0)
            {
                comboBoxSerialPorts.SelectedIndex = 0;
            }
        }

        public void ConfigureTimer()
        {
            modbusTimer.Stop();
            modbusTimer.Interval = 2000; // Arduino precisa de tempo para responder
            modbusTimer.Tick -= ModbusTimer_Tick;
            modbusTimer.Tick += ModbusTimer_Tick;
            modbusTimer.Start();
        }

        private void ConfigureModbus()
        {
            try
            {
                serialPort = new SerialPort(comboBoxSerialPorts.SelectedItem.ToString())
                {
                    BaudRate = 9600,
                    DataBits = 8,
                    Parity = Parity.None,
                    StopBits = StopBits.One,
                    ReadTimeout = 2000,
                    WriteTimeout = 2000
                };

                serialPort.Open();

                modbusMaster = ModbusSerialMaster.CreateRtu(serialPort);
                modbusMaster.Transport.ReadTimeout = 2000;
                modbusMaster.Transport.Retries = 1;

                MessageBox.Show($"Modbus conectado em {serialPort.PortName}", "Modbus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao configurar Modbus: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ModbusTimer_Tick(object sender, EventArgs e)
        {
            if (isSending) 
                return;

            if (modbusMaster == null || serialPort == null || !serialPort.IsOpen)
                return;

            var values = MonitoredItemValue?.DequeueValues();

            if (values == null || values.Count == 0)
                return;

            isSending = true;
            modbusTimer.Stop();

            try
            {
                var value = values.First();
                ushort valorParaEnviar = Convert.ToUInt16(value.Value);

                await Task.Run(() =>
                {
                    lock (modbusLock)
                    {
                        modbusMaster.WriteSingleRegister(1, 0, valorParaEnviar);
                    }
                });
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show("Falha Modbus:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }));
            }
            finally
            {
                isSending = false;
                modbusTimer.Start();
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Session = await OpcConnection.CreateOpcUAConnection();

                lblServerName.Text = OpcConnection.GetClientName();

                MessageBox.Show("Conexão estabelecida", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                IniciarMonitoramento();
                EnableModbus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar conectar {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableModbus()
        {
            if (radioBtnEnableModbus.Checked)
            {
                ConfigureModbus();
                ConfigureTimer();
            }
        }

        private void IniciarMonitoramento()
        {
            Subscription = OpcUAFactoryConfig.GetSubscription(Session);

            MonitoredItemValue = OpcUAFactoryConfig.GetMonitoration(Subscription);
            MonitoredItemValue.Notification += OnUpdateValue;

            Subscription.AddItem(MonitoredItemValue);

            Session.AddSubscription(Subscription);

            Subscription.Create();
        }

        private void OnUpdateValue(MonitoredItem item, MonitoredItemNotificationEventArgs e)
        {
            foreach (var valor in item.DequeueValues())
            {
                Invoke(() =>
                {
                    lblVariableValue.Text = $"{valor.Value} ---- Time: {DateTime.Now}";
                    opcListView.Items.Insert(0, $"{valor.Value} ---- Time: {DateTime.Now}");
                });
            }
        }
        private void ServerMainForm_Load(object sender, EventArgs e)
        {
            opcListView.Columns.Clear();
            opcListView.Columns.Add("Opc Value", opcListView.Width - 4, HorizontalAlignment.Left);

            lblServerName.Text =
                "Desconectado";
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                modbusTimer.Stop();

                if (serialPort != null &&
                   serialPort.IsOpen)
                {
                    serialPort.Close();
                }
            }
            catch
            {
            }
            base.OnFormClosing(e);
        }
    }
}
using EasyModbus;
using Opc.Ua;
using Opc.Ua.Client;
using ServidorOpc.Factories;
using System.IO.Ports;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ServidorOpc
{
    public partial class ServerMainForm : Form
    {
        private Session Session;
        private Subscription Subscription;
        private ModbusClient ModbusClient;
        private MonitoredItem MonitoredItemValue;
        private readonly object modbusLock = new object();
        private bool modbusBusy = false;

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
            modbusTimer.Interval = 3000;
            modbusTimer.Tick += ModbusTimer_Tick;
            modbusTimer.Start();
        }

        private void ConfigureModbus()
        {
            if (comboBoxSerialPorts.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma porta COM");
                return;
            }


            ModbusClient = new ModbusClient(
                comboBoxSerialPorts.SelectedItem.ToString()
            );

            ModbusClient.Baudrate = 9600;
            ModbusClient.Parity = Parity.None;
            ModbusClient.StopBits = StopBits.One;

            try
            {
                ModbusClient.Connect();

                MessageBox.Show("Modbus conectado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Modbus: " + ex.Message);
            }
        }

        private void ModbusTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ModbusClient == null || !ModbusClient.Connected)
                    return;


                var values = MonitoredItemValue.DequeueValues();


                foreach (var value in values)
                {
                    int valor = Convert.ToInt32(value.Value);


                    lock (modbusLock)
                    {
                        ModbusClient.WriteSingleRegister(0, valor);
                    }


                    break;
                }

            }
            catch (Exception ex)
            {
                modbusTimer.Stop();

                MessageBox.Show(
                    "Falha Modbus:\n" + ex.ToString()
                );
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Session = await OpcConnection.CreateOpcUAConnection();

                lblServerName.Text = OpcConnection.GetClientName();

                MessageBox.Show("Conexão estabelecida",
                    "Informação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                IniciarMonitoramento();
                EnableModbus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar conectar {ex.Message}", "" +
                    "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void EnableModbus()
        {
            if (radioBtnEnableModbus.Checked)
            {
                ConfigureModbus(); // ALTERAR se necessário
                ConfigureTimer();
            }
        }

        private void IniciarMonitoramento()
        {
            Subscription = OpcUAFactoryConfig.GetSubscription(Session);
            MonitoredItemValue = OpcUAFactoryConfig.GetMonitoration(Subscription); 

            MonitoredItemValue.Notification += OnUpdateValue; //atribui um metodo a um event para atualizar o label do valor atual (não foi IA que escreveu)
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
                    lblVariableValue.Text = $"{valor.Value}      --------- Time: {DateTime.Now}";
                    opcListView.Items.Insert(0, $"{valor.Value}  --------- Time: {DateTime.Now}");
                });
            }
        }

        private void ServerMainForm_Load(object sender, EventArgs e)
        {
            opcListView.Columns.Clear();
            opcListView.Columns.Add("Opc Value", opcListView.Width - 4, HorizontalAlignment.Left);
            lblServerName.Text = "Desconetado";
        }
    }
}

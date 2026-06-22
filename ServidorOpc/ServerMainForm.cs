using EasyModbus;
using Opc.Ua;
using Opc.Ua.Client;
using ServidorOpc.Factories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ServidorOpc
{
    public partial class ServerMainForm : Form
    {
        private Session Session;
        private Subscription Subscription;
        private OpcConnection OpcConnection;
        private ModbusClient ModbusClient;
        private MonitoredItem MonitoredItemValue;

        public ServerMainForm()
        {
            InitializeComponent();
            ConfigureModbus();
        }

        public void ConfigureTimer()
        {
            modbusTimer.Interval = 500;
            modbusTimer.Tick += ModbusTimer_Tick;
            modbusTimer.Start();
        }

        private void ConfigureModbus()
        {
            ModbusClient = new ModbusClient("COM5"); // ALTERAR se necessário
            ModbusClient.Baudrate = 9600;
            ModbusClient.Parity = System.IO.Ports.Parity.None;
            ModbusClient.StopBits = System.IO.Ports.StopBits.One;
            ModbusClient.Connect();
        }

        private void ModbusTimer_Tick(object sender, EventArgs e)
        {
            foreach (var value in MonitoredItemValue.DequeueValues())
            {
                //var = opcListView.Items.
                int passedValue = int.Parse(value.Value.ToString());
                ModbusClient.UnitIdentifier = 1;
                ModbusClient.WriteSingleRegister(0, passedValue);
            }
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                OpcConnection = new OpcConnection();
                Session = await OpcConnection.CreateOpcUAConnection();

                lblServerName.Text = OpcConnection.GetClientName();

                MessageBox.Show("Conexão estabelecida",
                    "Informação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                IniciarMonitoramento();
                ConfigureTimer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao tentar conectar {ex.Message}", "" +
                    "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void IniciarMonitoramento()
        {
            Subscription = new Subscription(Session.DefaultSubscription)
            {
                PublishingInterval = 500
            };

            MonitoredItemValue = new MonitoredItem(Subscription.DefaultItem) 
            {
                DisplayName = "MinhaVariavel",
                StartNodeId = NodeId.Parse("ns=3;i=1008"),
                SamplingInterval = 500
            };

            MonitoredItemValue.Notification += OnValorAtualizado; //atribui um metodo a um event para atualizar o label do valor atual (não foi IA que escreveu)
            Subscription.AddItem(MonitoredItemValue);

            Session.AddSubscription(Subscription);
            Subscription.Create();
        }

        private void OnValorAtualizado(MonitoredItem item, MonitoredItemNotificationEventArgs e)
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

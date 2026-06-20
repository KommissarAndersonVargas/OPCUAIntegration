using Opc.Ua;
using Opc.Ua.Client;
using ServidorOpc.Factories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ServidorOpc
{
    public partial class ServerMainForm : Form
    {
        private Session session;
        private Subscription subscription;

        public ServerMainForm()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                OpcConnection opcConnection = new OpcConnection();
                session = await opcConnection.CreateOpcUAConnection();

                lblServerName.Text = opcConnection.GetClientName();

                MessageBox.Show("Conexão estabelecida", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

                IniciarMonitoramento();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Erro ao tentar conectar {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void IniciarMonitoramento()
        {
            subscription = new Subscription(session.DefaultSubscription)
            {
                PublishingInterval = 500
            };

            var item = new MonitoredItem(subscription.DefaultItem)
            {
                DisplayName = "MinhaVariavel",
                StartNodeId = NodeId.Parse("ns=3;i=1008"),
                SamplingInterval = 500
            };

            item.Notification += OnValorAtualizado; //atribui um metodo a um event para atualizar o label do valor atual (não foi IA que escreveu)
            subscription.AddItem(item);

            session.AddSubscription(subscription);
            subscription.Create();
        }

        private void OnValorAtualizado(MonitoredItem item, MonitoredItemNotificationEventArgs e)
        {
            foreach (var valor in item.DequeueValues())
            {
                Invoke(() =>
                {
                    lblVariableValue.Text = $"{valor.Value}";
                    opcListView.Items.Insert(0, valor.Value.ToString());
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

using Opc.Ua;
using Opc.Ua.Client;

namespace ServidorOpc.Factories
{
    public class OpcUAFactoryConfig
    {
        private static Opc.Ua.ApplicationConfiguration _opcConnection;

        private static Subscription _subscription;

        private static MonitoredItem _monitoredItemValue;

        public static Opc.Ua.ApplicationConfiguration CreateOpcUAConfig()
        {
            if(_opcConnection is null)
            {
                _opcConnection = new Opc.Ua.ApplicationConfiguration()
                {
                    ApplicationName = "MeuClienteOPC",
                    ApplicationType = ApplicationType.Client,

                    SecurityConfiguration = new SecurityConfiguration
                    {
                        ApplicationCertificate = new CertificateIdentifier(),
                        AutoAcceptUntrustedCertificates = true,
                        RejectSHA1SignedCertificates = false
                    },

                    TransportConfigurations = new TransportConfigurationCollection(),
                    TransportQuotas = new TransportQuotas(),
                    ClientConfiguration = new ClientConfiguration()
                };
            }
           
            return _opcConnection;
        }

        public static Subscription GetSubscription(Session session)
        {
            if(_subscription is null)
            {
                _subscription = new Subscription(session.DefaultSubscription)
                {
                    PublishingInterval = 500
                };
            }
            return _subscription;
        }

        public static MonitoredItem GetMonitoration(Subscription subscription)
        {
            if (_monitoredItemValue is null)
            {
                _monitoredItemValue = new MonitoredItem(subscription.DefaultItem)
                {
                    DisplayName = "MinhaVariavel",
                    StartNodeId = NodeId.Parse("ns=3;i=1008"),
                    SamplingInterval = 500
                };
            }
            return _monitoredItemValue;
        }
    }
}

using Opc.Ua;

namespace ServidorOpc.Factories
{
    public class OpcUAFactoryConfig
    {
        private static Opc.Ua.ApplicationConfiguration OpcConnection;

        public static Opc.Ua.ApplicationConfiguration CreateOpcUAConfig()
        {
            if(OpcConnection is null)
            {
                OpcConnection = new Opc.Ua.ApplicationConfiguration()
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
           
            return OpcConnection;
        }
    }
}

using Opc.Ua.Client;
using Opc.Ua;

namespace ServidorOpc.Factories
{
    public class OpcConnection
    {
        private string EndpointUrl = "opc.tcp://localhost:53530/OPCUA/SimulationServer";

        public  async Task<Session> CreateOpcUAConnection()
        {
            var config = OpcUAFactoryConfig.CreacteOpcUAConfig();
            var selectedEndpoint = new EndpointDescription(EndpointUrl);

            var endpoint = CoreClientUtils.SelectEndpoint(config, EndpointUrl, useSecurity: false);
            var endpointConfiguration = EndpointConfiguration.Create(config);
            var configuredEndpoint = new ConfiguredEndpoint(null, endpoint, endpointConfiguration);

            return await Session.Create(config, configuredEndpoint, false, "ClienteOPC", 60000, new UserIdentity(new AnonymousIdentityToken()), null);
        }

        public string GetClientName()
        {
            return EndpointUrl;
        }

    }
}

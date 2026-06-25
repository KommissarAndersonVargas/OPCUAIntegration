using Opc.Ua.Client;
using Opc.Ua;

namespace ServidorOpc.Factories
{
    public class OpcConnection
    {
        private static string EndpointUrl = "opc.tcp://localhost:53530/OPCUA/SimulationServer";

        public static async Task<Session> CreateOpcUAConnection()
        {
            var config = OpcUAFactoryConfig.CreateOpcUAConfig();
            var selectedEndpoint = new EndpointDescription(EndpointUrl);

            var endpoint = CoreClientUtils.SelectEndpoint(config, EndpointUrl, useSecurity: false);
            var endpointConfiguration = EndpointConfiguration.Create(config);
            var configuredEndpoint = new ConfiguredEndpoint(null, endpoint, endpointConfiguration);

            return await Session.Create(config, configuredEndpoint, false, "ClienteOPC", 60000, new UserIdentity(new AnonymousIdentityToken()), null);
        }

        public static string GetClientName()
        {
            return EndpointUrl;
        }

    }
}

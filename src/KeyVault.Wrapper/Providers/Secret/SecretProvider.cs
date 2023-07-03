using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace KeyVault.Wrapper.Providers.Secret
{
    public class SecretProvider : KeyVaultBaseProvider, ISecretProvider
    {
        private readonly IOptions<Settings> _options;
        private readonly ILogger _logger;
        private readonly SecretClient _secretClient;

        public SecretProvider(IOptions<Settings> options, ILogger logger) : base(options)
        {
            _options = options;
            _logger = logger;
            _secretClient = new SecretClient(uri, credentialStrategy);
        }

        public async Task<string> GetSecret(string name)
        {
            _logger.LogDebug($"Retrieving Secret: {name}");
            var secret = await _secretClient.GetSecretAsync(name);
            return secret.Value.Value;
        }
    }
}

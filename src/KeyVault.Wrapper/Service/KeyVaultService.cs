using KeyVault.Wrapper.Providers.Certificate;
using KeyVault.Wrapper.Providers.Key;
using KeyVault.Wrapper.Providers.Secret;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KeyVault.Wrapper.Service
{
    public class KeyVaultService : IKeyVaultService
    {
        private readonly ICertificateProvider certificateProvider;
        private readonly ISecretProvider secretProvider;
        private readonly KeyProvider keyProvider;

        public KeyVaultService(IOptions<Settings> options, ILogger<KeyVaultService> logger)
        {
            certificateProvider = new CertificateProvider(options, logger);
            secretProvider = new SecretProvider(options, logger);
            keyProvider = new KeyProvider(options, logger);
        }
        public ICertificateProvider CertificateProvider => certificateProvider;

        public ISecretProvider SecretProvider => secretProvider;

        public IKeyProvider KeyProvider => keyProvider;

    }
}

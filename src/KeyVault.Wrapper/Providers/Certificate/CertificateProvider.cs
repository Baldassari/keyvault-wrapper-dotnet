using Azure.Security.KeyVault.Certificates;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace KeyVault.Wrapper.Providers.Certificate
{
    public class CertificateProvider : KeyVaultBaseProvider, ICertificateProvider
    {
        private readonly CertificateClient _certificateClient;
        private readonly ILogger _logger;

        public CertificateProvider(IOptions<Settings> options, ILogger logger) : base(options)
        {
            _certificateClient = new CertificateClient(uri, credentialStrategy);
            _logger = logger;
        }

        private async Task<KeyVaultCertificateWithPolicy> GetCertificate(string name)
        {
            _logger.LogDebug($"Retrieving Certificate: {name}");
            var certificatePolicy = await _certificateClient.GetCertificateAsync(name);
            return certificatePolicy.Value;
        }

        public virtual async Task<X509Certificate2> GetX509CertificateAsync(string name, string password)
        {
            var certificatePolicy = await GetCertificate(name);
            return new X509Certificate2(certificatePolicy.Cer, password);
        }
    }
}

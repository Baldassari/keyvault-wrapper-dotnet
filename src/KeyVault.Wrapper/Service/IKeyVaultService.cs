using KeyVault.Wrapper.Providers.Certificate;
using KeyVault.Wrapper.Providers.Key;
using KeyVault.Wrapper.Providers.Secret;

namespace KeyVault.Wrapper.Service
{
    public interface IKeyVaultService
    {
        ICertificateProvider CertificateProvider { get; }
        ISecretProvider SecretProvider { get; }
        IKeyProvider KeyProvider { get; }
    }
}

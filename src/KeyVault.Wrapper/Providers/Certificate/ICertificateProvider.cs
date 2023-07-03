using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace KeyVault.Wrapper.Providers.Certificate
{
    public interface ICertificateProvider
    {
        Task<X509Certificate2> GetX509CertificateAsync(string name, string password);
    }
}

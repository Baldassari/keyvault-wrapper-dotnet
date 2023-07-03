using System.Security.Cryptography;
using System.Threading.Tasks;

namespace KeyVault.Wrapper.Providers.Key
{
    public interface IKeyProvider
    {
        Task<RSA> GetKey(string name);
        Task<string?> Sign(string jsonString, string keyName);
    }
}

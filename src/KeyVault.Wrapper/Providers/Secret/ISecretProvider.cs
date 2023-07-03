using System.Threading.Tasks;

namespace KeyVault.Wrapper.Providers.Secret
{
    public interface ISecretProvider
    {
        Task<string> GetSecret(string name);
    }
}

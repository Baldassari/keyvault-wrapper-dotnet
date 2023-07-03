using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeyVault.Wrapper.Providers.Key
{
    public class KeyProvider : KeyVaultBaseProvider, IKeyProvider
    {
        private readonly ILogger _logger;
        private readonly KeyClient _keyClient;

        public KeyProvider(IOptions<Settings> options, ILogger logger) : base(options)
        {
            _logger = logger;
            _keyClient = new KeyClient(uri, credentialStrategy);
        }

        public async Task<RSA> GetKey(string name)
        {
            _logger.LogDebug($"Retrieving Key: {name}");
            var key = await _keyClient.GetKeyAsync(name);
            return key.Value.Key.ToRSA();
        }

        public async Task<string?> Sign(string jsonString, string keyName)
        {
            byte[] encryptBytes = Encoding.UTF8.GetBytes(jsonString);
            try
            {
                CryptographyClient cryptoClient = _keyClient.GetCryptographyClient(keyName);

                var signature = await cryptoClient.SignDataAsync(SignatureAlgorithm.RS256, encryptBytes);
                return Convert.ToBase64String(signature.Signature);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Could not sign json content with {keyName}" + ex.Message, ex.StackTrace);
                return null;
            }
        }
    }
}

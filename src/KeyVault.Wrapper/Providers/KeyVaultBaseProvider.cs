using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Options;
using System;

namespace KeyVault.Wrapper.Providers
{
    public class KeyVaultBaseProvider
    {
        protected readonly Uri uri;
        protected readonly TokenCredential credentialStrategy;

        protected KeyVaultBaseProvider(IOptions<Settings> options)
        {
            uri = new Uri(options.Value.KeyVaultUrl);
            credentialStrategy = new EnvironmentCredential();
        }
    }
}

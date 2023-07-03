using Azure.Identity;
using KeyVault.Wrapper.Service;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;

namespace KeyVault.Wrapper
{
    public static class ServiceExtension
    {
        public static void AddKeyVault(this IServiceCollection services, IConfiguration configuration)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);
            });
            var logger = loggerFactory.CreateLogger("KeyVault");
            try
            {
                services.Configure<Settings>(options =>
                {
                    options.KeyVaultUrl = configuration["KEY_VAULT_URL"];
                    options.AzureClientSecret = configuration["AZURE_CLIENT_SECRET"];
                    options.AzureTenantId = configuration["AZURE_TENANT_ID"];
                    options.AzureClientId = configuration["AZURE_CLIENT_ID"];
                });
                services.AddSingleton<IKeyVaultService, KeyVaultService>();

                services.AddDataProtection()
                    //This blob must already exist before the application is run
                    .PersistKeysToAzureBlobStorage(configuration["DataProtection:blobStorageConnectionString"],
                        configuration["DataProtection:blobStorageName"],
                        configuration["DataProtection:blobContainerName"]);
                logger.LogInformation("KeyVault initialized successfully.");
            }
            catch (Exception ex)
            {
                logger.LogError("KeyVault initialization Error.");
                logger.LogError(ex.Message);
            }
        }
    }
}

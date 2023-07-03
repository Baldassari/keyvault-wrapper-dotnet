## KeyVault.Wrapper

### Solution
This project was designed to abstract the implementation of Azure Keyvault. I strongly recommend using this project with Clean Architecture or Onion Architecture and
inject this class library into your infrastructure folder.

### Configuration

#### STEP 1: Add project dependency
#### STEP 2: Add service the service to .NET Dependency Injection Container
`services.AddKeyVault()`
#### STEP 3: Add required app settings [KEY_VAULT_URL, AZURE_CLIENT_SECRET, AZURE_TENANT_ID, AZURE_CLIENT_ID]

#### STEP 4: Add IKeyVaultService as a dependency in your business class and enjoy :)

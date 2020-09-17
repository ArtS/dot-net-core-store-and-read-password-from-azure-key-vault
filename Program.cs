using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace dot_net_core_store_and_read_password_from_azure_key_vault
{
    class Program
    {
        static void Main(string[] args)
        {
            // To get URL of your Key Vault, run
            // "az keyvault show -n <your-key-vault-name>" and look for "vaultUrl" in the output
            var keyVaultUrl = "https://<your-key-vault-name>.vault.azure.net/";

            // Two ways to authenticate, pick one only.
            // 1. Supply Tennnt Id, Client Id and a Secret directly
            // 2. Use Environment Variables that contain that information

            // To obtain values for either of these steps, refer to the output ofcommand
            // `az ad sp create-for-rbac -n <your-app-name> --skip-assignment`

            // 1. Replace the values below with appropriate data and uncomment
            /*
            var credential = new ClientSecretCredential(
                "AZURE_TENANT_ID",  // use value from "tenant"
                "AZURE_CLIENT_ID", //  use value from "appId"
                "AZURE_CLIENT_SECRET" // use value from "password"
            );
            var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential);
            */

            // 2. Creates Credential onject using environment variables
            // "AZURE_TENANT_ID", "AZURE_CLIENT_ID" and "AZURE_CLIENT_SECRET"
            // If those variables not set, Azure call will fail.
            var credential =  new DefaultAzureCredential();

            var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential);

            KeyVaultSecret secret = client.GetSecret("<your-secret-name>");

            Console.WriteLine($"{secret.Name}: {secret.Value}");
        }
    }
}

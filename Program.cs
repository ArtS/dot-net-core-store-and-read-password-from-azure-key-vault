using System;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;

namespace dot_net_core_encrypted_local_config
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());
            Console.WriteLine("Hello World!");
        }
    }
}
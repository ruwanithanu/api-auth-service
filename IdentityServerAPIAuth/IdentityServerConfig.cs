using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerAPIAuth
{
    public class IdentityServerConfig
    {
        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("Stagebox", "Stagebox API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                //PROD Credentials for Stagebox developer team testing
                new Client
                {
                    ClientId = "devCCProdClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("devCCProdSecret".Sha256()) },
                    AllowedScopes = { "Stagebox" }
                },
                new Client
                {
                    ClientId = "devRopProdClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {new Secret("devRopProdSecret".Sha256()) },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "Stagebox", IdentityServerConstants.StandardScopes.OfflineAccess },
                    UpdateAccessTokenClaimsOnRefresh = true
                },
                //PROD Credentials for NS , JiBe & ES
                new Client
                {
                    ClientId = "AESBJB4A917DC34FBD47C0B54BBDE6110668C4",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("FJtLIJGuR8TJ9hGD0JtR6ydAZkEnnwzVWeDHQ4bYrfbjizGuCekbg0IAjG1O7rRxUlzHaJ".Sha256()) },
                    AllowedScopes = { "Stagebox" }
                },
                new Client
                {
                    ClientId = "AESBNS680838703C4E4F02991E4EC711692BA0",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("apVfpvNVF44iriYe9SCI5l0mq7A9snJDZXMeB7paoHXEaIcyujTmAHqw88WoJzs1VVALsu".Sha256()) },
                    AllowedScopes = { "Stagebox" }
                },
                new Client
                {
                    ClientId = "AESBES8FFEEB84A93F40BEB4B7AC0E49B70AF0",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("L8pQqQAtx4x5K5zMaDnnrqLzaQYyzuNTzGLbFTwLChjV6mgrDG5wj2GrnUGtkTxHF4dXXf".Sha256()) },
                    AllowedScopes = { "Stagebox" }
                }
                //Test, MIG Environments
                //new Client
                //{
                //    ClientId = "devCCClient",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = {new Secret("devCCSecret".Sha256()) },
                //    AllowedScopes = { "Stagebox" }
                //},
                //new Client
                //{
                //    ClientId = "devRopClient",
                //    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                //    ClientSecrets = {new Secret("devRopsecret".Sha256()) },
                //    AllowOfflineAccess = true,
                //    AllowedScopes = { "Stagebox", IdentityServerConstants.StandardScopes.OfflineAccess },
                //    UpdateAccessTokenClaimsOnRefresh = true
                //},
                //new Client
                //{
                //    ClientId = "AESBJB0B17F631177445349BA91F7DE6111CCC",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = {new Secret("QZJGmZvorFJpUkJIxK5uoLb6s7Wctwhze8XJpIlEQ9vmh0uGYOJ94evQAjxFkrxUGnI3pL".Sha256()) },
                //    AllowedScopes = { "Stagebox" }
                //},
                //new Client
                //{
                //    ClientId = "AESBNS12B0A66C897C4B19B6647B86AF541D77",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = {new Secret("U4QqgRoJz8qWcN3rx3Mz7chabBbzCR73FGaUfRSG8CcwtctsHnrFsVjcLv5paryAaxi7b7".Sha256()) },
                //    AllowedScopes = { "Stagebox" }
                //},
                //new Client
                //{
                //    ClientId = "AESBES89BFF845E7AF481AB3BDB0AAD9386ABA",
                //    AllowedGrantTypes = GrantTypes.ClientCredentials,
                //    ClientSecrets = {new Secret("DbzUBz5cJFr9qJnvrDVRQkcf4AHevVzsrPHtqZhCNrFpQtSLqRF8v63GyyvdcPLRJA4Kkx".Sha256()) },
                //    AllowedScopes = { "Stagebox" }
                //}
            };
        }
    }
}

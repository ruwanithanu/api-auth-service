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
                new Client
                {
                    ClientId = "devCCClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("devCCSecret".Sha256()) },
                    AllowedScopes = { "Stagebox" }
                },
                new Client
                {
                    ClientId = "devRopClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {new Secret("devRopsecret".Sha256()) },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "Stagebox", IdentityServerConstants.StandardScopes.OfflineAccess },
                    UpdateAccessTokenClaimsOnRefresh = true
                },
                new Client
                {
                    ClientId = "AESBJB0B17F631177445349BA91F7DE6111CCC",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("QZJGmZvorFJpUkJIxK5uoLb6s7Wctwhze8XJpIlEQ9vmh0uGYOJ94evQAjxFkrxUGnI3pL".Sha256()) },
                    AllowedScopes = { "Stagebox" }
                },
                new Client
                {
                    ClientId = "AESBNS12B0A66C897C4B19B6647B86AF541D77",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("U4QqgRoJz8qWcN3rx3Mz7chabBbzCR73FGaUfRSG8CcwtctsHnrFsVjcLv5paryAaxi7b7".Sha256()) },
                    AllowedScopes = { "Stagebox" }
                }
            };
        }
    }
}

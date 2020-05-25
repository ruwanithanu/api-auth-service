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
                }
            };
        }
    }
}

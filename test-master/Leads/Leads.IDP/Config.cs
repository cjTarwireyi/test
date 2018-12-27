using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;               // Claim
using IdentityServer4;                      // IdentityServerConstants
using IdentityServer4.Test;                 // TestUser
using IdentityServer4.Models;

namespace Leads.IDP
{
    public class Config
    {
        // Authenticated Users
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "dv323423-234kj432-438723-42jkasfsdf",
                    Username = "Mike",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Michael"),
                        new Claim("family_name", "Hendricks"),
                        new Claim("address", "Main Road 1")
                    }
                },
                new TestUser
                {
                    SubjectId = "dje239874-kl83jkld-jkaf32-2ji32i23",
                    Username = "Sarah",
                    Password = "password",

                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Sarah"),
                        new Claim("family_name", "Kapula"),
                        new Claim("address", "Town Road 1")
                    }
                }
            };
        }

        // identity-related resources (scopes)
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        // Client Applications, that is being authenticated with IDP
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientName = "Leads",
                    ClientId = "leadsclientid",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44336/signin-oidc",
                        "https://localhost:44336/"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:44336/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                },
                new Client
                {
                    ClientName = "Angular Client",
                    ClientId = "ng",
                    AllowedGrantTypes = GrantTypes.Implicit
                }
            };
        }
    }
}

using Duende.IdentityServer.Models;

namespace MagicVilla_IdentityV1
{
    public static class SD
    {
        public const string Admin = "admin";
        public const string Customer = "customer";

        public static IEnumerable<IdentityResource> identityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };
    }
}

using System.Linq;
using System.Security.Principal;

namespace CommandQuery.Sample.Tests
{
    public class TestPrincipal : IPrincipal
    {
        // Fields
        private readonly IIdentity identity;

        private readonly string[] roles;

        // Methods
        public TestPrincipal(IIdentity identity, string[] roles)
        {
            this.identity = identity;
            this.roles = roles;
        }

        public bool IsInRole(string role)
        {
            return roles != null && roles.ToList().Contains(role);
        }

        // Properties
        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }
    }
}
using System;
using System.Security.Principal;

namespace CommandQuery.Sample.Tests
{
    public class TestIdentity : IIdentity
    {
        // Fields
        private readonly string name;

        // Methods
        public TestIdentity(string userName)
        {
            name = userName;
        }

        // Properties
        public string AuthenticationType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return !string.IsNullOrEmpty(name);
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
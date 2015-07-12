using System.Collections.Generic;
using System.Security.Principal;
using Nancy.Security;

namespace SwimBikeRun.Strive.Modules
{
    public class User : IUserIdentity, IPrincipal
    {
        public IEnumerable<string> Claims { get; set; }
        public IIdentity Identity { get { return new GenericIdentity(UserName); } }
        public string UserName { get; set; }

        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException("Only included to satisfy the interface an implementation is not required.");
        }
    }
}

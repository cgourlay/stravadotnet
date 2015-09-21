using System.Threading;

using Nancy;

using SwimBikeRun.Strive.Modules.Security;

namespace SwimBikeRun.Strive.Modules
{
    public abstract class SecureModule : NancyModule
    {
        protected SecureModule(string modulePath) : base(modulePath)
        {
            Before += context =>
            {
                var authorizationHeader = context.Request.Headers["Authorization"];
                if (authorizationHeader == null) { return new Response { StatusCode = HttpStatusCode.Unauthorized }; }

                var accessToken = context.Request.Headers.Authorization;
                if (string.IsNullOrEmpty(accessToken)) { return new Response { StatusCode = HttpStatusCode.Unauthorized }; }

                Thread.CurrentPrincipal = new User { UserName = accessToken };

                return null;
            };
        }
    }
}

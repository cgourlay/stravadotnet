using System.Threading;

using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

using com.strava.api.Workflows;

namespace com.strava.api.Helpers.Nancy
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(typeof(ISegmentWorkflow), typeof(SegmentWorkflow));
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.BeforeRequest += ctx =>
            {
                var authorizationHeader = ctx.Request.Headers["Authorization"];
                if(authorizationHeader == null) { return new Response { StatusCode = HttpStatusCode.Unauthorized }; }

                var accessToken = ctx.Request.Headers.Authorization;
                if (string.IsNullOrEmpty(accessToken)) { return new Response { StatusCode = HttpStatusCode.Unauthorized }; }

                Thread.CurrentPrincipal = new User { UserName = accessToken };
                
                return null;
            };
            
            base.RequestStartup(container, pipelines, context);
        }
    }
}
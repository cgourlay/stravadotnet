using System.Threading;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

using SwimBikeRun.Workflows;
using com.Strava.Api.Repositories;

namespace com.Strava.Api.Helpers.Nancy
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(typeof(ISegmentWorkflow), typeof(SegmentWorkflow));
            container.Register(typeof(IProvider), typeof(Neo4JProvider));
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
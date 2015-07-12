using System.Threading;
using com.Strava.Api.Repositories;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using SwimBikeRun.Strive.Repositories;
using SwimBikeRun.Strive.Workflows;

namespace SwimBikeRun.Strive.Modules
{
    public class SwimBikeRunBootstrapper : DefaultNancyBootstrapper
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
                if (authorizationHeader == null) { return new Response { StatusCode = HttpStatusCode.Unauthorized }; }

                var accessToken = ctx.Request.Headers.Authorization;
                if (string.IsNullOrEmpty(accessToken)) { return new Response { StatusCode = HttpStatusCode.Unauthorized }; }

                Thread.CurrentPrincipal = new User { UserName = accessToken };

                return null;
            };

            base.RequestStartup(container, pipelines, context);
        }
    }
}
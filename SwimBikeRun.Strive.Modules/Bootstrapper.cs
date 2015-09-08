using System.Threading;

using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

using SwimBikeRun.Strive.Modules.Security;
using SwimBikeRun.Strive.Repositories;
using SwimBikeRun.Strive.Representations;
using SwimBikeRun.Strive.Workflows;
using SwimBikeRun.Strive.Workflows.Interfaces;

namespace SwimBikeRun.Strive.Modules
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        public Bootstrapper() { } // Must be public so it can be used with the Nancy.Testing.Browser class.

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(typeof(ISegmentWorkflow), typeof(SegmentWorkflow));
            container.Register(typeof(IEndpoints), typeof(Endpoints));
            container.Register(typeof(IRepository), typeof(Neo4JProvider));
        }
    }
}
using Nancy;
using Nancy.TinyIoc;

using com.strava.api.Workflows;

namespace com.strava.api.Helpers.Nancy
{
    internal sealed class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register(typeof(ISegmentWorkflow), typeof(SegmentWorkflow));
        }
    }
}

using Nancy;
using Nancy.Configuration;
using Nancy.Session.Persistable;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.Session.InMemory;

namespace QuotingDojoRedux
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            PersistableSessions.Enable(pipelines, new InMemorySessionConfiguration());
        }

        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(enabled: false, displayErrorTraces: true);
        }
    }
}
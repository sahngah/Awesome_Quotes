using Microsoft.AspNetCore.Builder;
using Nancy.Owin;
using Microsoft.Extensions.Logging;

namespace QuotingDojoRedux
{ 
    public class Startup
    {
        public void Configure(IApplicationBuilder app, ILoggerFactory LoggerFactory)
        { 
            app.UseOwin(x => x.UseNancy());
        }
    }
}
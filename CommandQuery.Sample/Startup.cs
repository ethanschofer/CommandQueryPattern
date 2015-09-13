using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CommandQuery.Sample.Startup))]
namespace CommandQuery.Sample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureContainer(app);            
        }
    }
}
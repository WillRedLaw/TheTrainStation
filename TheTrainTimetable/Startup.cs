using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheTrainTimetable.Startup))]
namespace TheTrainTimetable
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

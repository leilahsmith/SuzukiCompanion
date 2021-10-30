using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using SuzukiCompanion.Services;

[assembly: OwinStartupAttribute(typeof(SuzukiCompanion.WebMVC.Startup))]
namespace SuzukiCompanion.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var svc = new RoleService();
            svc.CreateAdmin();
            svc.MakeMyUserAdmin();
        }
    }
}

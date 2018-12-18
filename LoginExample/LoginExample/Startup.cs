using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.Owin;

[assembly: OwinStartup(typeof(LoginExample.Startup))]

namespace LoginExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            app.CreatePerOwinContext(() => new IdentityDbContext(connectionString));
            app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, cont) => new UserStore<IdentityUser>(cont.Get<IdentityDbContext>()));

            app.CreatePerOwinContext<UserManager<IdentityUser>>(                (opt, cont) => new UserManager<IdentityUser>(cont.Get<UserStore<IdentityUser>>()));



            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888



        }
    }
}

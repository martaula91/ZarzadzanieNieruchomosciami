using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //GlobalConfiguration.Configuration.UseSqlServerStorage("ZarzadzanieContext");
            //app.UseHangfireDashboard();
           // app.UseHangfireServer();
        }
    }
}
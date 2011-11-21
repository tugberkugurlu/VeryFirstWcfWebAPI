using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Ninject;

namespace VeryFirstWcfWebAPI {

    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {

            RouteTable.Routes.SetDefaultHttpConfiguration(new Microsoft.ApplicationServer.Http.WebApiConfiguration() { 
                CreateInstance = (serviceType, context, request) => GetKernel().Get(serviceType)
            });

            RouteTable.Routes.MapServiceRoute<People.PeopleApi>("Api/People");
        }

        private IKernel GetKernel() { 
            
            IKernel kernel = new StandardKernel();

            kernel.Bind<People.Infrastructure.IPeopleRepository>().
                To<People.Models.PeopleRepository>();

            return kernel;
        }

    }
}
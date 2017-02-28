using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using WeBikeWeb.Models;
using WeBikeWeb.Aplicacao.AutoMapper;

namespace WeBikeWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //ja converte as view models para dominio
            AutoMapperConfig.RegisterMappings();

            var db = new Contexto();             
            db.Database.CreateIfNotExists();

            //var applicationDbContextdb = new ApplicationDbContext();
            //applicationDbContextdb.Database.CreateIfNotExists();

            using (var context = new Contexto())
            {
                context.Database.Initialize(force: true);
            }

            //using (var context = new ApplicationDbContext())
            //{
            //    context.Database.Initialize(force: true);
            //}
        }
    }
}

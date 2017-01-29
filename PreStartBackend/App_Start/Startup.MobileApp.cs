using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Owin;
using PreStartBackend.DataObjects;
using PreStartBackend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;

namespace PreStartBackend
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new MobileServiceInitializer());

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    // This middleware is intended to be used locally for debugging. By default, HostName will
                    // only have a value when running in an App Service application.
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }

            app.UseWebApi(config);
        }
    }

    public class MobileServiceInitializer : DropCreateDatabaseIfModelChanges<MobileServiceContext>
    {
        //protected override void Seed(MobileServiceContext context)
        //{
        //    //List<Site> sites = new List<Site>
        //    //{
        //    //    new Site {Id = Guid.NewGuid().ToString(), Name = "Northern Intersection"},
        //    //    new Site {Id = Guid.NewGuid().ToString(), Name = "Cycleway"},
        //    //    new Site {Id = Guid.NewGuid().ToString(), Name = "Quarry"},
        //    //    new Site {Id = Guid.NewGuid().ToString(), Name = "Motorway"},
        //    //    new Site {Id = Guid.NewGuid().ToString(), Name = "Stadium"},
        //    //    new Site {Id = Guid.NewGuid().ToString(), Name = "Yard"}
        //    //};

        //    //foreach (var site in sites)
        //    //{
        //    //    context.Set<Site>().Add(site);
        //    //}

        //    base.Seed(context);
        //}
    }
}


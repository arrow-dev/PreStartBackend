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
        protected override void Seed(MobileServiceContext context)
        {
            List<Hazard> hazards = new List<Hazard>
            {
                new Hazard {Id = Guid.NewGuid().ToString(), Task = "Driving"},
                new Hazard {Id = Guid.NewGuid().ToString(), Task = "Site set up"},
                new Hazard {Id = Guid.NewGuid().ToString(), Task = "Heavy lift"},
                new Hazard {Id = Guid.NewGuid().ToString(), Task = "Laying Bitumen"},
                new Hazard {Id = Guid.NewGuid().ToString(), Task = "Digging"},
                new Hazard {Id = Guid.NewGuid().ToString(), Task = "Cleaning up site"}
            };

            foreach (var hazard in hazards)
            {
                context.Set<Hazard>().Add(hazard);
            }

            base.Seed(context);
        }
    }
}


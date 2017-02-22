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

            List<string> prestartIds = new List<string>();

            List<Prestart> prestarts = new List<Prestart>
            {
                new Prestart
                {
                    Id = Guid.NewGuid().ToString(), ContractName = "Motorway", ContractNumber = "3202", Location = "Canterbury", LotNo = "50", 
                    Department = "Civil", SiteId = "Southern Overpass", JobNumber = "222", SiteManager = "John Johnson", StmsNumber = "324234",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                    Doing = "Fulton Hogan crew are clearing debris, Survey crew setting up profiles.", PlantEquipment = "Loader and Dump truck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare site for Roading team.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now.AddDays(-2)
                },

                new Prestart
                {
                    Id = Guid.NewGuid().ToString(), ContractName = "Motorway", ContractNumber = "3202", Location = "Canterbury", LotNo = "50",
                    Department = "Civil", SiteId = "Hornby Intersection", JobNumber = "333", SiteManager = "John Johnson", StmsNumber = "324234",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                    Doing = "Fulton Hogan crew are clearing debris, Survey crew setting up profiles.", PlantEquipment = "Loader and Dump truck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare site for Roading team.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now.AddDays(-1)
                },

                new Prestart
                {
                    Id = Guid.NewGuid().ToString(), ContractName = "Motorway", ContractNumber = "3202", Location = "Canterbury", LotNo = "50",
                    Department = "Civil", SiteId = "Ashburton Culvert", JobNumber = "444", SiteManager = "John Johnson", StmsNumber = "324234",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                    Doing = "Fulton Hogan crew are clearing debris, Survey crew setting up profiles.", PlantEquipment = "Loader and Dump truck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare site for Roading team.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now
                },

                new Prestart
                {
                    Id = Guid.NewGuid().ToString(), ContractName = "Cycleway", ContractNumber = "5656", Location = "Canterbury", LotNo = "50",
                    Department = "Civil", SiteId = "Richmond Cycleway", JobNumber = "777", SiteManager = "John Johnson", StmsNumber = "324234",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                    Doing = "Fulton Hogan crew are clearing debris, Survey crew setting up profiles.", PlantEquipment = "Loader and Dump truck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare site for Roading team.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now.AddDays(+1)
                },

                new Prestart
                {
                    Id = Guid.NewGuid().ToString(), ContractName = "Airport", ContractNumber = "8989", Location = "Canterbury", LotNo = "50",
                    Department = "Civil", SiteId = "Runway Repairs", JobNumber = "254", SiteManager = "John Johnson", StmsNumber = "324234",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                    Doing = "Fulton Hogan crew are clearing debris, Survey crew setting up profiles.", PlantEquipment = "Loader and Dump truck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare site for Roading team.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now.AddDays(+2)
                },

                new Prestart
                {
                    Id = Guid.NewGuid().ToString(), ContractName = "Motorway", ContractNumber = "3202", Location = "Canterbury", LotNo = "50",
                    Department = "Roading", SiteId = "Southern Overpass", JobNumber = "222", SiteManager = "Steve Smith", StmsNumber = "23454325",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                    Doing = "Road crew are preparing road surface, Survey crew setting up profiles.", PlantEquipment = "Grader and Dumptruck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare road for surfacing.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now.AddDays(-2)
                },

                new Prestart
                {
                   Id = Guid.NewGuid().ToString(), ContractName = "Motorway", ContractNumber = "3202", Location = "Canterbury", LotNo = "50",
                    Department = "Roading", SiteId = "Southern Overpass", JobNumber = "222", SiteManager = "Steve Smith", StmsNumber = "23454325",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                    Doing = "Road crew are preparing road surface.", PlantEquipment = "Grader and Dumptruck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare site for Roading team.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now.AddDays(-1)
                },

                new Prestart
                {
                   Id = Guid.NewGuid().ToString(), ContractName = "Motorway", ContractNumber = "3202", Location = "Canterbury", LotNo = "50",
                    Department = "Roading", SiteId = "Southern Overpass", JobNumber = "222", SiteManager = "Steve Smith", StmsNumber = "23454325",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                    Doing = "Road crew are preparing road surface.", PlantEquipment = "Grader and Dumptruck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare site for Roading team.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now
                },

                new Prestart
                {
                    Id = Guid.NewGuid().ToString(), ContractName = "Motorway", ContractNumber = "3202", Location = "Canterbury", LotNo = "50",
                    Department = "Roading", SiteId = "Southern Overpass", JobNumber = "222", SiteManager = "Steve Smith", StmsNumber = "23454325",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                    Doing = "Road crew are preparing road surface.", PlantEquipment = "Grader and Dumptruck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare site for Roading team.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now.AddDays(+1)
                },

                new Prestart
                {
                   Id = Guid.NewGuid().ToString(), ContractName = "Motorway", ContractNumber = "3202", Location = "Canterbury", LotNo = "50",
                    Department = "Roading", SiteId = "Southern Overpass", JobNumber = "222", SiteManager = "Steve Smith", StmsNumber = "23454325",
                    TmpNumber = "355325", SiteFirstAider = "Bill Jackson", CertificateNumber = "23423413241234", Plan = "Site Tidy Up",
                     Doing = "Road crew are preparing road surface.", PlantEquipment = "Grader and Dumptruck",
                    SpecialRequirements = "Traffic Management", HoldPoints = "n/a", QualityChecks = "n/a", Problems = "Heavy traffic caused delays for the public",
                    Differences = "Try to keep two lanes open for the public as much as possible.", MinimumProductivityRequirements = "Prepare site for Roading team.",
                    EmergencyPlan = "In case of emergency meet at site office.", FitForWork = true, SiteSecure = true, BarricadesRequired = true, SuitableAccess = true,
                    WeatherForecastConsidered = true, SpecialistPpeRequired = false, ErosionAndSedimentControlImplemented = true, DateCreated = DateTime.Now.AddDays(+2)
                }
            };

            foreach (var prestart in prestarts)
            {
                context.Set<Prestart>().Add(prestart);
                prestartIds.Add(prestart.Id);
            }
            
            List<Hazard> hazards = new List<Hazard>
            {
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[0], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[0], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[0], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[0], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[0], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[0], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[0], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[0], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},

                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[1], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[1], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[1], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[1], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[1], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[1], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[1], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[1], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},

                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[2], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[2], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[2], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[2], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[2], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[2], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[2], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[2], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},

                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[3], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[3], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[3], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[3], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[3], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[3], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[3], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[3], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},

                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[4], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[4], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[4], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[4], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[4], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[4], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[4], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[4], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},

                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[5], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[5], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[5], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[5], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[5], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[5], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[5], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[5], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},

                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[6], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[6], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[6], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[6], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[6], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[6], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[6], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[6], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},

                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[7], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[7], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[7], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[7], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[7], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[7], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[7], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[7], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},

                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[8], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[8], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[8], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[8], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[8], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[8], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[8], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[8], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},

                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[9], DateCreated = DateTime.Now.AddDays(-1), Task = "Working near Traffic & Pedestrians", Description = "Reversing Plant, Pedestrians", Repercussion = "Injury or Death", RiskBefore = "High", Response = "Work withing designated work area", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[9], DateCreated = DateTime.Now.AddDays(-1), Task = "Getting equipment to site", Description = "Towing Trailers", Repercussion = "Traffic accident", RiskBefore = "High", Response = "Load trailer correctly to ensure it is balanced and not over capacity", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[9], DateCreated = DateTime.Now.AddDays(-2), Task = "Site set up", Description = "Boxing", Repercussion = "Cuts, bruises", RiskBefore = "High", Response = "Competant staff", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[9], DateCreated = DateTime.Now.AddDays(-2), Task = "Surface Preparation", Description = "Spreading Gravel", Repercussion = "Tip over", RiskBefore = "High", Response = "Identify uneven ground", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[9], DateCreated = DateTime.Now.AddDays(-3), Task = "Delivery of asphalt", Description = "Hot boxes", Repercussion = "Personal injury", RiskBefore = "High", Response = "Workers are not permitted to enter a live lane, safety zone or taper", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[9], DateCreated = DateTime.Now.AddDays(-3), Task = "Tack Coating", Description = "Emulsion", Repercussion = "Run off into waterways", RiskBefore = "High", Response = "Weather checked before work starts", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[9], DateCreated = DateTime.Now.AddDays(-4), Task = "Asphalting (by hand)", Description = "Hot Material", Repercussion = "Burns", RiskBefore = "High", Response = "PPE including long trousers and gloves", RiskAfter = "low"},
                new Hazard {Id = Guid.NewGuid().ToString(), PrestartId = prestartIds[9], DateCreated = DateTime.Now.AddDays(-4), Task = "Operating Plant and Machinery", Description = "Noise", Repercussion = "Hearing loss", RiskBefore = "High", Response = "Wear hearing protection", RiskAfter = "low"},
            };

            foreach (var hazard in hazards)
            {
                context.Set<Hazard>().Add(hazard);
            }

            List<string> namesList = new List<string>
            {
                "Sylvester Treloar",
                "Adeline Carpentier",
                "Cordia Mcneel",
                "Evalyn Stiller",
                "Lilliana Bagg",
                "Lesha Coury",
                "Reginald Kofoed",
                "Angela Mcalpine",
                "Marg Pon",
                "Anitra Joynes",
                "Shondra Schall",
                "Philip Greenspan",
                "Otto Apple",
                "Chantay Junker",
                "Donnie Popp",
                "Stefanie Havener",
                "Ranee Kaler",
                "Tara Giddens"
            };
            List<string> employersList = new List<string>
            {
                "Fulton Hogan",
                "Stark Bros Ltd.",
                "NZTA",
                "Canterbury Surveying"
            };

            for (int i = 0; i < 100; i++)
            {
                context.Set<SignOn>().Add(new SignOn
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = namesList[new Random().Next(0,namesList.Count-1)], Employer = employersList[new Random().Next(0, employersList.Count-1)], PrestartId = prestartIds[new Random().Next(0, prestartIds.Count-1)],
                    DateCreated = DateTime.Now.AddDays(new Random().Next(-5, 5)), AgreeToTerms = true, Gloves = true, HardHat = true, HearingProtection = true, HiVis = true, SafetyBoots = true, SafetyGlasses = true
                });

                System.Threading.Thread.Sleep(50);
            }

            base.Seed(context);
        }
    }
}


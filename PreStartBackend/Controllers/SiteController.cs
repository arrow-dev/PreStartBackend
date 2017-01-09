using Microsoft.Azure.Mobile.Server;
using PreStartBackend.DataObjects;
using PreStartBackend.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Task = System.Threading.Tasks.Task;

namespace PreStartBackend.Controllers
{
    public class SiteController : TableController<Site>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Site>(context, Request);
        }

        // GET tables/Site
        public IQueryable<Site> GetAllSite()
        {
            return Query(); 
        }

        // GET tables/Site/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Site> GetSite(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Site/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Site> PatchSite(string id, Delta<Site> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Site
        public async Task<IHttpActionResult> PostSite(Site item)
        {
            Site current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Site/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteSite(string id)
        {
             return DeleteAsync(id);
        }
    }
}

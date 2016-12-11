using Microsoft.Azure.Mobile.Server;
using PreStartBackend.DataObjects;
using PreStartBackend.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace PreStartBackend.Controllers
{
    public class HazardController : TableController<Hazard>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Hazard>(context, Request, enableSoftDelete: true);
        }

        // GET tables/Hazard
        public IQueryable<Hazard> GetAllHazard()
        {
            return Query(); 
        }

        // GET tables/Hazard/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Hazard> GetHazard(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Hazard/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Hazard> PatchHazard(string id, Delta<Hazard> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Hazard
        public async Task<IHttpActionResult> PostHazard(Hazard item)
        {
            Hazard current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Hazard/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public System.Threading.Tasks.Task DeleteHazard(string id)
        {
             return DeleteAsync(id);
        }
    }
}

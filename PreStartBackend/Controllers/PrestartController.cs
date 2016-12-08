using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using PreStartBackend.DataObjects;
using PreStartBackend.Models;

namespace PreStartBackend.Controllers
{
    public class PrestartController : TableController<Prestart>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Prestart>(context, Request);
        }

        // GET tables/Prestart
        public IQueryable<Prestart> GetAllPrestart()
        {
            return Query(); 
        }

        // GET tables/Prestart/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Prestart> GetPrestart(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Prestart/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Prestart> PatchPrestart(string id, Delta<Prestart> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Prestart
        public async Task<IHttpActionResult> PostPrestart(Prestart item)
        {
            Prestart current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Prestart/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePrestart(string id)
        {
             return DeleteAsync(id);
        }
    }
}

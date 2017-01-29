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
    public class SignOnController : TableController<SignOn>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<SignOn>(context, Request);
        }

        // GET tables/SignOn
        public IQueryable<SignOn> GetAllSignOn()
        {
            return Query(); 
        }

        // GET tables/SignOn/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<SignOn> GetSignOn(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/SignOn/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<SignOn> PatchSignOn(string id, Delta<SignOn> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/SignOn
        public async Task<IHttpActionResult> PostSignOn(SignOn item)
        {
            SignOn current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/SignOn/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public System.Threading.Tasks.Task DeleteSignOn(string id)
        {
             return DeleteAsync(id);
        }
    }
}

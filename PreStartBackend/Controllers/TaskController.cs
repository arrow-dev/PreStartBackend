using Microsoft.Azure.Mobile.Server;
using PreStartBackend.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;

namespace PreStartBackend.Controllers
{
    public class TaskController : TableController<DataObjects.Task>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<DataObjects.Task>(context, Request, enableSoftDelete: true);
        }

        // GET tables/Task
        public IQueryable<DataObjects.Task> GetAllTask()
        {
            return Query(); 
        }

        // GET tables/Task/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<DataObjects.Task> GetTask(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Task/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<DataObjects.Task> PatchTask(string id, Delta<DataObjects.Task> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Task
        public async Task<IHttpActionResult> PostTask(DataObjects.Task item)
        {
            DataObjects.Task current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Task/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public System.Threading.Tasks.Task DeleteTask(string id)
        {
             return DeleteAsync(id);
        }
    }
}

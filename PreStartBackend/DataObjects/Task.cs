using Microsoft.Azure.Mobile.Server;
using System.Collections.ObjectModel;

namespace PreStartBackend.DataObjects
{
    public class Task: EntityData
    {
        public string Description { get; set; }
        public string SiteId { get; set; }
        public virtual Collection<Hazard> Hazards { get; set; }
    }
}
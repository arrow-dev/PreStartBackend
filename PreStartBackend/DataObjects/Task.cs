using Microsoft.Azure.Mobile.Server;
using System.Collections.ObjectModel;

namespace PreStartBackend.DataObjects
{
    public class Task: EntityData
    {
        public string TaskDescription { get; set; }

        public virtual Collection<Hazard> Hazards { get; set; }
    }
}
using Microsoft.Azure.Mobile.Server;

namespace PreStartBackend.DataObjects
{
    public class Hazard: EntityData
    {
        public string Description { get; set; }

        public string Repercussion { get; set; }

        public int RiskBefore { get; set; }

        public string Response { get; set; }

        public int RiskAfter { get; set; }

        public string TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}
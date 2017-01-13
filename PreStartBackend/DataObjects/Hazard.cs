using Microsoft.Azure.Mobile.Server;

namespace PreStartBackend.DataObjects
{
    public class Hazard: EntityData
    {
        public string Description { get; set; }

        public string Repercussion { get; set; }

        public string RiskBefore { get; set; }

        public string Response { get; set; }

        public string RiskAfter { get; set; }

        public string TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}
﻿using Microsoft.Azure.Mobile.Server;

namespace PreStartBackend.DataObjects
{
    public class Hazard: EntityData
    {
        public string Task { get; set; }

        public string Description { get; set; }

        public string Repercussion { get; set; }

        public string RiskBefore { get; set; }

        public string Response { get; set; }

        public string RiskAfter { get; set; }

        public string PrestartId { get; set; }

        public virtual Prestart Prestart { get; set; }
    }
}
using Microsoft.Azure.Mobile.Server;
using System;

namespace PreStartBackend.DataObjects
{
    public class SignOn : EntityData
    {
        public DateTime DateCreated { get; set; }

        public string Name { get; set; }
            
        public string Employer { get; set; }

        public bool HiVis { get; set; }

        public bool SafetyBoots { get; set; }

        public bool Gloves { get; set; }

        public bool HardHat { get; set; }

        public bool HearingProtection { get; set; }

        public bool SafetyGlasses { get; set; }

        public bool SiteInductionComplete { get; set; }

        public string InductionNumber { get; set; }

        public bool AgreeToTerms { get; set; }

        public byte[] Signature { get; set; }

        public string PrestartId { get; set; }

        public virtual Prestart Prestart { get; set; }
    }
}
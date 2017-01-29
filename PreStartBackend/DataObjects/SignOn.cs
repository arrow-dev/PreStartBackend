using Microsoft.Azure.Mobile.Server;
using System;

namespace PreStartBackend.DataObjects
{
    public class SignOn : EntityData
    {
        public String Name { get; set; }    
        public String Employer { get; set; }
        public bool HiVis { get; set; }
        public bool SafetyBoots { get; set; }
        public bool Gloves { get; set; }
        public bool HardHat { get; set; }
        public bool HearingProtection { get; set; }
        public bool SafetyGlasses { get; set; }
        public bool SiteInductionComplete { get; set; }
        public string InductionNumber { get; set; }
        public bool AgreeToTerms { get; set; }
    }
}
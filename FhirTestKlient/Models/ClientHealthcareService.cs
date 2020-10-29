using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhirTestKlient.Models
{
    public class ClientHealthcareService
    {
        public HealthcareService healthcareService{ get; set; }
        public ClientHealthcareService(HealthcareService _healthcareService)
        {
            healthcareService = _healthcareService;
        }
        public string GetIdentifierValue
        {
            get
            {
                Identifier id = healthcareService.Identifier.FirstOrDefault(x => x.Use == Identifier.IdentifierUse.Old);
                if (id != null) return id.Value;
                return "";
            }
        } 

        public string GetTelecom
        {
            get
            {
                string ret = "";
                List<ContactPoint> sortedlist = healthcareService.Telecom.OrderBy(x => x.Rank).ToList();

                foreach (var tel in sortedlist)
                {
                    if (ret != string.Empty) ret += ", ";
                    ret += tel.Use.ToString() + ": " + tel.Value;
                }
                return ret;

            }
        }
    }
}

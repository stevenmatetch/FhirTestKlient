using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhirTestKlient.Models
{
  public  class ClientPractionerRole
  {
        public PractitionerRole PractitionerRole { get; set; }
        public ClientPractionerRole(PractitionerRole _PractitionerRole)
        {
            PractitionerRole = _PractitionerRole;
        }
        public string GetIdentifierValue
        {
            get
            {
                Identifier id = PractitionerRole.Identifier.FirstOrDefault(x => x.Use == Identifier.IdentifierUse.Old);
                if (id != null) return id.Value;
                return "";
            }
        }
    }
}

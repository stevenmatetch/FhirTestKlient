using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhirTestKlient.Models
{
   public class ClientSlot
    {
        public Slot Slot { get; set; }
        public ClientSlot(Slot _Slot)
        {
            Slot = _Slot;
        }
        public string GetStartTime
        {
            get
            {
                return Slot.Start.GetValueOrDefault().ToString("yyyy-MM-dd   HH: mm:ss");

            }
        }
        public string GetEndTime
        {
            get
            {
                return Slot.End.GetValueOrDefault().ToString("yyyy-MM-dd   HH: mm:ss");

            }
        }
        public string GetIdentifierValue
        {
            get
            {
                Identifier id = Slot.Identifier.FirstOrDefault();
                if (id != null) return id.Value;
                return "";
            }
        }
        public string GetServiceType
        {
            get
            {
                CodeableConcept cc = Slot.ServiceType.FirstOrDefault();                
                
                if (cc != null) return cc.Text;
                return "";
            }
        }
    }
}

using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store.Preview.InstallControl;

namespace FhirTestKlient.Models
{
   public class ClientPatient
    {
       
        public Patient Patient { get; set; }

        public ClientPatient( Patient pat)
        {
            Patient = pat;

        }

        // Endanst för binding
        public string GetIdentifierValue
        {
            get

            {
              
                Identifier identifier = Patient.Identifier.FirstOrDefault();
                if (identifier != null) return identifier.Value;
                return "";
            }
        }
        // Endanst för binding
        public string GetOfficialName
        {
            get
            {
              
                HumanName humanname = Patient.Name.FirstOrDefault();
                return humanname.Text;


            }
        }
        // Endanst för binding
        public string GetTelecom
        {
            get
            {

                ContactPoint contactPoint = Patient.Telecom.FirstOrDefault();
                if (contactPoint != null) return contactPoint.Value;
                return "";

            }
        }
        // Endanst för binding
        public string GetAddress
        {
            get
            {
                Address address = Patient.Address.FirstOrDefault();
                //if (address == null) return "";

                return address.Text;

            }
        }

   }
}




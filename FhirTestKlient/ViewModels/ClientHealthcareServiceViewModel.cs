using FhirTestKlient.Models;
using Hl7.Fhir.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhirTestKlient.ViewModels
{
 public  class ClientHealthcareServiceViewModel
    {
        public ObservableCollection<ClientHealthcareService> healthcareServices { get; set; }
        public ClientHealthcareServiceViewModel()
        {
            healthcareServices = new ObservableCollection<ClientHealthcareService>();
            healthcareServices.Add(SkapaTestClientHealthcareService1());
            healthcareServices.Add(SkapaTestClientHealthcareService2());
        }
        public ClientHealthcareService SkapaTestClientHealthcareService1()
        {

             HealthcareService healthcareService = new HealthcareService();

            healthcareService.Identifier = new List<Identifier>();
            healthcareService.Identifier.Add(new Identifier() { Value = "xxx 50", Use = Identifier.IdentifierUse.Old });
            healthcareService.Identifier.Add(new Identifier() { Value = "xxx 40", Use = Identifier.IdentifierUse.Usual });
            healthcareService.Telecom = new List<ContactPoint>();
            healthcareService.Telecom.Add(new ContactPoint() {Value = "040 23 54 00", Use = ContactPoint.ContactPointUse.Mobile, Rank = 1 });
            healthcareService.Telecom.Add(new ContactPoint() {Value = "040 12 12 04",Use = ContactPoint.ContactPointUse.Home, Rank = 2 });
            healthcareService.Active = true;


            healthcareService.Name = "Stevens healthcareService ";
            return new ClientHealthcareService(healthcareService);

        }
        public ClientHealthcareService SkapaTestClientHealthcareService2()
        {

            HealthcareService healthcareService = new HealthcareService();

            healthcareService.Identifier = new List<Identifier>();
            healthcareService.Identifier.Add(new Identifier() { Value = "xxx", Use = Identifier.IdentifierUse.Old });
            healthcareService.Identifier.Add(new Identifier() { Value = "yyy", Use = Identifier.IdentifierUse.Usual });
            healthcareService.Telecom = new List<ContactPoint>();
            healthcareService.Telecom.Add(new ContactPoint() {  Value = "040 23 55 56",Use = ContactPoint.ContactPointUse.Mobile, Rank = 1 });
            healthcareService.Telecom.Add(new ContactPoint() { Value = "040 86 45 23", Use = ContactPoint.ContactPointUse.Home, Rank = 2 });
            healthcareService.Active = true;
            healthcareService.Name = "Tims healthcareService ";
            return new ClientHealthcareService(healthcareService);

        }
        public string GetJSONHealthcareService

        {
            get
            {

                string jsonString;
                jsonString = JsonConvert.SerializeObject(healthcareServices);

                return jsonString;

            }

        }
    }
}

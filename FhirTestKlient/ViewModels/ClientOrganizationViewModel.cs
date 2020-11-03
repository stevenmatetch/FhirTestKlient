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
  
   public   class ClientOrganizationViewModel
   {
        public ObservableCollection<ClientOrganization> organizations { get; set; }

        public ClientOrganizationViewModel()
        {
            organizations = new ObservableCollection<ClientOrganization>();
            organizations.Add(SkapaTestOrganization1());
            organizations.Add(SkapaTestOrganization2());
        }
        public ClientOrganization SkapaTestOrganization1()
        {

            Organization organization = new Organization();
            organization.Identifier = new List<Identifier>();
            organization.Identifier.Add(new Identifier() {Value = "xxx 20" ,Use = Identifier.IdentifierUse.Old});
            organization.Identifier.Add(new Identifier() {Value = "xxx 30", Use = Identifier.IdentifierUse.Usual });
            organization.Telecom = new List<ContactPoint>();
            organization.Telecom.Add(new ContactPoint() {Value = "040 98 76 34", Use = ContactPoint.ContactPointUse.Mobile, Rank = 1});
            organization.Telecom.Add(new ContactPoint() { Value = "040 23 76 56", Use = ContactPoint.ContactPointUse.Home, Rank = 2 });
            organization.Active = true;
            organization.Name = "Folktandvården skåne";
            return new ClientOrganization(organization);
        
        }
        public ClientOrganization SkapaTestOrganization2()
        {

            Organization organization = new Organization();
            organization.Identifier = new List<Identifier>();
            organization.Identifier.Add(new Identifier() { Value = "xxx 50", Use = Identifier.IdentifierUse.Old });
            organization.Identifier.Add(new Identifier() { Value = "xxx 40", Use = Identifier.IdentifierUse.Usual });
            organization.Telecom = new List<ContactPoint>();
            organization.Telecom.Add(new ContactPoint() { Value = "040 67 34 21", Use = ContactPoint.ContactPointUse.Mobile, Rank = 1 });
            organization.Telecom.Add(new ContactPoint() { Value = "040 90 56 23", Use = ContactPoint.ContactPointUse.Home, Rank = 2 });
            organization.Active = true;
            organization.Name = "Rönneholms Tandvård AB";
            return new ClientOrganization(organization);

        }
        public string GetJSONOrganization
        {
            get
            {

                string jsonString;
                jsonString = JsonConvert.SerializeObject(organizations);

                return jsonString;

            }
        }


   }
}

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
  public class ClientPractionerRoleViewModel
    {
        public ObservableCollection<ClientPractionerRole> practionerRoles { get; set; }

        public ClientPractionerRoleViewModel()
        {
            practionerRoles = new ObservableCollection<ClientPractionerRole>();
            practionerRoles.Add(SkapaTestPractionRole1());
            practionerRoles.Add(SkapaTestPractionRole2());
        }
        public ClientPractionerRole SkapaTestPractionRole1()
        {

            PractitionerRole practionerRole = new PractitionerRole();


            practionerRole.Identifier = new List<Identifier>();
            practionerRole.Identifier.Add(new Identifier() { Value = "practionerRole 1", Use = Identifier.IdentifierUse.Old });
            practionerRole.Identifier.Add(new Identifier() { Value = "practionerRole 2", Use = Identifier.IdentifierUse.Usual });
            practionerRole.Active = true;



            return new ClientPractionerRole(practionerRole);

        }
        public ClientPractionerRole SkapaTestPractionRole2()
        {

            PractitionerRole practionerRole = new PractitionerRole();


            practionerRole.Identifier = new List<Identifier>();
            practionerRole.Identifier.Add(new Identifier() { Value = "practionerRole 3", Use = Identifier.IdentifierUse.Old });
            practionerRole.Identifier.Add(new Identifier() { Value = "practionerRole 4", Use = Identifier.IdentifierUse.Usual });
            practionerRole.Active = true;

            return new ClientPractionerRole(practionerRole);

        }
        public string GetJSONPractionerRole

        {
            get
            {

                string jsonString;
                jsonString = JsonConvert.SerializeObject(practionerRoles);

                return jsonString;

            }

        }

    }
}


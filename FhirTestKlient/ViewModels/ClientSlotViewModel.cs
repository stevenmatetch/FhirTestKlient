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
   public class ClientSlotViewModel
    {
        public ObservableCollection<ClientSlot> slots { get; set; }

        public ClientSlotViewModel()
        {
            slots = new ObservableCollection<ClientSlot>();
            slots.Add(SkapaTestSlot1());
            slots.Add(SkapaTestSlot2());
        }
        public ClientSlot SkapaTestSlot1()
        {

            Slot slot = new Slot();

            slot.Identifier = new List<Identifier>();
            slot.Identifier.Add(new Identifier() { Value = "slot1", Use = Identifier.IdentifierUse.Old });
            slot.Identifier.Add(new Identifier() { Value = "slot2", Use = Identifier.IdentifierUse.Usual });
            slot.Start = DateTimeOffset.Now;
            slot.End = DateTimeOffset.Now.AddDays(3);
            slot.Status = Slot.SlotStatus.Free;
            slot.Schedule = new ResourceReference();
            slot.Schedule.Reference = "Reference 1";

            /* Todo Skapa Schedule och skicka med */
            Schedule schedule = new Schedule();
            schedule.Active = true;
            schedule.Comment = "Inga kommentarer...";
            
            return new ClientSlot(slot);

        }
        public ClientSlot SkapaTestSlot2()
        {

            Slot slot = new Slot();

            slot.Identifier = new List<Identifier>();
            slot.Identifier.Add(new Identifier() { Value = "slot 1", Use = Identifier.IdentifierUse.Old });
            slot.Identifier.Add(new Identifier() { Value = "slot 2", Use = Identifier.IdentifierUse.Usual });
            slot.Start = DateTimeOffset.Now;
            slot.End = DateTimeOffset.Now.AddDays(9);
            slot.Status = Slot.SlotStatus.Free;
            slot.Schedule = new ResourceReference();
            slot.Schedule.Reference = "Reference 2";

            /* Todo Skapa Schedule och skicka med */
            Schedule schedule = new Schedule();
            schedule.Active = true;
            schedule.Comment = "Massa kommentarer...";

            return new ClientSlot(slot);

        }
        public string GetJSONSlot

        {
            get
            {
                string jsonString;
                jsonString = JsonConvert.SerializeObject(slots);
                return jsonString;

            }

        }
    }
}

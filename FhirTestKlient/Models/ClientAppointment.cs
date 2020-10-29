using Hl7.Fhir.Model;
using Hl7.Fhir.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FhirTestKlient.Models
{
   public class ClientAppointment
    {
        public Appointment Appointment { get; set; }
        public Appointment SelectedAppointment { get; set; }
        public List<string> Statuses { get; set; }
        public string GetIdentifierValue
        {
            get
            {
                Identifier id = Appointment.Identifier.FirstOrDefault();
                if (id != null) return id.Value;
                return "";
            }
        }
        public string GetStartTime
        {
            get
            {
                return Appointment.Start.GetValueOrDefault().ToString("yyyy-MM-dd   HH: mm:ss");

            }
        }
        public string GetEndTime
        {
            get
            {
                return Appointment.End.GetValueOrDefault().ToString("yyyy-MM-dd   HH: mm:ss");

            }
        }
        
        public ClientAppointment(Appointment app)
        {
            Appointment = app;

            //Statuses = new List<string>()
            //{ "Proposed", "Pending", "Booked", "Arrived", "Fulfilled", "CheckedIn", "Waitlist", "Noshow", "EnteredInError" };

        }
        public ClientAppointment()
        {
            
        }

    }
}

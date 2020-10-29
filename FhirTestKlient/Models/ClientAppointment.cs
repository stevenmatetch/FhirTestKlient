using FhirTestKlient.Services;
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
     
        public List<string> Statuses { get; set; }


        public TimeSpan PutEndTime
        {
            get
            {
                return PutEndDate - PutEndDate.Date;

            }
            set
            {
                DateTime nyttdatum = PutEndDate.Date.Add(value);
            }
        }
        public TimeSpan PutStartTime
        {
            get
            {
                return PutStartDate - PutStartDate.Date;

            }
            set
            {
                DateTime nyttdatum = PutStartDate.Date.Add(value);
            }
        }
        public DateTimeOffset PutStartDate
        {
            get
            {
                return Appointment.Start.GetValueOrDefault();

            }
            set
            {
                //DateTimeOffset nyttdatum = Appointment.Start.GetValueOrDefault().AddDays(value);
            }
        }
        public DateTimeOffset PutEndDate
        {
            get
            {
                return Appointment.End.GetValueOrDefault();

            }
            set
            {

            }
        }
        public string PutIdentifierValue
        {
            get
            {
                Identifier id = Appointment.Identifier.FirstOrDefault();
                if (id != null) return id.Value;
                return "";
            }
            set
            {
                
            }
        }
        public string GetStartTime
        {
            get
            {
                return Appointment.Start.GetValueOrDefault().ToString("yyyy-MM-dd   HH: mm:ss");

            }
            set
            {
                
            }
        }
        public string GetEndTime
        {
            get
            {
                return Appointment.End.GetValueOrDefault().ToString("yyyy-MM-dd   HH: mm:ss");

            }
            set
            {

            }
        }
        public string GetIdentifierValue
        {
            get
            {
                Identifier id = Appointment.Identifier.FirstOrDefault();
                if (id != null) return id.Value;
                return "";
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

using FhirTestKlient.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.StartScreen;


namespace FhirTestKlient.ViewModels
{
    public class ClientAppointmentViewModel
    {
        public ObservableCollection<ClientAppointment> appointments { get; set; }

        public Appointment SelectedAppointment { get; set; }
        public List<string> Statuss { get; set; }
        public Appointment Appointment { get; set; }
        public ClientAppointmentViewModel()
        {
            appointments = new ObservableCollection<ClientAppointment>();

            //appointments.Add(SkapaTestAppointment1());
            //appointments.Add(SkapaTestAppointment2());
            //appointments.Add(SkapaTestAppointment3());

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

        public string GetJSONappointments
        {
            get
            {
                var serializer = new FhirJsonSerializer();

                string text;

                Bundle newBund = new Bundle();

                newBund.Entry = new List<Bundle.EntryComponent>();

                foreach (var app in appointments)
                {
                    Bundle.EntryComponent comp = new Bundle.EntryComponent();
                    comp.Resource = app.Appointment;

                    newBund.Entry.Add(comp);

                }

                text = serializer.SerializeToString(newBund);

               return text;

            }

        }
    
    }

        //public ClientAppointment SkapaTestAppointment1()
        //{

        //    Appointment appointment = new Appointment();

        //    appointment.Identifier = new List<Identifier>();
        //    appointment.Identifier.Add(new Identifier() { Value = "EgetId 20", Use = Identifier.IdentifierUse.Secondary });
        //    appointment.Identifier.Add(new Identifier() { Value = "SchSNr 10", Use = Identifier.IdentifierUse.Official });
        //    appointment.Comment = "Dra ut en tand";
        //    appointment.Start = DateTimeOffset.Now;
        //    appointment.End = DateTime.Parse("2020/01/20 07:22:16");
        //    appointment.Status = Appointment.AppointmentStatus.Booked;

        //    return new ClientAppointment(appointment);
        //}
        //public ClientAppointment SkapaTestAppointment2()
        //{

        //    Appointment appointment = new Appointment();

        //    appointment.Identifier = new List<Identifier>();
        //    appointment.Identifier.Add(new Identifier() { Value = "EgetId 55", Use = Identifier.IdentifierUse.Secondary });
        //    appointment.Identifier.Add(new Identifier() { Value = "SchSNr 99", Use = Identifier.IdentifierUse.Official });
        //    appointment.Comment = "Peta på tandköttet";
        //    appointment.Start = DateTimeOffset.Now;
        //    appointment.End = DateTimeOffset.Parse("2020/01/06 07:22:16");
        //    appointment.Status = Appointment.AppointmentStatus.Arrived;

        //    return new ClientAppointment(appointment);
        //}
        //public ClientAppointment SkapaTestAppointment3()
        //{

        //    Appointment appointment = new Appointment();

        //    appointment.Identifier = new List<Identifier>();
        //    appointment.Identifier.Add(new Identifier() { Value = "EgetId 2", Use = Identifier.IdentifierUse.Secondary });
        //    appointment.Identifier.Add(new Identifier() { Value = "SchSNr 555", Use = Identifier.IdentifierUse.Official });
        //    appointment.Comment = "Betala räkning";
        //    appointment.Start = DateTime.Now.AddMonths(4);
        //    appointment.Start = DateTimeOffset.Now;
        //    appointment.End = DateTime.Parse("2020/07/22 07:22:16");
        //    appointment.Status = Appointment.AppointmentStatus.Cancelled;

        //    return new ClientAppointment(appointment);
        //}
        //    public string GetJSONAppointment

        //    {
        //        get
        //        {

        //            string jsonString;
        //            jsonString = JsonConvert.SerializeObject(appointments);

        //            return jsonString;

        //        }


        //    }
        //}
    
}


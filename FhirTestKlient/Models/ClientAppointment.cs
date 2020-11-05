using FhirTestKlient.Services;
using Hl7.Fhir.FhirPath;
using Hl7.Fhir.Model;
using Hl7.Fhir.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments;
using Windows.UI.Xaml.Controls;
using static Hl7.Fhir.Model.Appointment;

namespace FhirTestKlient.Models
{
   public class ClientAppointment
    {
        public Hl7.Fhir.Model.Appointment Appointment { get; set; }
     
        public List<string> Statuses { get; set; }

        public string PutStatus
        {
            get
            {
                return Appointment.Status.ToString();
            }
            set
            {
                Appointment.Status = GetAppointmentStatus(value);
            }
        }

        public TimeSpan PutEndTime
        {
            get
            {
                DateTime today = new DateTime().AddMinutes(15);
                try
                {
                    return PutEndDate - PutEndDate.Date;
                }
                catch (Exception)
                {

                }
                return today.TimeOfDay;

            }
            set
            {
                Appointment.End = Appointment.End.Value.Date.Add(value);
            }
        }
       
        public TimeSpan PutStartTime
        {
            
            get
            {
                DateTime today = new DateTime();
                try
                {
                    return PutStartDate - PutStartDate.Date;
                }
                catch(Exception)
                {

                }
                return today.TimeOfDay;

            }
            set
            {
                Appointment.Start = Appointment.Start.Value.Date.Add(value);
            }
        }
        
        public DateTimeOffset PutStartDate
        {
           
            get
            {
                try
                {
                    DateTime today = new DateTime();
                    if (Appointment.Start == null)
                    {
                        return today.Date;
                    }
                   
                }
                catch (Exception)
                {
                   
                }

                return Appointment.Start.GetValueOrDefault();

            }
            set
            {

                Appointment.Start = value;
            }
        }
        public DateTimeOffset PutEndDate
        {
           
            get
            {

                try
                {
                    DateTimeOffset today = new DateTimeOffset();
                    if (Appointment.End == null)
                    {
                        return today.Date;
                    }

                }
                catch (Exception)
                {

                }

                return Appointment.End.GetValueOrDefault();

            }
            set
            {
                Appointment.End = value;
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
                //Appointment.Identifier = Appointment.Identifier.Select(x => { x.Value = value; return x; }).ToList();
               
            }
        }
        public string PutComment
        {
            get
            {
               return Appointment.Comment;
            }
            set
            {
                Appointment.Comment = value;
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

        public ClientAppointment(Hl7.Fhir.Model.Appointment app)
        {
            Appointment = app;

            //Statuses = new List<string>()
            //{ "Proposed", "Pending", "Booked", "Arrived", "Fulfilled", "CheckedIn", "Waitlist", "Noshow", "EnteredInError" };

        }
        public ClientAppointment()
        {
            
        }

        public static AppointmentStatus? GetAppointmentStatus(string status)
        {
            switch (status.ToLower())
            {
                case "booked": return AppointmentStatus.Booked;
                case "checkedin": return AppointmentStatus.CheckedIn;
                case "pending": return AppointmentStatus.Pending;
                case "proposed": return AppointmentStatus.Proposed;
                case "fulfilled": return AppointmentStatus.Fulfilled;
                case "noshow": return AppointmentStatus.Noshow;
                //case 50: return AppointmentStatus.;
                case "cancelled": return AppointmentStatus.Cancelled;
                case "waitlist": return AppointmentStatus.Waitlist;
                default: return AppointmentStatus.EnteredInError;
            }
        }

    }
}

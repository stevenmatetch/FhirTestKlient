﻿using FhirTestKlient.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace FhirTestKlient.Services

{
    public class APIServices
    {
        static HttpClient httpClient = new HttpClient();
        private static string BaseUrl = "https://localhost:44345/api";
        private static string GetAllPatientsUrl = "https://localhost:44345/api/Patient";
        private static string AppointmentsUrl = "https://localhost:44345/api/Appointment";
        private static string SlotsUrl = "https://localhost:44345/api/Slot";
        private static string ScheduleUrl = "https://localhost:44345/api/Schedule";

        /// <summary>
        /// Hämtar en Patient från FHIR-servern
        /// </summary>
        /// <param name="pnr">Patienten personnummer (id)</param>
        /// <returns>HL7.Fhir.Model.Patient</returns>
        public async Task<Patient> GetPatientAsync(string pnr)
        {
            var jsonPatient = await httpClient.GetStringAsync(BaseUrl + "/Patient/" + pnr); 

            FhirJsonParser fjp = new FhirJsonParser();
            Resource res = fjp.Parse<Resource>(jsonPatient);

            return res as Patient;

        }

        /// <summary>
        /// Hämtar alla patienter från FHIR-servern
        /// </summary>
        /// <returns>ObservableCollection<ClientPatient></returns>
        public async Task<ObservableCollection<ClientPatient>> GetAllPatientAsync()
        {

            var jsonGetAllPatients = await httpClient.GetStringAsync(GetAllPatientsUrl);

            ObservableCollection<ClientPatient> retVal = new ObservableCollection<ClientPatient>();

            FhirJsonParser fjp = new FhirJsonParser();
            Bundle bund = fjp.Parse<Bundle>(jsonGetAllPatients);
            if (null != bund)
            {
                foreach (var entry in bund.Entry)
                {

                    ClientPatient newPat = new ClientPatient(entry.Resource as Patient);
                    retVal.Add(newPat);
                }
            }
            return retVal;

        }
        public async Task<Appointment> GetAppointment(string patientPnr)
        {
            var jsonAppointment = await httpClient.GetStringAsync(BaseUrl + "/Appointment/" + patientPnr);

            FhirJsonParser fjp = new FhirJsonParser();
            Resource res = fjp.Parse<Resource>(jsonAppointment);

            return res as Appointment;

        }
        /// <summary>
        /// Hämtar alla bokningar från FHIR-servern
        /// </summary>
        /// <returns><ObservableCollection<ClientAppointment></returns>
        public async Task<ObservableCollection<ClientAppointment>> GetAllAppointmentAsync()
        {

            var jsonGetAllAppointments = await httpClient.GetStringAsync(AppointmentsUrl);

            ObservableCollection<ClientAppointment> retVal = new ObservableCollection<ClientAppointment>();

            FhirJsonParser fjp = new FhirJsonParser();
            Bundle bund = fjp.Parse<Bundle>(jsonGetAllAppointments);

            if (null != bund)
            {
                foreach (var entry in bund.Entry)
                {

                    ClientAppointment newApp = new ClientAppointment(entry.Resource as Appointment);
                    retVal.Add(newApp);
                }

            }
            return retVal;

        }
        /// <summary>
        /// Lägger till en bokning i FHIR-servern
        /// </summary>
        /// <param name="app"></param>
        /// <returns>Appointment</returns>
        public async Task<Appointment> PostAppointmentAsync(ClientAppointment app)
        {
            using (HttpClient client = new HttpClient())
            {
           
                var serializer = new FhirJsonSerializer();

                var JsonAppointment  = serializer.SerializeToString(app.Appointment);

                //var appointment = JsonConvert.SerializeObject(app);
                HttpContent httpContent = new StringContent(JsonAppointment);

                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync(AppointmentsUrl, httpContent);

                string p = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Appointment>(p);
            }

        }
        /// <summary>
        /// Ändrar en bokning i FHIR-servern
        /// </summary>
        /// <param name="app"></param>
        /// <returns>Appointment</returns>
        public async Task<Appointment> PutAppointmentAsync(ClientAppointment app)
        {
            using (HttpClient client = new HttpClient())
            {
                var serializer = new FhirJsonSerializer();

                var JsonAppointment = serializer.SerializeToString(app.Appointment);

                //var appointment = JsonConvert.SerializeObject(app);
                HttpContent httpContent = new StringContent(JsonAppointment);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PutAsync(AppointmentsUrl + "/" + app.Appointment.Id.ToString(), httpContent); 

                string p = await result.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Appointment>(p);
            }

        }
        public async Task<ObservableCollection<ClientSlot>> GetAllSlotsAsync()
        {

            var jsonGetAllSlots = await httpClient.GetStringAsync(SlotsUrl);

            ObservableCollection<ClientSlot> retVal = new ObservableCollection<ClientSlot>();

            FhirJsonParser fjp = new FhirJsonParser();
            Bundle bund = fjp.Parse<Bundle>(jsonGetAllSlots);
            if (null != bund)
            {
                foreach (var entry in bund.Entry)
                {

                    ClientSlot newSlot = new ClientSlot(entry.Resource as Slot);
                    retVal.Add(newSlot);
                }
            }
            return retVal;

        }
        public async Task<ObservableCollection<ClientSchedule>> GetAllScheduleAsync()
        {

            var jsonGetAllSchedules = await httpClient.GetStringAsync(ScheduleUrl);

            ObservableCollection<ClientSchedule> retVal = new ObservableCollection<ClientSchedule>();

            FhirJsonParser fjp = new FhirJsonParser();
            Bundle bund = fjp.Parse<Bundle>(jsonGetAllSchedules);

            if (null != bund)
            {
                foreach (var entry in bund.Entry)
                {

                    ClientSchedule newSch = new ClientSchedule(entry.Resource as Schedule);
                    retVal.Add(newSch);
                }

            }
            return retVal;

        }
    }
}
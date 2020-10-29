using FhirTestKlient.Models;
using FhirTestKlient.ViewModels;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.FhirPath.Sprache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace FhirTestKlient.Services

{
    public class APIServices
    {
        static HttpClient httpClient = new HttpClient();
        private static string BaseUrl = "https://localhost:44345/api";
        private static string GetAllPatientsUrl = "https://localhost:44345/api/Patient";
        private static string AppointmentsUrl = "https://localhost:44345/api/Appointment";

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

                    ClientAppointment newPat = new ClientAppointment(entry.Resource as Appointment);
                    retVal.Add(newPat);
                }
            }
            return retVal;

        }
        public async Task<Appointment> PostAppointmentAsync(Appointment app)
        {
            using (HttpClient client = new HttpClient())
            {
           
                var serializer = new FhirJsonSerializer();


                var JsonAppointment  = serializer.SerializeToString(app);

                //var appointment = JsonConvert.SerializeObject(app);
                HttpContent httpContent = new StringContent(JsonAppointment);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync(AppointmentsUrl, httpContent);

                string p = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Appointment>(p);
            }

        }
        public async Task<Appointment> PutAppointmentAsync(Appointment app)
        {
            using (HttpClient client = new HttpClient())
            {
                var serializer = new FhirJsonSerializer();

                var JsonAppointment = serializer.SerializeToString(app);

                //var appointment = JsonConvert.SerializeObject(app);
                HttpContent httpContent = new StringContent(JsonAppointment);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PutAsync(AppointmentsUrl + "/" + app.Id.ToString(), httpContent);

                string p = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Appointment>(p);
            }

        }
    }
}
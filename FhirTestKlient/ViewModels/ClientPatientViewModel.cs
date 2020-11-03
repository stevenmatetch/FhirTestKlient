using FhirTestKlient.Models;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FhirTestKlient.ViewModels
{
    public class ClientPatientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ClientPatient> _patients;
        public ObservableCollection<ClientPatient> Patients
        {
            get
            {
                return _patients;
            }
            set
            {
                _patients = value;
                NotifyPropertyChanged("GetJSONPatient");

            }
        }

        public Patient _patient { get; set; }

        public Patient Patient 
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                NotifyPropertyChanged("Patient");
                NotifyPropertyChanged("GetOfficialName");
                NotifyPropertyChanged("GetIdentifierValue");
                NotifyPropertyChanged("GetAddress");
                NotifyPropertyChanged("GetTelecom");
                NotifyPropertyChanged("GetJSONPatient");
            }
        }
        
        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }

        }

        public ClientPatientViewModel( )
        {
            Patients = new ObservableCollection<ClientPatient>();
            Patient = new Patient();
        
        }
       
        // endast för binding
        public string GetIdentifierValue
        {
            get

            {
              
                Identifier identifier = Patient.Identifier.FirstOrDefault();
                if (identifier != null) return identifier.Value;
                return "";
            }
        }
        // endast för binding
        public string GetOfficialName
        {
            get
            {

                HumanName humanname = Patient.Name.FirstOrDefault();
                if (humanname == null) return "";
                return humanname.Text;
            }
        }
        // endast för binding
        public string GetAddress
        {
            get
            {

                Address address = Patient.Address.FirstOrDefault();
                if (address == null) return "";
                return address.Text;

            }
        }
        // endast för binding
        public string GetTelecom
        {
            get
            {
                ContactPoint contactPoint = Patient.Telecom.FirstOrDefault();
                if (contactPoint != null) return contactPoint.Value;

                return"";


            }
        }
        // endast för binding
        public string GetJSONPatient
        {

            get
            {
                var serializer = new FhirJsonSerializer();
          
                string text;
                if (Patient.ResourceBase != null)
                {
                    // en patient
                    text = serializer.SerializeToString(Patient);
                } else
                {
                    // ta listan istället
                    Bundle newBund = new Bundle();
                    newBund.Entry = new List<Bundle.EntryComponent>();
                    foreach (var pat in Patients)
                    {
                        Bundle.EntryComponent comp = new Bundle.EntryComponent();
                        comp.Resource = pat.Patient;

                        newBund.Entry.Add(comp);
                    }
                    text = serializer.SerializeToString(newBund);

                }

                return text;

            }

        }

    }
  
}
    //public static Patient SkapaTestPatient()
    //{
    //    Patient pat = new Patient();


    //    pat.Identifier = new List<Identifier>();
    //    Identifier newIdentifier = new Identifier();
    //    newIdentifier.Value = "5";
    //    pat.Identifier.Add(newIdentifier);

    //    pat.Name = new List<HumanName>();
    //    HumanName newName = new HumanName();
    //    newName.Text = "Steven Matetcho";
    //    newName.Use = HumanName.NameUse.Official;
    //    pat.Name.Add(newName);
    //    newName = new HumanName();
    //    newName.Text = "Steve";
    //    newName.Use = HumanName.NameUse.Nickname;
    //    pat.Name.Add(newName);

    //    pat.Telecom = new List<ContactPoint>();
    //    ContactPoint newContact = new ContactPoint();
    //    newContact.Value = "040 - 11 22 33";
    //    newContact.Use = ContactPoint.ContactPointUse.Work;
    //    newContact.Rank = 2;
    //    pat.Telecom.Add(newContact);

    //    newContact = new ContactPoint();
    //    newContact.Value = "076 - 45 45 46";
    //    newContact.Use = ContactPoint.ContactPointUse.Home;
    //    newContact.Rank = 1;
    //    pat.Telecom.Add(newContact);

    //    pat.Gender = AdministrativeGender.Male;

    //    pat.BirthDate = "06/05/1996";

    //    pat.Active = true;

    //    return pat;



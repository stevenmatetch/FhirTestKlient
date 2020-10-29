using FhirTestKlient.Models;
using FhirTestKlient.Services;
using FhirTestKlient.ViewModels;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FhirTestKlient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        //public ClientPatientViewModel clientPatientViewModel { get; set; }
        public APIServices aPIServices{ get; set; }
        private ClientPatientViewModel ClientPatientViewModel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> pnr { get; set; }

  
        public ClientPatientViewModel UpdateClientPatientViewModel
        {
            get
            {
                return ClientPatientViewModel;
            }
            set
            {
                ClientPatientViewModel = value;
                NotifyPropertyChanged("UpdateClientPatientViewModel");
              
            }

        }
        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }

        }


        public MainPage()
        {

            aPIServices = new APIServices();
            pnr = new List<string>() { "191212121212", "191111111111", "190101010101", "201212121212" };
            ClientPatientViewModel = new ClientPatientViewModel();
            ClientPatientViewModel.Patients = new ObservableCollection<ClientPatient>();
            this.InitializeComponent();
            BackButton.Visibility = Visibility.Collapsed;
            GetAllPatients();

            //Patient pat = new Patient();

            //pat.Identifier = new List<Identifier>();
            //Identifier newIdentifier = new Identifier();
            //newIdentifier.Value = "5";
            //pat.Identifier.Add(newIdentifier);

            //pat.Name = new List<HumanName>();
            //HumanName newName = new HumanName();
            //newName.Text = "Steven Matetcho";
            //newName.Use = HumanName.NameUse.Official;
            //pat.Name.Add(newName);
            //newName = new HumanName();
            //newName.Text = "Steve";
            //newName.Use = HumanName.NameUse.Nickname;
            //pat.Name.Add(newName);

            //pat.Telecom = new List<ContactPoint>();
            //ContactPoint newContact = new ContactPoint();
            //newContact.Value = "040 - 11 22 33";
            //newContact.Use = ContactPoint.ContactPointUse.Work;
            //newContact.Rank = 2;
            //pat.Telecom.Add(newContact);

            //newContact = new ContactPoint();
            //newContact.Value = "076 - 45 45 46";
            //newContact.Use = ContactPoint.ContactPointUse.Home;
            //newContact.Rank = 1;
            //pat.Telecom.Add(newContact);

            //pat.Gender = AdministrativeGender.Male;

            //pat.BirthDate = "06/05/1996";

            //pat.Active = true;

            //ClientPatientViewModel.Patient = pat;

            // ClientPatientViewModell = new ClientPatientViewModel();

        }
        public async void GetAllPatients()
        {
            UpdateClientPatientViewModel.Patients = await aPIServices.GetAllPatientAsync();
            listAllPatient.ItemsSource = ClientPatientViewModel.Patients;
        }

        private void OpenSplitview_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentPage));
            if (ForwardButton.IsPressed)
            {
                BackButton.Visibility = Visibility.Visible;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string selectprn = pnrCombobox.SelectedItem.ToString();
            UpdateClientPatientViewModel.Patient = await aPIServices.GetPatientAsync(selectprn);

            //Patient pat = new Patient();
            //pat.Identifier = new List<Identifier>();
            //pat.Identifier.Add(new Identifier() { Value = selectprn.ToString() });
            ////ClientPatientViewModel newModel = new ClientPatientViewModel();xxx
            ////newModel.Patient = await aPIServices.GetPatientAsync(pat);xxxx
            // alla patienter
            //ClientPatientViewModel.Patients = await aPIServices.GetAllPatientAsync();
            //listAllPatient.ItemsSource = ClientPatientViewModel.Patients;


        }
    }
}

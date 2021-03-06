﻿using FhirTestKlient.ViewModels;
using System;
using System.Collections.Generic;
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
using Hl7.Fhir.Model;
using FhirTestKlient._View;
using FhirTestKlient.Services;
using System.ComponentModel;
using System.Collections.ObjectModel;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FhirTestKlient.Models
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppointmentPage : Page
    {
        public ClientAppointmentViewModel clientappointmentViewModel;
        public APIServices aPIServices;
        public ClientAppointment selectedAppointemnt { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public AppointmentPage()
        {
            aPIServices = new APIServices();
            clientappointmentViewModel = new ClientAppointmentViewModel();
            clientappointmentViewModel.appointments = new ObservableCollection<ClientAppointment>();

            this.InitializeComponent();
            GetAllAppointments();

        }
        public ClientAppointmentViewModel UpdateClientAppointmentViewModel
        {
            get
            {
                return clientappointmentViewModel;
            }
            set
            {
                clientappointmentViewModel = value;
                NotifyPropertyChanged("UpdateClientAppointmentViewModel");

            }

        }
        private void NotifyPropertyChanged(string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }

        }

        public async void GetAllAppointments()
        {
            UpdateClientAppointmentViewModel.appointments = await aPIServices.GetAllAppointmentAsync();
            appointmentListview.ItemsSource = await aPIServices.GetAllAppointmentAsync();

           

        } //clientappointmentViewModel.appointments = await aPIServices.GetAllAppointmentAsync();

            //listAllPatient.ItemsSource = ClientPatientViewModel.Patients;
      

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SlotPage));
        

        }

        private void OpenSplitview_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
           

        }

    
        private async void Registrera_Click(object sender, RoutedEventArgs e)
        {
            PostAndPutAppointmentDialog c = new PostAndPutAppointmentDialog();
            var res = await c.ShowAsync();
            GetAllAppointments();

        }

        private async void Editera_Click(object sender, RoutedEventArgs e)
        {
            PostAndPutAppointmentDialog c = new PostAndPutAppointmentDialog(selectedAppointemnt);
            var res = await c.ShowAsync();

            GetAllAppointments();


        }
    }

}

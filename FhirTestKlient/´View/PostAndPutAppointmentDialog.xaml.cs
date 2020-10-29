using FhirTestKlient.Models;
using FhirTestKlient.Services;
using FhirTestKlient.ViewModels;
using Hl7.Fhir.Model;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FhirTestKlient._View
{
    public sealed partial class PostAndPutAppointmentDialog : ContentDialog
    {
        public APIServices aPIServices;
        //public ClientAppointmentViewModel clientAppointmentViewModel { get; set; }
        //public ClientAppointment clientAppointment { get; set; }
        public ClientAppointment thisAppointment { get; set; }
        public Appointment Appointment { get; }
     
        public List<string> Statuses { get; set; }
        public PostAndPutAppointmentDialog(ClientAppointment app)
        {
            Statuses = new List<string>()
            { "Proposed", "Pending", "Booked", "Arrived", "Fulfilled", "CheckedIn", "Waitlist", "Noshow", "EnteredInError" };
            thisAppointment = app;
            //clientAppointmentViewModel = new ClientAppointmentViewModel();
            aPIServices = new APIServices();
            this.InitializeComponent();

        }

        /* Skapa ny appointment */
        public PostAndPutAppointmentDialog()
        {
            thisAppointment = new ClientAppointment();
            thisAppointment.Appointment = new Appointment();
            Statuses = new List<string>()
            { "Proposed", "Pending", "Booked", "Arrived", "Fulfilled", "CheckedIn", "Waitlist", "Noshow", "EnteredInError" };
            
            //clientAppointmentViewModel = new ClientAppointmentViewModel();
            aPIServices = new APIServices();
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private async void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (thisAppointment.Appointment.Id != null)
            {
                thisAppointment.Appointment = await aPIServices.PutAppointmentAsync(thisAppointment);

            }
            else
            {
                thisAppointment.Appointment = await aPIServices.PostAppointmentAsync(thisAppointment);
            }
        }
    }
}

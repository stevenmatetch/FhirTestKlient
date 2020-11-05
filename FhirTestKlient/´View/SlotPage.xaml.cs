using FhirTestKlient.Models;
using FhirTestKlient.Services;
using FhirTestKlient.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FhirTestKlient._View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SlotPage : Page
    {
        public ClientScheduleViewModel clientScheduleViewModel { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public ClientSlotViewModel clientSlotViewModel;
        public APIServices aPIServices { get; set; }
        public SlotPage()
        {
            clientScheduleViewModel = new ClientScheduleViewModel();
            clientSlotViewModel = new ClientSlotViewModel();
            clientSlotViewModel.slots = new ObservableCollection<ClientSlot>();
            aPIServices = new APIServices();

            this.InitializeComponent();
            GetAllSlots();
            GetAllSchedules();
        }
        public ClientSlotViewModel UpdateClientSlotViewModel
        {
            get
            {
                return clientSlotViewModel;
            }
            set
            {
                clientSlotViewModel = value;
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
        public async void GetAllSlots()
        {
            UpdateClientSlotViewModel.slots = await aPIServices.GetAllSlotsAsync();
            SlotListView.ItemsSource = await aPIServices.GetAllSlotsAsync();

        }
        public async void GetAllSchedules()
        {
           
            ScheduleListView.ItemsSource = await aPIServices.GetAllScheduleAsync();

        }

        private void OpenSplitview_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PractitionerRolePage));

        }
    }
}

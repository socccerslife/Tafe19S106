using StartFinance.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StartFinance.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppointmentEditPage : Page
    {
        AppointmentDetailViewModel viewModel;
        public AppointmentEditPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int id = Template10.Services.SerializationService.SerializationService.Json.Deserialize<int>(e.Parameter?.ToString());
            if (viewModel == null)
            {
                viewModel = new AppointmentDetailViewModel(Convert.ToInt32(id));
                DataContext = viewModel.Appointment;
            }
        }

        private async void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Appointment.EventName = txtEName.Text;
            viewModel.Appointment.Location = txtLocation.Text;
            viewModel.Appointment.EventDate = txtEDate.Text;
            viewModel.Appointment.StartTime = txtStartTime.Text;
            viewModel.Appointment.EndTime = txtEndTime.Text;
            if (viewModel.SaveEditedAppointment(viewModel.Appointment))
            {
                MessageDialog md = new MessageDialog("Appointment update successfully", "UPDATE OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Appointment update failed", "UPDATE OUTCOME");
                await md.ShowAsync();
            }

            var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
            nav.Navigate(typeof(AppointmentDetailPage), viewModel.Appointment.AppointmentId);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
            nav.Navigate(typeof(AppointmentDetailPage), viewModel.Appointment.AppointmentId);
        }
    }
}

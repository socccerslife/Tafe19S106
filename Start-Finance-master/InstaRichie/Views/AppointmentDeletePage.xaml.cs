using StartFinance.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class AppointmentDeletePage : Page
    {
        AppointmentDetailViewModel viewModel;
        public AppointmentDeletePage()
        {
            this.InitializeComponent();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int appointmentId = int.Parse(txtAppointmentId.Text);
                viewModel = new AppointmentDetailViewModel();
                if (viewModel.DeleteAppointment(appointmentId))
                {
                    MessageDialog md = new MessageDialog("Appointment has been deleted", "APPOINTMENT DELETED");
                    await md.ShowAsync();
                    Frame.Navigate(typeof(AppointmentPage));
                }
                else
                {
                    MessageDialog md = new MessageDialog("Appointment NOT deleted", "FAIL TO DELETE");
                    await md.ShowAsync();
                    txtAppointmentId.Focus(FocusState.Programmatic);
                    txtAppointmentId.SelectAll();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageDialog md = new MessageDialog("Please add new Appointment", "APPOINTMENT IS NOT EXIST");
                await md.ShowAsync();
                txtAppointmentId.Focus(FocusState.Programmatic);
                txtAppointmentId.SelectAll();
                return;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentPage));
        }
    }
}

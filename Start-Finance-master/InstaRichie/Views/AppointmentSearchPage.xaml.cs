using StartFinance.Models;
using StartFinance.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class AppointmentSearchPage : Page
    {
        private IAppointmentRepository Db { get; }
        private AppointmentSearchViewModel viewModel;
        private int appointmentId;
        private string EventName;

        public AppointmentSearchPage()
        {
            this.InitializeComponent();
            Db = App.Data;
            viewModel = new AppointmentSearchViewModel();
        }

        private async void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAID.Text))
            {
                MessageDialog md = new MessageDialog("Please insert appointment ID in field", "EMPTY FIELD");
                await md.ShowAsync();
                txtAID.Focus(FocusState.Programmatic);
                txtAID.SelectAll();
                return;
            }
            else
            {
                try
                {
                    appointmentId = int.Parse(txtAID.Text);
                }
                catch
                {
                    MessageDialog md = new MessageDialog("Please insert valid Appointment ID", "WRONG VALUE");
                    await md.ShowAsync();
                    txtAID.Focus(FocusState.Programmatic);
                    txtAID.SelectAll();
                    return;
                }
            }

            if (String.IsNullOrEmpty(txtEName.Text))
            {
                MessageDialog md = new MessageDialog("Please insert Event Name in field", "EMPTY FILED");
                await md.ShowAsync();
                txtEName.Focus(FocusState.Programmatic);
                txtEName.SelectAll();
                return;
            }
            else
            {
                EventName = txtEName.Text;
            }
                        

            foreach (var salmon in viewModel.FindAppointment(appointmentId, EventName))
            {
                Debug.Write(salmon + "\n");
            }
            MainListBox.ItemsSource = viewModel.FindAppointment(appointmentId, EventName);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentPage));
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var appointment = MainListBox.SelectedItem as Appointment;

            if (appointment != null)
            {
                var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
                nav.Navigate(typeof(AppointmentDetailPage), appointment.AppointmentId);
            }
            MainListBox.SelectedIndex = -1;
        }
    }
}

using StartFinance.Models;
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
    public sealed partial class AppointmentAddPage : Page
    {
        private AppointmentViewModel viewModel;
        public AppointmentAddPage()
        {
            this.InitializeComponent();
            viewModel = new AppointmentViewModel();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Appointment a = new Appointment();

            //validate Event Name section is empty
            if (String.IsNullOrEmpty(txtEName.Text))
            {
                MessageDialog md = new MessageDialog("Please write Event Name in field", "EMPTY VALUE");
                await md.ShowAsync();
                txtEName.Focus(FocusState.Programmatic);
                txtEName.SelectAll();
                return;
            }
            else
            {
                try
                {
                    a.EventName = txtEName.Text;
                }
                catch
                {
                    MessageDialog md = new MessageDialog("There is no data", "No data");
                    await md.ShowAsync();
                    txtEName.Focus(FocusState.Programmatic);
                    txtEName.SelectAll();
                    return;
                }
            }

            //validate Location section is empty
            if (String.IsNullOrEmpty(txtLocation.Text))
            {
                MessageDialog md = new MessageDialog("Please write Location in field", "EMPTY VALUE");
                await md.ShowAsync();
                txtLocation.Focus(FocusState.Programmatic);
                txtLocation.SelectAll();
                return;
            }
            else
            {
                try
                {
                    a.Location = txtLocation.Text;
                }
                catch
                {
                    MessageDialog md = new MessageDialog("There is no data", "No data");
                    await md.ShowAsync();
                    txtLocation.Focus(FocusState.Programmatic);
                    txtLocation.SelectAll();
                    return;
                }
            }


            //validate Event Date section is empty
            if (String.IsNullOrEmpty(txtEDate.Text))
            {
                MessageDialog md = new MessageDialog("Please write Event Date in field", "EMPTY VALUE");
                await md.ShowAsync();
                txtEDate.Focus(FocusState.Programmatic);
                txtEDate.SelectAll();
                return;
            }
            else
            {
                try
                {
                    a.EventDate = txtEDate.Text;
                }
                catch
                {
                    MessageDialog md = new MessageDialog("There is no data", "No data");
                    await md.ShowAsync();
                    txtEDate.Focus(FocusState.Programmatic);
                    txtEDate.SelectAll();
                    return;
                }
            }

            //validate Start Time section is empty
            if (String.IsNullOrEmpty(txtStartTime.Text))
            {
                MessageDialog md = new MessageDialog("Please write Start Time in field", "EMPTY VALUE");
                await md.ShowAsync();
                txtStartTime.Focus(FocusState.Programmatic);
                txtStartTime.SelectAll();
                return;
            }
            else
            {
                try
                {
                    a.StartTime = txtStartTime.Text;
                }
                catch
                {
                    MessageDialog md = new MessageDialog("There is no data", "No data");
                    await md.ShowAsync();
                    txtStartTime.Focus(FocusState.Programmatic);
                    txtStartTime.SelectAll();
                    return;
                }
            }

            //validate End Time section is empty
            if (String.IsNullOrEmpty(txtEndTime.Text))
            {
                MessageDialog md = new MessageDialog("Please write End Time in field", "EMPTY VALUE");
                await md.ShowAsync();
                txtEndTime.Focus(FocusState.Programmatic);
                txtEndTime.SelectAll();
                return;
            }
            else
            {
                try
                {
                    a.EndTime = txtEndTime.Text;
                }
                catch
                {
                    MessageDialog md = new MessageDialog("There is no data", "No data");
                    await md.ShowAsync();
                    txtEndTime.Focus(FocusState.Programmatic);
                    txtEndTime.SelectAll();
                    return;
                }
            }
            viewModel.AddNewAppointment(a);

            Frame.Navigate(typeof(AppointmentPage));

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentPage));
        }
    }
}

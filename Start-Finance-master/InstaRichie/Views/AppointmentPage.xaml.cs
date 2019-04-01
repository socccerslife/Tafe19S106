using StartFinance.Models;
using StartFinance.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Template10.Common;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class AppointmentPage : Page
    {
        AppointmentViewModel viewModel;

        public AppointmentPage()
        {
            this.InitializeComponent();
            viewModel = new AppointmentViewModel();
            if (!viewModel.IsDataLoaded)
            {
                viewModel.LoadData();
            }

            DataContext = viewModel;
            this.Loaded += new RoutedEventHandler(AppointmentPage_Loaded);
        }

        private void AppointmentPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!viewModel.IsDataLoaded)
            {
                viewModel.LoadData();
            }
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentSearchPage));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentAddPage));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AppointmentDeletePage));
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainListBox.SelectedItem = null;
        }
    }
}

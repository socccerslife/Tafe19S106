using StartFinance.Models;
using StartFinance.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Services.NavigationService;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Template10.Common.BootStrapper;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StartFinance.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactPage : Page
    {
        ContactViewModel viewModel;

        public ContactPage()
        {
            this.InitializeComponent();
            viewModel = new ContactViewModel();
            if (!viewModel.IsDataLoaded)
            {
                viewModel.LoadData();
            }

            DataContext = viewModel;
            this.Loaded += new RoutedEventHandler(ContactPage_Loaded);
        }

        private void ContactPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!viewModel.IsDataLoaded)
            {
                viewModel.LoadData();
            }
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var contact = MainListBox.SelectedItem as Contact;
            if (contact != null)
            {
                var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
                nav.Navigate(typeof(ContactDetailsPage), contact.Id);
            }
            MainListBox.SelectedIndex = -1;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainListBox.SelectedItem = null;
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.ContactNewPage));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.ContactSearchPage));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.ContactDeletePage));
        }
    }
}

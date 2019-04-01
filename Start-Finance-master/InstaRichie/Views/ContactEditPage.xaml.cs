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
    public sealed partial class ContactEditPage : Page
    {
        ContactDetailViewModel viewModel;
        public ContactEditPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //int id = (int)e.Parameter;
            int id = Template10.Services.SerializationService.SerializationService.Json.Deserialize<int>(e.Parameter?.ToString());
            if (viewModel == null)
            {
                //viewModel = new ContactDetailViewModel(id);
                viewModel = new ContactDetailViewModel(Convert.ToInt32(id));
                DataContext = viewModel.Contact;
            }
        }

        private async void Accept_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Contact.FirstName = txtFirst.Text;
            viewModel.Contact.LastName = txtLast.Text;
            viewModel.Contact.CompanyName = txtCompanyName.Text;
            viewModel.Contact.Phone = txtPhone.Text;
            if (viewModel.SaveEditedContact(viewModel.Contact))
            {
                MessageDialog md = new MessageDialog("Info changes updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Info changes NOT updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }

            //Frame.Navigate(typeof(Views.ContactDetailsPage), viewModel.Contact.Id);
            var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
            nav.Navigate(typeof(ContactDetailsPage), viewModel.Contact.Id);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(Views.ContactDetailsPage), viewModel.Contact.Id);
            var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
            nav.Navigate(typeof(ContactDetailsPage), viewModel.Contact.Id);
        }
    }
}

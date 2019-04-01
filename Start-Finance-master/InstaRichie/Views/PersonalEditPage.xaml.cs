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
    public sealed partial class PersonalEditPage : Page
    {
        PersonalDetailViewModel viewModel;
        public PersonalEditPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //int id = (int)e.Parameter;
            int id = Template10.Services.SerializationService.SerializationService.Json.Deserialize<int>(e.Parameter?.ToString());
            if (viewModel == null)
            {
                //viewModel = new PersonalDetailViewModel(id);
                viewModel = new PersonalDetailViewModel(Convert.ToInt32(id));
                DataContext = viewModel.Personal;
            }
        }

        private async void Accept_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Personal.FirstName = txtFirst.Text;
            viewModel.Personal.LastName = txtLast.Text;
            viewModel.Personal.DOB = txtDob.Text;
            viewModel.Personal.Gender = txtGender.Text;
            viewModel.Personal.Email = txtEmail.Text;
            viewModel.Personal.Phone = txtPhone.Text;
            if (viewModel.SaveEditedPersonal(viewModel.Personal))
            {
                MessageDialog md = new MessageDialog("Info changes updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Info changes NOT updated", "UPDATE OUTCOME");
                await md.ShowAsync();
            }

            //Frame.Navigate(typeof(Views.PersonalDetailsPage), viewModel.Personal.Id);
            var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
            nav.Navigate(typeof(PersonalDetailsPage), viewModel.Personal.Id);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(Views.PersonalDetailsPage), viewModel.Personal.Id);
            var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
            nav.Navigate(typeof(PersonalDetailsPage), viewModel.Personal.Id);
        }
    }
}

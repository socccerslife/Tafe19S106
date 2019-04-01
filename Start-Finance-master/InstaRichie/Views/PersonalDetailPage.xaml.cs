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
    public sealed partial class PersonalDetailsPage : Page
    {
        PersonalDetailViewModel viewModel;
        public PersonalDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int id = Template10.Services.SerializationService.SerializationService.Json.Deserialize<int>(e.Parameter?.ToString());

            if (viewModel == null)
            {
                viewModel = new PersonalDetailViewModel(Convert.ToInt32(id));
                DataContext = viewModel.Personal;
            }
        }

        //private void EditProduct_Click(object sender, EventArgs e)
        //{
        //    Frame.Navigate(typeof(Views.PersonalEditPage), viewModel.Personal.Id);
        //}

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.PersonalPage));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
            nav.Navigate(typeof(PersonalEditPage), viewModel.Personal.Id);
            //Frame.Navigate(typeof(Views.PersonalEditPage), viewModel.Personal.Id);
        }
    }
}

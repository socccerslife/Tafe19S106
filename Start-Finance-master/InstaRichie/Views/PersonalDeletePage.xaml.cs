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
    public sealed partial class PersonalDeletePage : Page
    {
        PersonalDetailViewModel viewModel;
        public PersonalDeletePage()
        {
            this.InitializeComponent();
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtid.Text);
                viewModel = new PersonalDetailViewModel();
                if (viewModel.DeletePersonal(id))
                {
                    MessageDialog md = new MessageDialog("Info has been deleted", "UPDATE OUTCOME");
                    await md.ShowAsync();
                    Frame.Navigate(typeof(Views.PersonalPage));
                }
                else
                {
                    MessageDialog md = new MessageDialog("Info changes NOT updated", "UPDATE OUTCOME");
                    await md.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                {
                    MessageDialog md = new MessageDialog("Info changes NOT updated", " PLEASE INPUT AN ID");
                    await md.ShowAsync();
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.PersonalPage));
        }
    }
}

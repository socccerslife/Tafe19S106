using StartFinance.Models;
using StartFinance.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class PersonalNewPage : Page
    {
        private PersonalViewModel viewModel;
        public PersonalNewPage()
        {
            this.InitializeComponent();
            viewModel = new PersonalViewModel();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Personal s = new Personal();
            s.FirstName = txtFirst.Text;
            s.LastName = txtLast.Text;
            s.DOB = txtDob.Text;
            s.Gender = txtGender.Text;
            s.Email = txtEmail.Text;
            s.Phone = txtPhone.Text;
            viewModel.AddNewPersonal(s);

            Frame.Navigate(typeof(Views.PersonalPage));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.PersonalPage));
        }
    }
}

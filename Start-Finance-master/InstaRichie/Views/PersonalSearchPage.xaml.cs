﻿using StartFinance.Models;
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
    public sealed partial class PersonalSearchPage : Page
    {
        private IPersonalRepository Db { get; }
        private PersonalSearchViewModel viewModel;
        private string first;
        private string last;
        private int id;
        private string phone;
        public PersonalSearchPage()
        {
            this.InitializeComponent();
            Db = App.Data;
            viewModel = new PersonalSearchViewModel();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirst.Text == "")
            {
                first = "";
            }
            try
            {
                first = txtFirst.Text;
            }
            catch
            {
                first = "";
            }
            if (txtLast.Text == "")
            {
                last = "";
            }
            try
            {
                last = txtLast.Text;
            }
            catch
            {
                last = "";
            }
            if (txtid.Text == "")
            {
                id = 0;
            }
            try
            {
                id = int.Parse(txtid.Text);
            }
            catch
            {
                id = 0;
            }
            if (txtPhone.Text == "")
            {
                phone = "";
            }
            try
            {
                phone = txtPhone.Text;
            }
            catch
            {
                phone = "";
            }
            foreach (var salmon in viewModel.FindPersonal(id, first, last, phone))
            {
                Debug.Write(salmon + "\n");
            }
            MainListBox.ItemsSource = viewModel.FindPersonal(id, first, last, phone);
        }

        private void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var personal = MainListBox.SelectedItem as Personal;

            if (personal != null)
            {
                //Frame.Navigate(typeof(Views.PersonalDetailsPage), personal.Id);
                var nav = WindowWrapper.Current().NavigationServices.FirstOrDefault();
                nav.Navigate(typeof(PersonalDetailsPage), personal.Id);
            }
            // Reset selected index to -1 (no selection)
            MainListBox.SelectedIndex = -1;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.PersonalPage));
        }
    }
}

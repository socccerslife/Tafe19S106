using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.ComponentModel;
using System.Collections.ObjectModel;
using StartFinance.Models;

namespace StartFinance.ViewModels
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        private IContactRepository Db { get; }
        private ObservableCollection<Contact> contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set
            {
                if (value != contacts)
                {
                    contacts = value;
                    NotifyPropertyChanged("Contacts");
                }
            }
        }

        public ContactViewModel()
        {
            Db = App.Data;
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadData()
        {
            Contacts = new ObservableCollection<Contact>(Db.GetContacts().ToList());
            this.IsDataLoaded = true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        internal async void AddNewContact(Contact newContact)
        {
            if (Db.InsertContact(newContact))
            {
                MessageDialog md = new MessageDialog("Info added to database", "INSERT OUTCOME");
                await md.ShowAsync();
            }
            else
            {
                MessageDialog md = new MessageDialog("Info NOT added to database", "INSERT OUTCOME");
                await md.ShowAsync();
            }
        }
    }
}

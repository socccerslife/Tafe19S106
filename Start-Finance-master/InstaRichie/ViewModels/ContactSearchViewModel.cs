using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using StartFinance.Models;

namespace StartFinance.ViewModels
{
    public class ContactSearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IContactRepository Db { get; }
        private ObservableCollection<Contact> contact;
        public ObservableCollection<Contact> Contacts
        {
            get { return contact; }

            set
            {
                if (value != contact)
                {
                    contact = value;
                    NotifyPropertyChanged("Contacts");
                }
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public ContactSearchViewModel()
        {
            Db = App.Data;
        }

        public IEnumerable<Contact> FindContact(int id, string first, string last, string phone)
        {
            return (Db.FindContact(id, first, last, phone));
            //Contacts = new ObservableCollection<Contact>(Db.GetContacts().ToList());
        }
    }
}

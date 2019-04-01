using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using StartFinance.Models;

namespace StartFinance.ViewModels
{
    public class ContactDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IContactRepository Db { get; }
        private Contact contact;

        public Contact Contact
        {
            get { return contact; }

            set
            {
                if (contact != value)
                {
                    contact = value;
                    RaisePropertyChanged("Contact");
                }
            }
        }

        private void RaisePropertyChanged(string propname)
        {
            var eh = PropertyChanged;
            if (eh != null)
                eh(this, new PropertyChangedEventArgs(propname));
        }

        public ContactDetailViewModel(int contactId)
        {
            Db = App.Data;
            this.Contact = Db.GetContactById(contactId);
        }

        public ContactDetailViewModel()
        {
            Db = App.Data;
        }

        public bool SaveEditedContact(Contact s)
        {
            return Db.UpdateContact(s);
        }
        public bool DeleteContact(int id)
        {
            return Db.DeleteContact(id);
        }
    }
}

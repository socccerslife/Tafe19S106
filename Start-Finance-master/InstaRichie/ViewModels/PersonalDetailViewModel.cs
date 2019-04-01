using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using StartFinance.Models;

namespace StartFinance.ViewModels
{
    public class PersonalDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IPersonalRepository Db { get; }
        private Personal personal;

        public Personal Personal
        {
            get { return personal; }

            set
            {
                if (personal != value)
                {
                    personal = value;
                    RaisePropertyChanged("Personal");
                }
            }
        }

        private void RaisePropertyChanged(string propname)
        {
            var eh = PropertyChanged;
            if (eh != null)
                eh(this, new PropertyChangedEventArgs(propname));
        }

        public PersonalDetailViewModel(int personalId)
        {
            Db = App.Data;
            this.Personal = Db.GetPersonalById(personalId);
        }

        public PersonalDetailViewModel()
        {
            Db = App.Data;
        }

        public bool SaveEditedPersonal(Personal s)
        {
            return Db.UpdatePersonal(s);
        }
        public bool DeletePersonal(int id)
        {
            return Db.DeletePersonal(id);
        }
    }
}

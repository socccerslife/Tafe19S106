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
    public class PersonalSearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IPersonalRepository Db { get; }
        private ObservableCollection<Personal> personal;
        public ObservableCollection<Personal> Personals
        {
            get { return personal; }

            set
            {
                if (value != personal)
                {
                    personal = value;
                    NotifyPropertyChanged("Personals");
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

        public PersonalSearchViewModel()
        {
            Db = App.Data;
        }

        public IEnumerable<Personal> FindPersonal(int id, string first, string last, string phone)
        {
            return (Db.FindPersonal(id, first, last, phone));
            //Personals = new ObservableCollection<Personal>(Db.GetPersonals().ToList());
        }
    }
}

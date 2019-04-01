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
    public class PersonalViewModel : INotifyPropertyChanged
    {
        private IPersonalRepository Db { get; }
        private ObservableCollection<Personal> personals;
        public ObservableCollection<Personal> Personals
        {
            get { return personals; }
            set
            {
                if (value != personals)
                {
                    personals = value;
                    NotifyPropertyChanged("Personals");
                }
            }
        }

        public PersonalViewModel()
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
            Personals = new ObservableCollection<Personal>(Db.GetPersonals().ToList());
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

        internal async void AddNewPersonal(Personal newPersonal)
        {
            if (Db.InsertPersonal(newPersonal))
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

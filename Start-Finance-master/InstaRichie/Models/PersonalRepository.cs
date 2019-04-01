using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite.Net;

namespace StartFinance.Models
{
    public class PersonalRepository : IPersonalRepository
    {
        string path;
        SQLiteConnection conn;

        public PersonalRepository(string dbName)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbName);
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn.CreateTable<Personal>();
        }

        public bool DeletePersonal(int personalId)
        {
            Personal p = GetPersonalById(personalId);
            if (conn.Delete(p) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Personal> FindPersonal(int id, string first, string last, string phone)
        {
            var personals = conn.Table<Personal>().ToList();
            if (id != 0)
            {
                return personals.FindAll(p => p.Id == id);
            }
            else if (first != null)
            {
                return personals.FindAll(p => p.FirstName == first);
            }
            else if (last != null)
            {
                return personals.FindAll(p => p.LastName == last);
            }
            else
            {
                return personals.FindAll(p => p.Phone == phone);
            }
        }

        public Personal GetPersonalById(int personalId)
        {
            var personals = conn.Table<Personal>().ToList();
            return personals.First(p => p.Id == personalId);
        }

        public IEnumerable<Personal> GetPersonals()
        {
            return conn.Table<Personal>().ToList();
        }

        public bool InsertPersonal(Personal personal)
        {
            if (conn.Insert(personal) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePersonal(Personal personal)
        {
            if (conn.Update(personal) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite.Net;

namespace StartFinance.Models
{
    public class ContactRepository : IContactRepository
    {
        string path;
        SQLiteConnection conn;

        public ContactRepository(string dbName)
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbName);
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn.CreateTable<Contact>();
        }

        public bool DeleteContact(int contactId)
        {
            Contact p = GetContactById(contactId);
            if (conn.Delete(p) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Contact> FindContact(int id, string first, string last, string phone)
        {
            var contacts = conn.Table<Contact>().ToList();
            if (id != 0)
            {
                return contacts.FindAll(p => p.Id == id);
            }
            else if (first != null)
            {
                return contacts.FindAll(p => p.FirstName == first);
            }
            else if (last != null)
            {
                return contacts.FindAll(p => p.LastName == last);
            }
            else
            {
                return contacts.FindAll(p => p.Phone == phone);
            }
        }

        public Contact GetContactById(int contactId)
        {
            var contacts = conn.Table<Contact>().ToList();
            return contacts.First(p => p.Id == contactId);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return conn.Table<Contact>().ToList();
        }

        public bool InsertContact(Contact contact)
        {
            if (conn.Insert(contact) > 0)
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

        public bool UpdateContact(Contact contact)
        {
            if (conn.Update(contact) > 0)
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


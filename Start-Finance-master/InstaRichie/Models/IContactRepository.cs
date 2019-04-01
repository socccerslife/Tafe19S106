using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartFinance.Models
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContactById(int contactId);
        bool InsertContact(Contact contact);
        bool DeleteContact(int contactId);
        bool UpdateContact(Contact contact);
        IEnumerable<Contact> FindContact(int id, string first, string last, string phone);
        void Save();
    }
}

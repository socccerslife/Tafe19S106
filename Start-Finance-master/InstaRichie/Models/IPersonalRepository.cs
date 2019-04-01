using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartFinance.Models
{
    public interface IPersonalRepository
    {
        IEnumerable<Personal> GetPersonals();
        Personal GetPersonalById(int personalId);
        bool InsertPersonal(Personal personal);
        bool DeletePersonal(int personalId);
        bool UpdatePersonal(Personal personal);
        IEnumerable<Personal> FindPersonal(int id, string first, string last, string phone);
        void Save();
    }
}

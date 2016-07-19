using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beer.Model;

namespace Beer.Data
{
    public interface IGenericRepository<T> where T : RepositoryObject
    {
        IEnumerable<T> SelectAll();
        T SelectById(object id);
        T SearchByName(string name);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}

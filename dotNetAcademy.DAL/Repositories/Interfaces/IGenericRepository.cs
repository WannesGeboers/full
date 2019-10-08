using System;
using System.Collections.Generic;
using System.Text;

namespace dotNetAcademy.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Delete(int id);
        void Update(int id,T obj);
        void Save();
    }
}

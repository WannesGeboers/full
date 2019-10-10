using System;
using System.Collections.Generic;
using System.Text;

namespace dotNetAcademy.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Insert(T obj);
        void Delete(string id);
        void Save();
    }
}

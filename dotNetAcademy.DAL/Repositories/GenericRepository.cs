using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotNetAcademy.DAL.Context;
using dotNetAcademy.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotNetAcademy.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DotNetAcademyDbContext _context;
        private readonly DbSet<T> table = null;

        public GenericRepository(DotNetAcademyDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.AsEnumerable();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Delete(int id)
        {
            var res = table.Find(id);
            if (res != null)
            {
                table.Remove(res);
            }
        }

        public void Update(int id,T obj)
        {
            var res = table.Find(id);
            //TODO: check for changes

            if (res != null)
            {
                _context.Set<T>().Update(obj);
                //_context.Entry(res).State = EntityState.Modified;
            }

            
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

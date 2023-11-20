﻿using dbThuCung.Model.Context;
using dbThuCung.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbThuCung.Repository.Repository
{
    public class Repo<T> : IRepo<T> where T : class, new()
    {
        private readonly ThuCungContext _context;
        DbSet<T> _dbSet;
        public Repo(ThuCungContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public bool Add(T entity)
        {
            bool result = false;
            if (!_dbSet.Any(e => e == entity))
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                result = true;
            }
            return result;
        }

        public bool Delete(long id)
        {
            bool result = true;
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                result = false;
            }
            else
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
            return result;

        }

        public T Get(long id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public bool Update(T entity)
        {
            bool result = true;
            if (!_dbSet.Any(e => e == entity))
            {
                result = false;
            }
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return result;
        }

    }
}

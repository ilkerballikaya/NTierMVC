﻿using Project.BLL.DesignPatterns.RepositoryPattern.IntRep;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.Context;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.RepositoryPattern.BaseRep
{
    public class BaseRepository<T>:IRepository<T> where T:BaseEntity
    {
        protected MyContext db;

        public BaseRepository()
        {
            db = DBTool.DBInstance;
        }


        public void Add(T item)
        {
            db.Set<T>().Add(item);
            Save();
        }

        protected void Save()
        {
            db.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public void Delete(T item)
        {
            item.Status = MODEL.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void Destroy(T item)
        {
            db.Set<T>().Remove(item);
            Save();
        }

        public T Find(int id)
        {
            return db.Set<T>().Find(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().FirstOrDefault(exp);
        }

        public List<T> GetActives()
        {
            return Where(x => x.Status != MODEL.Enums.DataStatus.Deleted);
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public List<T> GetModifieds()
        {
            return Where(x => x.Status == MODEL.Enums.DataStatus.Updated);

        }

        public List<T> GetPassives()
        {
            return Where(x => x.Status == MODEL.Enums.DataStatus.Deleted);

        }

        public object Select(Expression<Func<T, object>> exp)
        {
            return db.Set<T>().Select(exp);
        }

        public void Update(T item)
        {
            T guncellenecek = Find(item.ID);
            item.Status = MODEL.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            db.Entry(guncellenecek).CurrentValues.SetValues(item);
            Save();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
        }


    }
}

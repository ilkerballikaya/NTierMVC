using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.RepositoryPattern.IntRep
{
    public interface IRepository<T> where T:BaseEntity
    {
        //Listeleme 
        List<T> GetAll();
        List<T> GetPassives();
        List<T> GetActives();
        List<T> GetModifieds();

        //Modifikasyon
        void Add(T item);
        void Delete(T item);
        void Update(T item);
        void Destroy(T item);

        //Sorgulamalar
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        T Find(int id);
        object Select(Expression<Func<T, object>> exp);


    }
}

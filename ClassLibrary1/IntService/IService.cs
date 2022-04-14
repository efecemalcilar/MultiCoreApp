using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Core.IntService
{
    public interface IService<T> where T:class
    {
        Task<T> GetByIdAsync(int id);
        // Asenkron programlama yapmak için Task ifadesi ile başlarız. İçeride trading yapılarım var ve bu birden fazla işlemin aynı anda yürütülmesi anlamına geliyor. Html ayrı bir kanalda database ayrı bir kanalde yükleniyor. Trade işlemde de kaç çekirdek varsa o kadar sayıya bölebiliyor.

        Task<IEnumerable<T>> GetAllAsync(); //Soyut olarak kullanıyorum. List dersek ram da oluşturmak zorunda yani fiziksel karşılığını bulmak zorunda.

        Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate); //Select * from Product where name = "Apple" Anlamına geliyor. True dönüyor ve IEnumerable şeklinde listeye ceviriyor. Bu fonksyon geri döüş değeri olarak bool bekliyor.

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<IQueryable<T>> QListAsync();  // Async tag i burada asenkron calıstıgımızı belirtmek için kullanılır.


        // Update ve delete işleminin asenkron yapıları yoktur.

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities); // Biritek tek ekleme işlemi yaparken diğeri grup halinde yapıyor.

        T Update(T entity); // T nin anlamı Product verdiysem product tipinde geri dönüş bekliyor anlamına geliyor

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task DeleteAsync(T entity);

        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}

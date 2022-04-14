using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.Core.IntRepository;

namespace MultiCoreApp.Core.IntUnitOfWork
{
    public interface IUnitOfWork 
    {
        IProductRepository ProductRepository { get; } // Save işlemi gerçekleşmeden once product repository adında bir alanı doldurmuş oldum.
        // Bu katman Bir patterndir. Add işlemi ile save işlemni arasında bir aralık var o ara burası oluyor.Amacım unitofwork tetiklenmeden once araya bir sistem sokmak. Bunun core tarafında bir adı var 

        ICategoryRepository CategoryRepository { get; }



        Task CommintAsync(); // Savechange işlemim. Add işlemi için bunu kullanırken 

        void Commit(); // update ve remove için bunu kullanmaya calıscam.
    }
}

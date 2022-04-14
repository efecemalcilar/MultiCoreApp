using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Core.Models
{
    public class Product // 1 ürünün 1 kategorisi olur genellikle
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public int Stock { get; set; } = 0;

        public decimal Price { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Guid CategoryId { get; set; } // Bunu yapmazsak category_id diye bir şey oluşturacak ve ben buna class üzerinden ulaşamıycam class da tanımlı olmadığı için.

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = new Category(); //Buraya gelebilcek olan değer tekildir. Newledik çünkü database de oluşuyo sonra cağırmak istediğimde yer var ama newlemezsem ramda oluşmuyo. Newlediğim için ram de oluşyor ve cağrırken iyi oluyo..

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basadann
{
   public  class ShopContext: DbContext
    {
       public ShopContext()
           : base("BookShop")
        { }
       public virtual DbSet<Authos> Authos { get; set; }
       public virtual DbSet<Books> Books { get; set; }
       public virtual DbSet<Izdanie> Izdanie { get; set; }
       public virtual DbSet<Izdatelstvo1> Izdatelstvo1 { get; set; }
       public virtual DbSet<Prodazhi> Prodazhi { get; set; }
       public virtual DbSet<Sotrudniki> Sotrudniki { get; set; }
    }
}

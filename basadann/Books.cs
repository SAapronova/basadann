

namespace basadann
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Books")]
    public partial class Books
    {
        public Books()
        {
            Prodazhi = new HashSet<Prodazhi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bookshifr { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? idauthor { get; set; }

        
        public int? idizdanie { get; set; }

        
        public int? idizdatelstvo { get; set; }

        [StringLength(50)]
        public string ganr { get; set; }

        [StringLength(50)]
        public string price { get; set; }

       public virtual Authos Authos { get; set; }

       public virtual Izdanie Izdanie { get; set; }

      public virtual Izdatelstvo1 Izdatelstvo1 { get; set; }

        public virtual ICollection<Prodazhi> Prodazhi { get; set; }
    }
}

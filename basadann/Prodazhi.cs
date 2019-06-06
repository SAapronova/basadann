using System;
using System.Collections.Generic;
using System.Data.Entity;
 

namespace basadann
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodazhi")]
    public partial class Prodazhi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idprod { get; set; }

        public int? idsotrud { get; set; }

       
        public int bookshifr { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public TimeSpan? time { get; set; }

       // public virtual Books Books { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }
    }
}

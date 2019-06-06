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

    [Table("Sotrudniki")]
    public partial class Sotrudniki
    {
        public Sotrudniki()
        {
            Prodazhi = new HashSet<Prodazhi>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idsotrud { get; set; }

        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }

        [StringLength(50)]
        public string Backname { get; set; }

        [StringLength(50)]
        public string Dolznost { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Telephone { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
        public virtual ICollection<Prodazhi> Prodazhi { get; set; }
    }
}

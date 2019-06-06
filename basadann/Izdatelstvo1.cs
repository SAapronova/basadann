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

    [Table("Izdatelstvo1")]
    public partial class Izdatelstvo1
    {
        public Izdatelstvo1()
        {
            Books = new HashSet<Books>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idizdatelstvo { get; set; }

        [StringLength(50)]
        public string naimenovanie { get; set; }

        [StringLength(10)]
        public string year { get; set; }

        [StringLength(50)]
        public string kolvostr { get; set; }

        [StringLength(50)]
        public string gorod { get; set; }

        [StringLength(50)]
        public string telef { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}

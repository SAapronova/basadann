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

    [Table("Izdanie")]
    public partial class Izdanie
    {
        public Izdanie()
        {
            Books = new HashSet<Books>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idizdanie { get; set; }

        [StringLength(50)]
        public string pereplet { get; set; }

        [StringLength(50)]
        public string format { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}

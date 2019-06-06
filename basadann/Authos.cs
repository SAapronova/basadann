
namespace basadann
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Authos")]
    public partial class Authos
    {
        public Authos()
        {
            Books = new HashSet<Books>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idauthor { get; set; }

        [StringLength(50)]
        public string lastname { get; set; }

        [StringLength(50)]
        public string firstname { get; set; }

        [StringLength(50)]
        public string backname { get; set; }

        public int? birthyear { get; set; }

        public int? deathyear { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}

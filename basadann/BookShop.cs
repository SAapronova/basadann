
namespace basadann
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookShop : DbContext
    {
        public BookShop()
            : base("name=BookShop")
        {
        }

        public virtual DbSet<Authos> Authos { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Izdanie> Izdanie { get; set; }
        public virtual DbSet<Izdatelstvo1> Izdatelstvo1 { get; set; }
        public virtual DbSet<Prodazhi> Prodazhi { get; set; }
        public virtual DbSet<Sotrudniki> Sotrudniki { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authos>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Authos)
                .HasForeignKey(e => e.idauthor);

            modelBuilder.Entity<Books>()
                .Property(e => e.bookshifr)
                .HasColumnType("int");

            modelBuilder.Entity<Books>()
                .Property(e => e.idizdanie)
                .HasColumnType("int");

            modelBuilder.Entity<Books>()
               .Property(e => e.idauthor)
               .HasColumnType("int");

            modelBuilder.Entity<Books>()
                .Property(e => e.idizdatelstvo)
                .HasColumnType("int");


            modelBuilder.Entity<Izdanie>()
                .Property(e => e.idizdanie)
                .HasColumnType("int");
               

            modelBuilder.Entity<Izdatelstvo1>()
                .Property(e => e.idizdatelstvo)
                .HasColumnType("int");

            modelBuilder.Entity<Izdatelstvo1>()
                .Property(e => e.year)
                .IsFixedLength();

            modelBuilder.Entity<Prodazhi>()
             
                .Property(e => e.bookshifr)
                 .HasColumnType("int");

            modelBuilder.Entity<Sotrudniki>()
                .Property(e => e.Telephone)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Sotrudniki>()
             .Property(e => e.Login)
             .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
             .Property(e => e.Password)
             .IsFixedLength();

            modelBuilder.Entity<Sotrudniki>()
                .HasMany(e => e.Prodazhi)
                .WithRequired(e => e.Sotrudniki)
                .WillCascadeOnDelete(false);

           

        
        }
    }
}

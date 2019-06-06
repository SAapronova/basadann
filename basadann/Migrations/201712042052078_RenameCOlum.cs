namespace basadann.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCOlum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authos",
                c => new
                    {
                        idauthor = c.Int(nullable: false),
                        lastname = c.String(maxLength: 50),
                        firstname = c.String(maxLength: 50),
                        backname = c.String(maxLength: 50),
                        birthyear = c.Int(),
                        deathyear = c.Int(),
                    })
                .PrimaryKey(t => t.idauthor);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        bookshifr = c.Int(nullable: false),
                        name = c.String(maxLength: 50),
                        iduathor = c.Int(nullable: false),
                        idizdanie = c.Int(nullable: false),
                        idizdatelstvo = c.Int(nullable: false),
                        ganr = c.String(maxLength: 50),
                        price = c.String(maxLength: 50),
                        Authos_idauthor = c.Int(),
                    })
                .PrimaryKey(t => t.bookshifr)
                .ForeignKey("dbo.Authos", t => t.Authos_idauthor)
                .ForeignKey("dbo.Izdanie", t => t.idizdanie, cascadeDelete: true)
                .ForeignKey("dbo.Izdatelstvo1", t => t.idizdatelstvo, cascadeDelete: true)
                .Index(t => t.idizdanie)
                .Index(t => t.idizdatelstvo)
                .Index(t => t.Authos_idauthor);
            
            CreateTable(
                "dbo.Izdanie",
                c => new
                    {
                        idizdanie = c.Int(nullable: false),
                        pereplet = c.String(maxLength: 50),
                        format = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.idizdanie);
            
            CreateTable(
                "dbo.Izdatelstvo1",
                c => new
                    {
                        idizdatelstvo = c.Int(nullable: false),
                        naimenovanie = c.String(maxLength: 50),
                        year = c.String(maxLength: 10),
                        kolvostr = c.String(maxLength: 50),
                        gorod = c.String(maxLength: 50),
                        telef = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.idizdatelstvo);
            
            CreateTable(
                "dbo.Prodazhi",
                c => new
                    {
                        idprod = c.Int(nullable: false),
                        idsotrud = c.Int(nullable: false),
                        bookshifr = c.String(maxLength: 10),
                        date = c.DateTime(storeType: "date"),
                        time = c.Time(precision: 7),
                        Books_bookshifr = c.Int(),
                    })
                .PrimaryKey(t => t.idprod)
                .ForeignKey("dbo.Books", t => t.Books_bookshifr)
                .ForeignKey("dbo.Sotrudniki", t => t.idsotrud, cascadeDelete: true)
                .Index(t => t.idsotrud)
                .Index(t => t.Books_bookshifr);
            
            CreateTable(
                "dbo.Sotrudniki",
                c => new
                    {
                        idsotrud = c.Int(nullable: false),
                        Lastname = c.String(nullable: false, maxLength: 50),
                        Firstname = c.String(maxLength: 50),
                        Backname = c.String(maxLength: 50),
                        Dolznost = c.String(maxLength: 50),
                        Telephone = c.Decimal(precision: 18, scale: 2, storeType: "numeric"),
                    })
                .PrimaryKey(t => t.idsotrud);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prodazhi", "idsotrud", "dbo.Sotrudniki");
            DropForeignKey("dbo.Prodazhi", "Books_bookshifr", "dbo.Books");
            DropForeignKey("dbo.Books", "idizdatelstvo", "dbo.Izdatelstvo1");
            DropForeignKey("dbo.Books", "idizdanie", "dbo.Izdanie");
            DropForeignKey("dbo.Books", "Authos_idauthor", "dbo.Authos");
            DropIndex("dbo.Prodazhi", new[] { "Books_bookshifr" });
            DropIndex("dbo.Prodazhi", new[] { "idsotrud" });
            DropIndex("dbo.Books", new[] { "Authos_idauthor" });
            DropIndex("dbo.Books", new[] { "idizdatelstvo" });
            DropIndex("dbo.Books", new[] { "idizdanie" });
            DropTable("dbo.Sotrudniki");
            DropTable("dbo.Prodazhi");
            DropTable("dbo.Izdatelstvo1");
            DropTable("dbo.Izdanie");
            DropTable("dbo.Books");
            DropTable("dbo.Authos");
        }
    }
}

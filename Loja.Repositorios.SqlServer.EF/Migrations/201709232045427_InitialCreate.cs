namespace Loja.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200),
                        Preco = c.Decimal(nullable: false, precision: 9, scale: 2),
                        Estoque = c.Int(nullable: false),
                        Descont = c.Boolean(nullable: false),
                        Categoria_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.Categoria_ID)
                .Index(t => t.Categoria_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "Categoria_ID", "dbo.Categoria");
            DropIndex("dbo.Produto", new[] { "Categoria_ID" });
            DropTable("dbo.Produto");
            DropTable("dbo.Categoria");
        }
    }
}

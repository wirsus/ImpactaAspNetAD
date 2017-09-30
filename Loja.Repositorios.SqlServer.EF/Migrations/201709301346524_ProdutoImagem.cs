namespace Loja.Repositorios.SqlServer.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProdutoImagem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdutoImagem",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false),
                        Bytes = c.Binary(),
                        ContentType = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.ProdutoId);
            
            AddColumn("dbo.Produto", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            DropColumn("dbo.Produto", "Descont");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Descont", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ProdutoImagem", "ProdutoId", "dbo.Produto");
            DropIndex("dbo.ProdutoImagem", new[] { "ProdutoId" });
            DropColumn("dbo.Produto", "Ativo");
            DropTable("dbo.ProdutoImagem");
        }
    }
}

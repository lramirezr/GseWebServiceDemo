namespace Gse.WebService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Cif = c.String(),
                        Nombre = c.String(),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(),
                        FechaModificacion = c.DateTime(nullable: false),
                        UsuarioId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NombreUsuario = c.String(),
                        Contrasenya = c.Binary(),
                        Email = c.String(),
                        Nombre = c.String(),
                        Apellidos = c.String(),
                        FechaNacimiento = c.DateTime(),
                        FechaAlta = c.DateTime(nullable: false),
                        FechaBaja = c.DateTime(),
                        FechaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empresas", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Empresas", new[] { "UsuarioId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Empresas");
        }
    }
}

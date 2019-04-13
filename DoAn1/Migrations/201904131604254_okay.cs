namespace DoAn1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class okay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietGioHangs",
                c => new
                    {
                        IDGioHang = c.String(nullable: false, maxLength: 128),
                        idSach = c.Int(nullable: false),
                        Sach_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.IDGioHang, t.idSach })
                .ForeignKey("dbo.GioHangs", t => t.IDGioHang, cascadeDelete: true)
                .ForeignKey("dbo.Saches", t => t.Sach_id)
                .Index(t => t.IDGioHang)
                .Index(t => t.Sach_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietGioHangs", "Sach_id", "dbo.Saches");
            DropForeignKey("dbo.ChiTietGioHangs", "IDGioHang", "dbo.GioHangs");
            DropIndex("dbo.ChiTietGioHangs", new[] { "Sach_id" });
            DropIndex("dbo.ChiTietGioHangs", new[] { "IDGioHang" });
            DropTable("dbo.ChiTietGioHangs");
        }
    }
}

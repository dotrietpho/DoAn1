namespace DoAn1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comeon : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChiTietGioHangs", "GioHang_id", "dbo.GioHangs");
            DropForeignKey("dbo.ChiTietGioHangs", "Sach_id", "dbo.Saches");
            DropForeignKey("dbo.HoaDons", "GioHang_id", "dbo.GioHangs");
            DropForeignKey("dbo.KhachHangs", "GioHang_id", "dbo.GioHangs");
            DropIndex("dbo.ChiTietGioHangs", new[] { "GioHang_id" });
            DropIndex("dbo.ChiTietGioHangs", new[] { "Sach_id" });
            DropIndex("dbo.HoaDons", new[] { "GioHang_id" });
            DropIndex("dbo.KhachHangs", new[] { "GioHang_id" });
            DropColumn("dbo.KhachHangs", "idGioHang");
            RenameColumn(table: "dbo.HoaDons", name: "GioHang_id", newName: "idGioHang");
            RenameColumn(table: "dbo.KhachHangs", name: "GioHang_id", newName: "idGioHang");
            DropPrimaryKey("dbo.GioHangs");
            AddColumn("dbo.GioHangs", "IDGioHang", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.HoaDons", "idGioHang", c => c.String(maxLength: 128));
            AlterColumn("dbo.KhachHangs", "idGioHang", c => c.String(maxLength: 128));
            AlterColumn("dbo.KhachHangs", "idGioHang", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.GioHangs", "IDGioHang");
            CreateIndex("dbo.HoaDons", "idGioHang");
            CreateIndex("dbo.KhachHangs", "idGioHang");
            AddForeignKey("dbo.HoaDons", "idGioHang", "dbo.GioHangs", "IDGioHang");
            AddForeignKey("dbo.KhachHangs", "idGioHang", "dbo.GioHangs", "IDGioHang");
            DropColumn("dbo.GioHangs", "id");
            DropTable("dbo.ChiTietGioHangs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ChiTietGioHangs",
                c => new
                    {
                        idGioHang = c.Int(nullable: false),
                        idSach = c.Int(nullable: false),
                        GioHang_id = c.Int(),
                        Sach_id = c.Int(),
                    })
                .PrimaryKey(t => new { t.idGioHang, t.idSach });
            
            AddColumn("dbo.GioHangs", "id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.KhachHangs", "idGioHang", "dbo.GioHangs");
            DropForeignKey("dbo.HoaDons", "idGioHang", "dbo.GioHangs");
            DropIndex("dbo.KhachHangs", new[] { "idGioHang" });
            DropIndex("dbo.HoaDons", new[] { "idGioHang" });
            DropPrimaryKey("dbo.GioHangs");
            AlterColumn("dbo.KhachHangs", "idGioHang", c => c.Int());
            AlterColumn("dbo.KhachHangs", "idGioHang", c => c.Int(nullable: false));
            AlterColumn("dbo.HoaDons", "idGioHang", c => c.Int());
            DropColumn("dbo.GioHangs", "IDGioHang");
            AddPrimaryKey("dbo.GioHangs", "id");
            RenameColumn(table: "dbo.KhachHangs", name: "idGioHang", newName: "GioHang_id");
            RenameColumn(table: "dbo.HoaDons", name: "idGioHang", newName: "GioHang_id");
            AddColumn("dbo.KhachHangs", "idGioHang", c => c.Int(nullable: false));
            CreateIndex("dbo.KhachHangs", "GioHang_id");
            CreateIndex("dbo.HoaDons", "GioHang_id");
            CreateIndex("dbo.ChiTietGioHangs", "Sach_id");
            CreateIndex("dbo.ChiTietGioHangs", "GioHang_id");
            AddForeignKey("dbo.KhachHangs", "GioHang_id", "dbo.GioHangs", "id");
            AddForeignKey("dbo.HoaDons", "GioHang_id", "dbo.GioHangs", "id");
            AddForeignKey("dbo.ChiTietGioHangs", "Sach_id", "dbo.Saches", "id");
            AddForeignKey("dbo.ChiTietGioHangs", "GioHang_id", "dbo.GioHangs", "id");
        }
    }
}

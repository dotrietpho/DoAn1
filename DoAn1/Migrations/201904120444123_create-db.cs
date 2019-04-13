namespace DoAn1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => new { t.idGioHang, t.idSach })
                .ForeignKey("dbo.GioHangs", t => t.GioHang_id)
                .ForeignKey("dbo.Saches", t => t.Sach_id)
                .Index(t => t.GioHang_id)
                .Index(t => t.Sach_id);
            
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TongTienGioHang = c.Int(nullable: false),
                        TinhTrang = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Saches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TenSach = c.String(),
                        HinhSach = c.String(),
                        GiaSach = c.Int(nullable: false),
                        TenTacGia = c.String(),
                        SoTrang = c.Int(nullable: false),
                        SoLuongConLai = c.Int(nullable: false),
                        SoLuongXem = c.Int(nullable: false),
                        MoTa = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TinhTrang = c.String(),
                        TongTien = c.Int(nullable: false),
                        DiaChiGiaoHang = c.String(),
                        SDTGiaoHang = c.String(),
                        GhiChu = c.String(),
                        NgayLapHD = c.String(),
                        NgayHenGiaoHang = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        GioHang_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GioHangs", t => t.GioHang_id)
                .Index(t => t.GioHang_id);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        TaiKhoan = c.String(nullable: false, maxLength: 128),
                        MatKhau = c.String(),
                        TenKH = c.String(),
                        NgaySinh = c.String(),
                        SDT = c.Int(nullable: false),
                        GioiTinh = c.Boolean(nullable: false),
                        SoLanTruyCap = c.Int(nullable: false),
                        AnhDaiDien = c.String(),
                        isDeleted = c.Boolean(nullable: false),
                        idGioHang = c.Int(nullable: false),
                        GioHang_id = c.Int(),
                    })
                .PrimaryKey(t => t.TaiKhoan)
                .ForeignKey("dbo.GioHangs", t => t.GioHang_id)
                .Index(t => t.GioHang_id);
            
            CreateTable(
                "dbo.TaiKhoanAdmins",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        TaiKhoan = c.String(),
                        MatKhau = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KhachHangs", "GioHang_id", "dbo.GioHangs");
            DropForeignKey("dbo.HoaDons", "GioHang_id", "dbo.GioHangs");
            DropForeignKey("dbo.ChiTietGioHangs", "Sach_id", "dbo.Saches");
            DropForeignKey("dbo.ChiTietGioHangs", "GioHang_id", "dbo.GioHangs");
            DropIndex("dbo.KhachHangs", new[] { "GioHang_id" });
            DropIndex("dbo.HoaDons", new[] { "GioHang_id" });
            DropIndex("dbo.ChiTietGioHangs", new[] { "Sach_id" });
            DropIndex("dbo.ChiTietGioHangs", new[] { "GioHang_id" });
            DropTable("dbo.TaiKhoanAdmins");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.Saches");
            DropTable("dbo.GioHangs");
            DropTable("dbo.ChiTietGioHangs");
        }
    }
}

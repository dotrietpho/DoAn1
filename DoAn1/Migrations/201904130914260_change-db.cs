namespace DoAn1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Saches", "NgayXuatBan", c => c.String());
            DropColumn("dbo.Saches", "SoLuongConLai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Saches", "SoLuongConLai", c => c.Int(nullable: false));
            DropColumn("dbo.Saches", "NgayXuatBan");
        }
    }
}

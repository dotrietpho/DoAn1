namespace DoAn1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHangs", "SDT", c => c.String());
            AlterColumn("dbo.KhachHangs", "GioiTinh", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHangs", "GioiTinh", c => c.Boolean(nullable: false));
            AlterColumn("dbo.KhachHangs", "SDT", c => c.Int(nullable: false));
        }
    }
}

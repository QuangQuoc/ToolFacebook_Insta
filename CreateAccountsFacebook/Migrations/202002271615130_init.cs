namespace ControlLdPlayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_name = c.String(unicode: false),
                        user_id = c.String(unicode: false),
                        email = c.String(unicode: false),
                        phone_number = c.String(unicode: false),
                        password = c.String(unicode: false),
                        fb_2fa_code = c.String(unicode: false),
                        BrowserName = c.String(unicode: false),
                        BrowserFileName = c.String(unicode: false),
                        BrowserStatus = c.Boolean(nullable: false),
                        full_name = c.String(unicode: false),
                        birthday = c.DateTime(nullable: false, precision: 0),
                        avatar_id = c.Int(nullable: false),
                        gioi_tinh = c.String(unicode: false),
                        Device_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.avatars", t => t.avatar_id, cascadeDelete: true)
                .ForeignKey("dbo.devices", t => t.Device_Id)
                .Index(t => t.avatar_id)
                .Index(t => t.Device_Id);
            
            CreateTable(
                "dbo.avatars",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        link = c.String(unicode: false),
                        using_number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.devices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                        DeviceIp = c.String(unicode: false),
                        status = c.Boolean(nullable: false),
                        host_id = c.Int(nullable: false),
                        actived_account = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.hosts", t => t.host_id, cascadeDelete: true)
                .Index(t => t.host_id);
            
            CreateTable(
                "dbo.hosts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.LDProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resolution = c.String(unicode: false),
                        Cpu = c.String(unicode: false),
                        Memory = c.String(unicode: false),
                        Imei = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.devices", "host_id", "dbo.hosts");
            DropForeignKey("dbo.accounts", "Device_Id", "dbo.devices");
            DropForeignKey("dbo.accounts", "avatar_id", "dbo.avatars");
            DropIndex("dbo.devices", new[] { "host_id" });
            DropIndex("dbo.accounts", new[] { "Device_Id" });
            DropIndex("dbo.accounts", new[] { "avatar_id" });
            DropTable("dbo.LDProperties");
            DropTable("dbo.hosts");
            DropTable("dbo.devices");
            DropTable("dbo.avatars");
            DropTable("dbo.accounts");
        }
    }
}

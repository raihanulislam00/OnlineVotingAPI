namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udvoteoption : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "UserId", "dbo.Users");
            DropIndex("dbo.Votes", new[] { "UserId" });
            AlterColumn("dbo.Votes", "UserId", c => c.Int());
            CreateIndex("dbo.Votes", "UserId");
            AddForeignKey("dbo.Votes", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "UserId", "dbo.Users");
            DropIndex("dbo.Votes", new[] { "UserId" });
            AlterColumn("dbo.Votes", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Votes", "UserId");
            AddForeignKey("dbo.Votes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}

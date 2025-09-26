namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OptionText = c.String(nullable: false),
                        PollId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Poll_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.Poll_Id)
                .Index(t => t.Poll_Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PollId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.OptionId, cascadeDelete: false)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.Options", t => t.OptionId, cascadeDelete: false)
                .Index(t => t.PollId)
                .Index(t => t.OptionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "OptionId", "dbo.Options");
            DropForeignKey("dbo.Votes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Votes", "PollId", "dbo.Polls");
            DropForeignKey("dbo.Votes", "OptionId", "dbo.Polls");
            DropForeignKey("dbo.Options", "PollId", "dbo.Polls");
            DropForeignKey("dbo.Polls", "Poll_Id", "dbo.Polls");
            DropIndex("dbo.Votes", new[] { "UserId" });
            DropIndex("dbo.Votes", new[] { "OptionId" });
            DropIndex("dbo.Votes", new[] { "PollId" });
            DropIndex("dbo.Polls", new[] { "Poll_Id" });
            DropIndex("dbo.Options", new[] { "PollId" });
            DropTable("dbo.Users");
            DropTable("dbo.Votes");
            DropTable("dbo.Polls");
            DropTable("dbo.Options");
        }
    }
}

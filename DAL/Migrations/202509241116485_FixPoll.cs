namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class FixPoll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Options", "PollId", "dbo.Polls");

            DropIndex("dbo.Options", new[] { "PollId" });

            DropForeignKey("dbo.Polls", "Poll_Id", "dbo.Polls");
            DropIndex("dbo.Polls", new[] { "Poll_Id" });

            DropColumn("dbo.Polls", "Poll_Id");

            CreateIndex("dbo.Options", "PollId");
            AddForeignKey("dbo.Options", "PollId", "dbo.Polls", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Options", "PollId", "dbo.Polls");
            DropIndex("dbo.Options", new[] { "PollId" });

            AddColumn("dbo.Polls", "Poll_Id", c => c.Int());
            CreateIndex("dbo.Polls", "Poll_Id");
            AddForeignKey("dbo.Polls", "Poll_Id", "dbo.Polls", "Id");

            CreateIndex("dbo.Options", "PollId");
            AddForeignKey("dbo.Options", "PollId", "dbo.Polls", "Id", cascadeDelete: true);
        }
    }
}
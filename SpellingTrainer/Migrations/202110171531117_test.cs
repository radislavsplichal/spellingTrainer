namespace SpellingTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "spellingTrainer.Cards",
                c => new
                    {
                        cardID = c.Int(nullable: false, identity: true),
                        cardLabel = c.String(),
                        cardSolutionBre = c.String(),
                        cardSolutionAme = c.String(),
                        cardCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cardID);
            
            CreateTable(
                "spellingTrainer.Users",
                c => new
                    {
                        userID = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        userEmail = c.String(),
                        userPassword = c.String(),
                    })
                .PrimaryKey(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropTable("spellingTrainer.Users");
            DropTable("spellingTrainer.Cards");
        }
    }
}

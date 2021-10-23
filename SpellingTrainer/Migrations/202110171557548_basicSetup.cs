namespace SpellingTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basicSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "spellingTrainer.Decks",
                c => new
                    {
                        deckID = c.Int(nullable: false, identity: true),
                        deckLabel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.deckID);
            
            AddColumn("spellingTrainer.Cards", "cardImagePath", c => c.String());
            AddColumn("spellingTrainer.Cards", "deck_deckID", c => c.Int(nullable: false));
            AlterColumn("spellingTrainer.Cards", "cardLabel", c => c.String(nullable: false));
            AlterColumn("spellingTrainer.Users", "userName", c => c.String(nullable: false));
            AlterColumn("spellingTrainer.Users", "userEmail", c => c.String(nullable: false));
            AlterColumn("spellingTrainer.Users", "userPassword", c => c.String(nullable: false));
            CreateIndex("spellingTrainer.Cards", "deck_deckID");
            AddForeignKey("spellingTrainer.Cards", "deck_deckID", "spellingTrainer.Decks", "deckID", cascadeDelete: true);
            DropColumn("spellingTrainer.Cards", "cardCategory");
        }
        
        public override void Down()
        {
            AddColumn("spellingTrainer.Cards", "cardCategory", c => c.Int(nullable: false));
            DropForeignKey("spellingTrainer.Cards", "deck_deckID", "spellingTrainer.Decks");
            DropIndex("spellingTrainer.Cards", new[] { "deck_deckID" });
            AlterColumn("spellingTrainer.Users", "userPassword", c => c.String());
            AlterColumn("spellingTrainer.Users", "userEmail", c => c.String());
            AlterColumn("spellingTrainer.Users", "userName", c => c.String());
            AlterColumn("spellingTrainer.Cards", "cardLabel", c => c.String());
            DropColumn("spellingTrainer.Cards", "deck_deckID");
            DropColumn("spellingTrainer.Cards", "cardImagePath");
            DropTable("spellingTrainer.Decks");
        }
    }
}

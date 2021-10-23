using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace SpellingTrainer
{
    class GameLibraryContext : DbContext
    {
        public GameLibraryContext() : base(nameOrConnectionString: "GameLibrary")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("spellingTrainer");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Deck> Decks { get; set; }

    }
}

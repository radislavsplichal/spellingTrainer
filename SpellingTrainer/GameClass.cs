using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SpellingTrainer
{
    public class GameClass
    {
        public List<string> questions { get; set; }
        public List<string> answers { get; set; }
        public Deck deck { get; set; }
        public string currentTestString;
        public string currentSolution;
        public char expectedChar;
        

        public void loadSelectedDeckFromDatabase(string deckLabel) {
            //load the deck number to the game
            using (var context = new GameLibraryContext())
            {
                var d = context.Decks
                             .Where(b => b.deckLabel.Contains(deckLabel))
                             ;
                deck.deckID = d.FirstOrDefault().deckID;
                deck.deckLabel = d.FirstOrDefault().deckLabel;
            }

        }

        public void loadQuestionsFromDatabase(Deck deckParam) {
            //load the cards from the given deck
            using (var context = new GameLibraryContext()) {
               var result = context.Cards
                                .Where(b => b.deck == deckParam).ToArray();
                foreach (Card a in result)
                {
                    questions.Add(a.cardLabel);
                    questions.Add(a.cardSolutionBre);
                }
            }
           
        }

        public void checkCharacters(char c,int position) {


        }

    }
}

//var allBooks = context.Books
//       .Where(b => b.Title.Contains("Fundamentals"))
//       .ToList();

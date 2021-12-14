using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SpellingTrainer.ExcelClasses;

namespace SpellingTrainer
{
    public class GameClass
    {
        public Dictionary<string,string> exercises = new Dictionary<string,string>();
        public DataTable exercisesDataTable = new DataTable();
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
                    exercises.Add(a.cardLabel,a.cardSolutionBre);
                }
            }
           
        }
        public DataTable loadQuestionsFromExcel(string path) {
            DataTable dt = new DataTable();
            ExcelClasses.excelLoaderClass ex = new excelLoaderClass();
            dt = ex.importDataFromFile(path);

            Console.WriteLine("EXCEL INPUT");
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr.ItemArray.GetValue(0).ToString());
                Console.WriteLine(dr.ItemArray.GetValue(1).ToString());
                Console.WriteLine(dr.ItemArray.GetValue(2).ToString());
                Console.WriteLine(dr.ItemArray.GetValue(3).ToString());
            }
            this.exercisesDataTable = dt;
            return dt;
        }
        public DataTable loadQuestionsFromCsv(string path)
        {
            DataTable dt = new DataTable();
            dt = csvLoaderClass.loadFromCSV(path);
            this.exercisesDataTable = dt;
            return dt;

        }
        public void checkCharacters(char c,int position) {


        }

    }
}

//var allBooks = context.Books
//       .Where(b => b.Title.Contains("Fundamentals"))
//       .ToList();

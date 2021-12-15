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
        public GameClass() {
            this.curCharPosition = 0;
            this.curDeckPosition = 0;
            this.changeCard = false;
            this.score = 0;
        }
        //Properties
        public Dictionary<string,string> exercises = new Dictionary<string,string>();
        public DataTable exercisesDataTable = new DataTable();
        public Deck deck { get; set; }
        public string currentTestString;
        public string currentSolution;
        public char expectedChar;
        public int curDeckPosition;
        public int curCharPosition;
        public int curDeckSize;
        public Boolean lastAnswer;
        public Boolean changeCard;
        public Boolean gameEnd;
        public int score;
        //Methods
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
            deckSize();
            return dt;
        }
        public DataTable loadQuestionsFromCsv(string path)
        {
            DataTable dt = new DataTable();
            dt = csvLoaderClass.loadFromCSV(path);
            this.exercisesDataTable = dt;
            deckSize();
            return dt;

        }
        public void loadNextWord() {
            var curRow = exercisesDataTable.Rows[curDeckPosition];
            this.currentTestString = curRow.ItemArray.GetValue(1).ToString();
            this.currentSolution = curRow.ItemArray.GetValue(2).ToString();
            if (curDeckPosition < curDeckSize)
            {
                curDeckPosition = curDeckPosition + 1;
            }
            else {
                gameEnd = true;
            }


        }
        public void deckSize() {
           this.curDeckSize = exercisesDataTable.Rows.Count;
        }
        public void checkCharacters(char c) {
            int p = this.curCharPosition;
            Console.WriteLine("Expected: " + (char)currentSolution[p] + " at possition "+p+" CS "+ (currentSolution.Length - 1));
            if (c == (char)currentSolution[p])
            {
                lastAnswer = true;
                score = score + 10;
                if (this.curCharPosition == currentSolution.Length - 1)
                {
                    this.curCharPosition = 0;
                    Console.WriteLine("NEXT ITEM!");
                    loadNextWord();
                    changeCard = true;
                }
                else {
                    this.curCharPosition++;
                }
                   
                
            }
            else
            {
                score = score - 5;
                lastAnswer = false;
            }

        }
        public string rmChar(string input) {
            string a = "";
            for (int i = 0; i < input.Length-1; i++)
            {
                 a = a + input[i];
            }
            return a;
        }
        public string addChar(string input)
        {

            return null;
        }

    }
}

//var allBooks = context.Books
//       .Where(b => b.Title.Contains("Fundamentals"))
//       .ToList();

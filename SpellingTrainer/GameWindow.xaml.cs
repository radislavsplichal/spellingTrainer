using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SpellingTrainer
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        GameClass gc;
        public GameWindow()
        {
            InitializeComponent();
            gc = new GameClass();
           
        }

        public GameWindow(GameClass gc)
        {
            InitializeComponent();
            this.gc = gc;
            this.gc.loadNextWord();
            solutionArea.Focus();
            taskLabel.Content = gc.currentTestString;
            

        }

        public void prepareGame(string deckLabel) {
            gc.loadSelectedDeckFromDatabase(deckLabel);
            gc.loadQuestionsFromDatabase(gc.deck);
        }
        public void setExercise() {
            solutionArea.Clear();
            solutionArea.Focus();
            taskLabel.Content = gc.currentTestString;
            
        }

        private void SolutionArea_KeyUp(object sender, KeyEventArgs e)
        {
            var a = "";
            var b = (char)42;

            switch (e.Key)
            {
                case Key.OemMinus:
                    b = (char)45;
                    break;
                case Key.OemQuotes:
                    b = (char)39;
                    break;
                case Key.Back:
                    return;
                    break;
                default:
                    a = e.Key.ToString();
                    a = a.ToLower();
                    b = a[0];
                    break;
            }
            Console.WriteLine(a);
            
            
            Console.WriteLine(b);
            gc.checkCharacters(b);
            
            if (gc.lastAnswer == true) {
                solutionArea.Background = Brushes.LightGreen;
                solutionCheck.Content = solutionArea.Text;
                if (gc.changeCard == true) {
                    setExercise();
                    gc.changeCard = false;
                }
            }
            else
            {
                solutionArea.Background = Brushes.Red;
                solutionArea.Text = gc.rmChar(solutionArea.Text);
            }
            Console.WriteLine("Current Deck Possition " + gc.curDeckPosition +"/"+gc.curDeckSize);
            scoreCounter.Content = gc.score.ToString();
            if (gc.gameEnd == true) {
                MessageBox.Show("Deck Completed! Your score: " + gc.score.ToString());
                this.Close();
            }
        }
    }
}

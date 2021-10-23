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
        public void prepareGame(string deckLabel) {
            gc.loadSelectedDeckFromDatabase(deckLabel);
            gc.loadQuestionsFromDatabase(gc.deck);
        }
        public void 
    }
}

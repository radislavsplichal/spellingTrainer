using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace SpellingTrainer
{
    /// <summary>
    /// Interaction logic for GameSelection.xaml
    /// </summary>
    public partial class GameSelection : Window
    {
        GameClass gc;
        Boolean windowLock;
        public GameSelection()
        {
            InitializeComponent();
            this.windowLock = false;
            gc = new GameClass();
            startGameButon.IsEnabled = false;
        }
        //excel import
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                FilePath.Text = openFileDialog.FileName;
            Console.WriteLine(FilePath.Text);
            gc.exercisesDataTable = this.gc.loadQuestionsFromExcel(FilePath.Text.ToString());
            DeckContent.ItemsSource = this.gc.exercisesDataTable.AsDataView() ;

            startGameButon.IsEnabled = true;
        }
        //csv import
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                FilePath_Csv.Text = openFileDialog.FileName;
            Console.WriteLine(FilePath_Csv.Text);
            gc.exercisesDataTable = gc.loadQuestionsFromCsv(FilePath_Csv.Text.ToString());
            DeckContent.ItemsSource = this.gc.exercisesDataTable.AsDataView();

            startGameButon.IsEnabled = true;
        }

        private void StartGameButon_Click(object sender, RoutedEventArgs e)
        {
            this.windowLock = true;
            //this.Visibility = Visibility.Hidden ;
            GameWindow gw = new GameWindow(this.gc);
            gw.ShowDialog();
            Console.WriteLine("Start button Fire");
            //reset the game class parameters.
            //this.Visibility = Visibility.Visible;
            this.windowLock = false;
            this.DeckContent.ItemsSource = null;
            this.startGameButon.IsEnabled = false;
            this.gc = new GameClass();
            
            Console.WriteLine("Reset");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (windowLock) {
                e.Cancel = true;
                Console.WriteLine("WindowClosing");
            }

         }
    }
}

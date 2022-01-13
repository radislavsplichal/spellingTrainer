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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpellingTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.versionNumber.Content = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            newChapterButton.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameSelection charSelect = new GameSelection();
            try
            {
                this.Visibility = Visibility.Hidden;
                charSelect.ShowDialog();
                
                Console.WriteLine("Selection end");
                this.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
            
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

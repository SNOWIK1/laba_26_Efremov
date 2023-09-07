using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace WPF_laba_26
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TB_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as FrameworkElement).Style = (Style)Resources["tb_search_off"];
        }

        private void TB_LostFocus(object sender, RoutedEventArgs e)
        {
            (sender as FrameworkElement).Style = (Style)Resources["tb_search_on"];
       
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            if (openFD.ShowDialog() == true)
            {
                
                using (StreamReader reader = new StreamReader(openFD.FileName))
                {
                    MainTB.Text = reader.ReadToEnd();
                }
            }
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFD = new SaveFileDialog()
            {
                Filter = "txt files (*.txt)|*.txt"
            };

            if (saveFD.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(saveFD.FileName))
                {
                   writer.WriteLine(MainTB.Text);
                }
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

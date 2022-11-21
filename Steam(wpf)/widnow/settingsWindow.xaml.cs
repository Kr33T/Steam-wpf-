using System;
using System.Collections.Generic;
using System.IO;
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

namespace Steam_wpf_.widnow
{
    /// <summary>
    /// Логика взаимодействия для settingsWindow.xaml
    /// </summary>
    public partial class settingsWindow : Window
    {
        public settingsWindow()
        {
            InitializeComponent();

            string path = Environment.CurrentDirectory;
            path = path.Replace("bin\\Debug", "settings.txt");
            string[] lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                string[] array = line.Split(';');
                startPageCB.SelectedIndex = Convert.ToInt32(array[0]);
            }
        }

        private void confirmSettingsBTN_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory;
            path = path.Replace("bin\\Debug", "settings.txt");
            StreamWriter sw = new StreamWriter(path, false);
            sw.WriteLine($"{startPageCB.SelectedIndex};");
            sw.Close();
            this.Close();
        }

        private void cancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

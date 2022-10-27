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

namespace Steam_wpf_
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Window
    {
        public main()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("aboba");
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            storeL.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void storeL_MouseLeave(object sender, MouseEventArgs e)
        {
            storeL.Foreground = new SolidColorBrush(Color.FromRgb(210, 210, 210));
        }

        void enter(object obj)
        {
            (Label)obj.
        }
    }
}

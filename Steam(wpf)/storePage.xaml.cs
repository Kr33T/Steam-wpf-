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

namespace Steam_wpf_
{
    /// <summary>
    /// Логика взаимодействия для storePage.xaml
    /// </summary>
    public partial class storePage : Page
    {
        public storePage()
        {
            InitializeComponent();
            genresList.ItemsSource = DBHelper.sE.genres.ToList();
        }
    }
}

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

namespace Steam_wpf_.page
{
    /// <summary>
    /// Логика взаимодействия для rightFrameOfLibrary.xaml
    /// </summary>
    public partial class rightFrameOfLibrary : Page
    {
        public rightFrameOfLibrary(userLibrary game)
        {
            InitializeComponent();
            gameNameTB.Text = DBHelper.sE.games.FirstOrDefault(x => x.idGame == game.idGame).gameName;
            playedTimeTB.Text = "Вы играли\n" + DBHelper.sE.userLibrary.FirstOrDefault(x => x.idGame == game.idGame && x.idUser == MainWindow.userId).userPlayedTime.ToString() + " ч.";
        }

        private void gameNameTB_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Не реализовано");
        }
    }
}

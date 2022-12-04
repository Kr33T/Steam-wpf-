using Steam_wpf_.page;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Steam_wpf_
{
    /// <summary>
    /// Логика взаимодействия для libraryPage.xaml
    /// </summary>
    public partial class libraryPage : Page
    {
        public libraryPage()
        {
            InitializeComponent();
            gamesLB.ItemsSource = DBHelper.sE.userLibrary.Where(x => x.idUser == MainWindow.userId).ToList();
            gamesLB.SelectedValuePath = "idGame";
            gamePresenterFrame.gamePresenter = gamePresenterF;
        }

        private void gamesLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (int)gamesLB.SelectedValue;
            userLibrary game = DBHelper.sE.userLibrary.FirstOrDefault(x => x.idGame == index);
            gamePresenterFrame.gamePresenter.Navigate(new rightFrameOfLibrary(game));
        }

        private void gameImageI_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as Image).Uid);

            games game = DBHelper.sE.games.FirstOrDefault(x => x.idGame == index);

            if (game.gameImage != null)
            {
                byte[] Barr = game.gameImage;
                BitmapImage Bim = new BitmapImage();
                using (MemoryStream MS = new MemoryStream(Barr))
                {
                    Bim.BeginInit();
                    Bim.StreamSource = MS;
                    Bim.CacheOption = BitmapCacheOption.OnLoad;
                    Bim.EndInit();
                }
                (sender as Image).Source = Bim;
                (sender as Image).Stretch = Stretch.Uniform;
            }
            else
            {
                string path = Environment.CurrentDirectory;
                path = path.Replace("bin\\Debug", "Resources\\empty.jpg");
                (sender as Image).Source = BitmapFrame.Create(new Uri(path));
            }
        }
    }
}

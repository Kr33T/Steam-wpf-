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
    /// Логика взаимодействия для storePage.xaml
    /// </summary>
    public partial class storePage : Page
    {
        public storePage()
        {
            InitializeComponent();
            gamesLV.ItemsSource = DBHelper.sE.games.ToList();
            gamesLV.SelectedValuePath = "idGame";

            listOfLanguages.ItemsSource = DBHelper.sE.languages.ToList();
            listOfLanguages.SelectedValuePath = "idLanguage";
            listOfLanguages.DisplayMemberPath = "languageName";

            listOfTags.ItemsSource = DBHelper.sE.tags.ToList();
            listOfTags.SelectedValuePath = "idTag";
            listOfTags.DisplayMemberPath = "tagName";

            listOfGenres.ItemsSource = DBHelper.sE.genres.ToList();
            listOfGenres.SelectedValuePath = "idGenre";
            listOfGenres.DisplayMemberPath = "genreName";

            orderCB.SelectedIndex = 0;
        }

        private void tags_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);

            List<tagsForGame> tagsList = DBHelper.sE.tagsForGame.Where(x => x.idGame == index).ToList();

            
        }

        private void gameNameTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);

            List<tagsForGame> tagsList = DBHelper.sE.tagsForGame.Where(x => x.idGame == index).ToList();
        }

        private void tags4Game_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as ListView).Uid);

            List<tagsForGame> tags = DBHelper.sE.tagsForGame.Where(x => x.idGame == index).ToList();
            while (tags.Count > 5)
            {
                tags.RemoveAt(tags.Count() - 1);
            }

            (sender as ListView).ItemsSource = tags;
        }

        private void gamesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (int)gamesLV.SelectedValue;

            games game = DBHelper.sE.games.FirstOrDefault(x => x.idGame == index);

            frameClass.mainFrame.Navigate(new gameInStore(game));
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

        private void gamePriceTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);

            games game = DBHelper.sE.games.FirstOrDefault(x => x.idGame == index);

            (sender as TextBlock).Text = game.gamePrice.ToString() + " руб.";
        }

        private void searchBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<games> games;

                if (!String.IsNullOrEmpty(searchTB.Text))
                {
                    games = DBHelper.sE.games.Where(x => x.gameName.ToLower().Contains(searchTB.Text.ToLower())).ToList();
                }
                else
                {
                    games = DBHelper.sE.games.ToList();
                }
                switch (orderCB.SelectedIndex)
                {
                    case 1:
                        switch (fieldCB.SelectedIndex)
                        {
                            case 0:
                                games = games.OrderByDescending(x => x.gameName).ToList();
                                break;
                            case 1:
                                games = games.OrderByDescending(x => x.gamePrice).ToList();
                                break;
                            case 2:
                                games = games.OrderByDescending(x => x.releaseDate).ToList();
                                break;
                        }
                        break;
                    case 2:
                        switch (fieldCB.SelectedIndex)
                        {
                            case 0:
                                games = games.OrderBy(x => x.gameName).ToList();
                                break;
                            case 1:
                                games = games.OrderBy(x => x.gamePrice).ToList();
                                break;
                            case 2:
                                games = games.OrderBy(x => x.releaseDate).ToList();
                                break;
                        }
                        break;
                }
                if (!String.IsNullOrEmpty(minPriceTB.Text))
                {
                    games = games.Where(x => x.gamePrice >= Convert.ToInt32(minPriceTB.Text)).ToList();
                }
                if (!String.IsNullOrEmpty(maxPriceTB.Text))
                {
                    games = games.Where(x => x.gamePrice <= Convert.ToInt32(maxPriceTB.Text)).ToList();
                }
                if (!String.IsNullOrEmpty(minPriceTB.Text) && !String.IsNullOrEmpty(maxPriceTB.Text))
                {
                    games = games.Where(x => x.gamePrice >= Convert.ToInt32(minPriceTB.Text) && x.gamePrice <= Convert.ToInt32(maxPriceTB.Text)).ToList();
                }

                gamesLV.ItemsSource = games;
                gamesLV.SelectedValuePath = "idGame";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так..\n" + ex.Message);
            }
        }

        private void orderCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (orderCB.SelectedIndex)
            {
                case 0:
                    fieldCB.Visibility = Visibility.Collapsed;
                    break;
                case 1:
                    fieldCB.Visibility = Visibility.Visible;
                    break;
                case 2:
                    fieldCB.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}

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
    /// Логика взаимодействия для listOfGamesUpdated.xaml
    /// </summary>
    public partial class listOfGamesUpdated : Page
    {
        List<games> gamesList = DBHelper.sE.games.ToList();

        public listOfGamesUpdated()
        {
            InitializeComponent();
            gamesLV.ItemsSource = gamesList;
            gamesLV.SelectedValuePath = "idGame";
        }

        private void ratingForGameTB_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void gamesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indexOfGame;
            indexOfGame = Convert.ToInt32(gamesLV.SelectedValue);

            gameDescriptionTB.Text = gamesList.Find(x => x.idGame == indexOfGame).gameDescription;

            publishersLV.ItemsSource = DBHelper.sE.publishersForGame.ToList().Where(x => x.idGame == indexOfGame);

            developersLV.ItemsSource = DBHelper.sE.developersForGame.ToList().Where(x => x.idGame == indexOfGame);
        }

        private void tagsLV_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as ListView).Uid);

            List<tagsForGame> tagsList = DBHelper.sE.tagsForGame.Where(x => x.idGame == index).ToList();

            (sender as ListView).ItemsSource = tagsList;
        }

        private void languagesLV_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as ListView).Uid);

            List<languagesForGame> languagesList = DBHelper.sE.languagesForGame.Where(x => x.idGame == index).ToList();

            (sender as ListView).ItemsSource = languagesList;
        }

        private void genresLV_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as ListView).Uid);

            List<genresForGame> genresList = DBHelper.sE.genresForGame.Where(x => x.idGame == index).ToList();

            (sender as ListView).ItemsSource = genresList;
        }
    }
}

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

        private void genreForGameTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);

            List<genresForGame> genreList = DBHelper.sE.genresForGame.Where(x => x.idGame == index).ToList();

            string genres = "жанры: ";

            for (int i = 0; i < genreList.Count; i++)
            {
                if(i == genreList.Count - 1)
                    genres += genreList[i].genres.genreName + ", ";
                else
                    genres += genreList[i].genres.genreName;
            }

            (sender as TextBlock).Text = genres;
        }

        private void languagesForGameTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);

            List<languagesForGame> languageList = DBHelper.sE.languagesForGame.Where(x => x.idGame == index).ToList();

            string languages = "языки: ";

            for (int i = 0; i < languageList.Count; i++)
            {
                if (i == languageList.Count - 1)
                    languages += languageList[i].languages.languageName + ", ";
                else
                    languages += languageList[i].languages.languageName;
            }

            (sender as TextBlock).Text = languages;
        }

        private void tagsForGameTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);

            List<tagsForGame> tagList = DBHelper.sE.tagsForGame.Where(x => x.idGame == index).ToList();

            string tags = "метки: ";

            for (int i = 0; i < tagList.Count; i++)
            {
                if (i != tagList.Count - 1)
                    tags += tagList[i].tags.tagName + ", ";
                else
                    tags += tagList[i].tags.tagName;
            }

            (sender as TextBlock).Text = tags;
        }

        private void ratingForGameTB_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void gamesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indexOfGame;
            indexOfGame = Convert.ToInt32(gamesLV.SelectedValue);

            gameDescriptionTB.Text = gamesList.Find(x => x.idGame == indexOfGame).gameDescription;

            listOfPublishersDG.ItemsSource = DBHelper.sE.publishersForGame.ToList().Where(x => x.idGame == indexOfGame);

            listOfDevelopersDG.ItemsSource = DBHelper.sE.developersForGame.ToList().Where(x => x.idGame == indexOfGame);
        }
    }
}

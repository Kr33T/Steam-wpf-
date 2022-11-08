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

        }
    }
}

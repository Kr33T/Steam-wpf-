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
    /// Логика взаимодействия для listOfGames.xaml
    /// </summary>
    public partial class listOfGames : Page
    {
        List<games> gamesList = DBHelper.sE.games.ToList();

        public listOfGames()
        {
            InitializeComponent();
            listOfGamesDG.ItemsSource = gamesList;
            listOfGamesDG.SelectedValuePath = "idGame";
        }

        private void listOfGamesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indexOfGame;
            indexOfGame = Convert.ToInt32(listOfGamesDG.SelectedValue);

            gameDescriptionTB.Text = gamesList.Find(x => x.idGame == indexOfGame).gameDescription;

            listOfPublishersDG.ItemsSource = DBHelper.sE.publishersForGame.ToList().Where(x => x.idGame == indexOfGame);

            listOfDevelopersDG.ItemsSource = DBHelper.sE.developersForGame.ToList().Where(x => x.idGame == indexOfGame);
        }
    }
}

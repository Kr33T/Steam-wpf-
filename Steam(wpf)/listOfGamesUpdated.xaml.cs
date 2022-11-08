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
            uint sum = 0;

            foreach (var item in gamesList)
            {
                sum += (uint)item.gamePrice;
            }

            totalCostTB.Text = "Общая стоимость: " + sum.ToString() + " руб.";
        }

        private void ratingForGameTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);

            List<reviews> reviews = DBHelper.sE.reviews.Where(x => x.idGame == index).ToList();

            int result = 0;

            if (reviews.Count() != 0)
            {
                int totalReviews = reviews.Count();
                int posReviewsK = reviews.Where(x => x.rating == true).Count();

                result = (int)(Math.Round(Convert.ToDouble(posReviewsK) / Convert.ToDouble(totalReviews), 2) * 100);

                (sender as TextBlock).Text = $"{result}% из {totalReviews} обзоров положительные";

                if (0 <= result && result <= 33)
                    (sender as TextBlock).Foreground = new SolidColorBrush(Color.FromRgb(163, 76, 37));
                else if (34 <= result && result <= 66)
                    (sender as TextBlock).Foreground = new SolidColorBrush(Color.FromRgb(185, 160, 116));
                else if (67 <= result && result <= 100)
                    (sender as TextBlock).Foreground = new SolidColorBrush(Color.FromRgb(102, 192, 244));
            }
            else
            {
                (sender as TextBlock).Text = $"Обзоров нет";
                (sender as TextBlock).Foreground = new SolidColorBrush(Color.FromRgb(163, 76, 37));
            }
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

        private void priceTB_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);

            games game = DBHelper.sE.games.FirstOrDefault(x=>x.idGame == index);

            Binding bind = new Binding();

            if (game.isDiscounted)
            {
                bind.Path = new PropertyPath("gamePriceWithDiscount");
                (sender as TextBlock).SetBinding(TextBlock.TextProperty, bind);
            }
            else
            {
                bind.Path = new PropertyPath("gamePriceUpd");
                (sender as TextBlock).SetBinding(TextBlock.TextProperty, bind);
            }
        }
    }
}

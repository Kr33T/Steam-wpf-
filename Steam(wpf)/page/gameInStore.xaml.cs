using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для gameInStore.xaml
    /// </summary>
    public partial class gameInStore : Page
    {
        games game;

        public gameInStore(games game)
        {
            InitializeComponent();
            this.game = game;

            gameDescriptionTB.Text = game.gameDescription;
            gameNameTB.Text = game.gameName;
            releaseDateTB.Text = game.releaseDate.ToString("dd MMM. yyyy");
            if (game.gamePrice != 0)
                gamePriceTB.Text = game.gamePrice.ToString() + " руб.";
            else
                gamePriceTB.Text = "Бесплатно";
            playInGameTB.Text = "Сыграть в " + game.gameName;
            List<genresForGame> gfg = DBHelper.sE.genresForGame.Where(x => x.idGame == game.idGame).ToList();

            string temp = "";
            foreach (var item in gfg)
            {
                temp += item.genres.genreName + ", ";
            }
            genresTB.Text = temp.Substring(0, temp.Length - 2);

            List<reviews> reviews = DBHelper.sE.reviews.Where(x => x.idGame == game.idGame).ToList();

            int result = 0;

            if (reviews.Count() != 0)
            {
                int totalReviews = reviews.Count();
                int posReviewsK = reviews.Where(x => x.rating == true).Count();

                result = (int)(Math.Round(Convert.ToDouble(posReviewsK) / Convert.ToDouble(totalReviews), 2) * 100);

                reviewsRateTB.Text = $"{result}% из {totalReviews} обзоров положительные";

                if (0 <= result && result <= 33)
                    reviewsRateTB.Foreground = new SolidColorBrush(Color.FromRgb(163, 76, 37));
                else if (34 <= result && result <= 66)
                    reviewsRateTB.Foreground = new SolidColorBrush(Color.FromRgb(185, 160, 116));
                else if (67 <= result && result <= 100)
                    reviewsRateTB.Foreground = new SolidColorBrush(Color.FromRgb(102, 192, 244));
            }
            else
            {
                reviewsRateTB.Text = $"Обзоров нет";
                reviewsRateTB.Foreground = new SolidColorBrush(Color.FromRgb(163, 76, 37));
            }

            List<developersForGame> dfg = DBHelper.sE.developersForGame.Where(x => x.idGame == game.idGame).ToList();

            temp = "";
            foreach (var item in dfg)
            {
                temp += item.developers.developerName + ", ";
            }
            developersTB.Text = temp.Substring(0, temp.Length - 2);

            List<publishersForGame> pfg = DBHelper.sE.publishersForGame.Where(x => x.idGame == game.idGame).ToList();

            temp = "";
            foreach (var item in pfg)
            {
                temp += item.publishers.publisherName + ", ";
            }
            publishersTB.Text = temp.Substring(0, temp.Length - 2);

            tagsLV.ItemsSource = DBHelper.sE.tagsForGame.Where(x => x.idGame == game.idGame).ToList();

            headerReviewTB.Text = "Написать обзор " + game.gameName;
            underHeaderTB.Text = "Пожалуйста, опишите, что вам понравилось или не понравилось в этой игре, и порекомендовали бы вы её другим.\nБудьте вежливы и придерживайтесь правил и рекомендаций.";
            reviewLV.ItemsSource = DBHelper.sE.reviews.ToList();
            reviewLV.SelectedValuePath = "idReview";

            users user = DBHelper.sE.users.FirstOrDefault(x => x.idUser == MainWindow.userId);
            List<userLibrary> userLib = DBHelper.sE.userLibrary.Where(x => x.idUser == user.idUser).ToList();
            bool gameIsAlreadyAdded = false;
            foreach (var item in userLib)
            {
                if(game.idGame == item.idGame)
                {
                    gameIsAlreadyAdded = true;
                    break;
                }
            }
            if (gameIsAlreadyAdded)
            {
                addToLibBTN.Content = "В библиотеке";
                addToLibBTN.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                addToLibBTN.IsEnabled = false;
            }
            if (game.gameImage != null)
            {
                string image = Environment.CurrentDirectory;
                image = image.Replace("bin\\Debug", "Resources\\" + game.gameImage);
                gameImageI.Source = BitmapFrame.Create(new Uri(image));
            }
        }

        private void publishBTN_Click(object sender, RoutedEventArgs e)
        {
            string review = new TextRange(reviewTextRTB.Document.ContentStart, reviewTextRTB.Document.ContentEnd).Text;
            
        }

        private void reviewLV_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users user = DBHelper.sE.users.FirstOrDefault(x => x.idUser == MainWindow.userId);
            userLibrary ul = new userLibrary()
            {
                idUser = user.idUser,
                idGame = game.idGame,
                userPlayedTime = 0
            };
            DBHelper.sE.userLibrary.Add(ul);
            DBHelper.sE.SaveChanges();
            addToLibBTN.Content = "В библиотеке";
            addToLibBTN.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            addToLibBTN.IsEnabled = false;
            MessageBox.Show("Игра в библиотеке");
        }
    }
}

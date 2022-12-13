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
using System.Drawing;
using Steam_wpf_.widnow;

namespace Steam_wpf_
{
    /// <summary>
    /// Логика взаимодействия для profilePage.xaml
    /// </summary>
    public partial class profilePage : Page
    {
        users user;
        public profilePage()
        {
            InitializeComponent();
            users user = DBHelper.sE.users.FirstOrDefault(x => x.idUser == MainWindow.userId);
            this.user = user;
            userNicknameTB.Text = user.nickname;
            gamesCountTB.Text = "Игр у пользователя: " + DBHelper.sE.userLibrary.Where(x => x.idUser == MainWindow.userId).ToList().Count.ToString();
            userFIOTB.Text =  user.userSurname + " " + user.userName + " " + user.userMidname;

            userGameCollectionLV.ItemsSource = DBHelper.sE.userLibrary.Where(x => x.idUser == user.idUser).ToList();
            userGameCollectionLV.SelectedValuePath = "idGame";

            if(user.userImage != null)
            {
                byte[] Barr = user.userImage;
                BitmapImage Bim = new BitmapImage();
                using (MemoryStream MS = new MemoryStream(Barr))
                {
                    Bim.BeginInit();
                    Bim.StreamSource = MS;
                    Bim.CacheOption = BitmapCacheOption.OnLoad;
                    Bim.EndInit();
                }
                userImageI.Source = Bim;
                userImageI.Stretch = Stretch.Uniform;
            }
            else
            {
                string path = Environment.CurrentDirectory;
                path = path.Replace("bin\\Debug", "Resources\\empty.jpg");
                userImageI.Source = BitmapFrame.Create(new Uri(path));
            }
        }

        private void updateProfileBTN_Click(object sender, RoutedEventArgs e)
        {
            frameClass.mainFrame.Navigate(new updateUser(user));
        }

        private void playedTime_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as TextBlock).Uid);
            (sender as TextBlock).Text = DBHelper.sE.userLibrary.FirstOrDefault(x=>x.idUser == MainWindow.userId && x.idGame == index).userPlayedTime + " ч. всего";
        }

        private void userGameCollectionLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = Convert.ToInt32(userGameCollectionLV.SelectedValue);
            games game = DBHelper.sE.games.FirstOrDefault(x => x.idGame == index);
            frameClass.mainFrame.Navigate(new gameInStore(game));
        }

        private void gameImagei_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as System.Windows.Controls.Image).Uid);

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
                (sender as System.Windows.Controls.Image).Source = Bim;
                (sender as System.Windows.Controls.Image).Stretch = Stretch.Uniform;
            }
            else
            {
                string path = Environment.CurrentDirectory;
                path = path.Replace("bin\\Debug", "Resources\\empty.png");
                (sender as System.Windows.Controls.Image).Source = BitmapFrame.Create(new Uri(path));
            }
        }

        private void openGalery_Click(object sender, RoutedEventArgs e)
        {
            userGaleryWindow window = new userGaleryWindow();
            window.Show();
                
            window.Closing += (obj, args) =>
            {
                if (user.userImage != null)
                {
                    byte[] Barr = user.userImage;
                    BitmapImage Bim = new BitmapImage();
                    using (MemoryStream MS = new MemoryStream(Barr))
                    {
                        Bim.BeginInit();
                        Bim.StreamSource = MS;
                        Bim.CacheOption = BitmapCacheOption.OnLoad;
                        Bim.EndInit();
                    }
                    userImageI.Source = Bim;
                    userImageI.Stretch = Stretch.Uniform;
                }
                else
                {
                    string path = Environment.CurrentDirectory;
                    path = path.Replace("bin\\Debug", "Resources\\empty.jpg");
                    userImageI.Source = BitmapFrame.Create(new Uri(path));
                }
            };
        }
    }
}

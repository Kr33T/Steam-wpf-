using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Windows.Shapes;

namespace Steam_wpf_.widnow
{
    /// <summary>
    /// Логика взаимодействия для userGaleryWindow.xaml
    /// </summary>
    public partial class userGaleryWindow : Window
    {
        public userGaleryWindow()
        {
            InitializeComponent();

            imagesLV.ItemsSource = DBHelper.sE.userGalery.Where(x => x.idUser == user.idUser).ToList();
            imagesLV.SelectedValuePath = "idGaleryPhoto";
        }

        users user = DBHelper.sE.users.FirstOrDefault(x => x.idUser == MainWindow.userId);

        private void ImageI_Loaded(object sender, RoutedEventArgs e)
        {
            int index = Convert.ToInt32((sender as System.Windows.Controls.Image).Uid);

            userGalery galery = DBHelper.sE.userGalery.FirstOrDefault(x=>x.idGaleryPhoto == index);

            byte[] Barr = galery.userImage;
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

        private void selectImageBTN_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)imagesLV.SelectedValue;

            userGalery galery = DBHelper.sE.userGalery.FirstOrDefault(x => x.idUser == user.idUser && x.idGaleryPhoto == index);

            user.userImage = galery.userImage;

            DBHelper.sE.SaveChanges();

            this.Close();
        }

        private void deleteImageBTN_Click(object sender, RoutedEventArgs e)
        {
            int index = (int)imagesLV.SelectedValue;

            userGalery galery = DBHelper.sE.userGalery.FirstOrDefault(x => x.idUser == user.idUser && x.idGaleryPhoto == index);

            DBHelper.sE.userGalery.Remove(galery);
            DBHelper.sE.SaveChanges();
            imagesLV.ItemsSource = DBHelper.sE.userGalery.Where(x => x.idUser == user.idUser).ToList();
            MessageBox.Show("Фото удалено");
        }

        private void addNewImageBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                string Path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(Path);
                ImageConverter ISC = new ImageConverter();
                byte[] Barray = (byte[])ISC.ConvertTo(SDI, typeof(byte[]));
                userGalery galery = new userGalery()
                {
                    idUser = user.idUser,
                    userImage = Barray
                };
                DBHelper.sE.userGalery.Add(galery);
                DBHelper.sE.SaveChanges();

                imagesLV.ItemsSource = DBHelper.sE.userGalery.Where(x => x.idUser == user.idUser).ToList();
                MessageBox.Show("Фото добавлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так\n" + ex.Message);
            }
        }

        private void cancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

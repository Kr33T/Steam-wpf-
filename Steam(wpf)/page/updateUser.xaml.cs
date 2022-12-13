using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace Steam_wpf_.page
{
    /// <summary>
    /// Логика взаимодействия для updateUser.xaml
    /// </summary>
    public partial class updateUser : Page
    {
        users user;
        public updateUser(users user)
        {
            InitializeComponent();
            this.user = user;

            profileNameTB.Text = user.nickname;
            userSurnameTB.Text = user.userSurname;
            userNameTB.Text = user.userName;
            userMidnameTB.Text = user.userMidname;
            userLoginTB.Text = user.userLogin;

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
                path = path.Replace("bin\\Debug", "Resources\\empty.png");
                userImageI.Source = BitmapFrame.Create(new Uri(path));
            }
        }

        string checkString(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return null;
            }
            else
            {
                return str;
            }
        }

        private void saveChangesBTN_Click(object sender, RoutedEventArgs e)
        {
            List<users> usersList = DBHelper.sE.users.Where(x => x.userLogin.Equals(userLoginTB.Text)).ToList();

            if (usersList.Count == 0)
            {
                user.userLogin = userLoginTB.Text;
                user.nickname = user.nickname;
                user.userSurname = checkString(userSurnameTB.Text);
                user.userName = checkString(userNameTB.Text);
                user.userMidname = checkString(userMidnameTB.Text);

                user.userImage = Barray;

                DBHelper.sE.SaveChanges();
                MessageBox.Show("Данные изменены");
                frameClass.mainFrame.Navigate(new profilePage());
            }
            else
            {
                MessageBox.Show("Аккаунт с таким логином уже зарегистрирован.");
            }
            
        }

        private void cancelBTN_Click(object sender, RoutedEventArgs e)
        {
            if (frameClass.mainFrame.CanGoBack)
            {
                frameClass.mainFrame.GoBack();
            }
        }

        private void savePasswordBTN_Click(object sender, RoutedEventArgs e)
        {
            if (oldPasswordPB.Password.GetHashCode().ToString().Equals(user.userPassword.ToString()))
            {
                if (!newPasswordPB.Password.Contains(" "))
                {
                    if (newPasswordPB.Password.Length >= 8)
                    {
                        if (Regex.IsMatch(newPasswordPB.Password, @"[A-Z]+"))
                        {
                            if (Regex.IsMatch(newPasswordPB.Password, @"(?=.[0-9]){2,}"))
                            {
                                if (Regex.IsMatch(newPasswordPB.Password, @"[a-z]+.*[a-z]+.*[a-z]"))
                                {
                                    if (Regex.IsMatch(newPasswordPB.Password, @"\W"))
                                    {
                                        if (newPasswordPB.Password.Equals(repeatPasswordPB.Password))
                                        {
                                            if(!newPasswordPB.Password.Equals(oldPasswordPB.Password))
                                            {
                                                user.userPassword = newPasswordPB.Password.GetHashCode().ToString();
                                                DBHelper.sE.SaveChanges();
                                                MessageBox.Show("Пароль изменен");
                                                oldPasswordPB.Password = "";
                                                newPasswordPB.Password = "";
                                                repeatPasswordPB.Password = "";
                                            }
                                            else
                                            {
                                                MessageBox.Show("Пароль совпадает со старым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Пароль не содержит спец.символа", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("В пароле менее 3 строчных латинских символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("В пароле содержатся менее двух цифр", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароль должен содержать заглавную букву", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль состоит менее, чем из 8 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Старый пароль указан неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        string path;
        byte[] Barray;

        private void userImageBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);
                ImageConverter ISC = new ImageConverter();
                Barray = (byte[])ISC.ConvertTo(SDI, typeof(byte[]));
                userImageI.Source = BitmapFrame.Create(new Uri(path));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так\n" + ex.Message);
            }

        }
    }
}

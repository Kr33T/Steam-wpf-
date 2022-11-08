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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Steam_wpf_
{
    /// <summary>
    /// Логика взаимодействия для registrationWindow.xaml
    /// </summary>
    public partial class registrationWindow : Window
    {
        public registrationWindow()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(loginTB.Text) || !String.IsNullOrEmpty(nicknameTB.Text) || !String.IsNullOrEmpty(passwordPB.Password) || !String.IsNullOrEmpty(repeatPB.Password))
            {
                var dialogRes = MessageBox.Show("Уверены, что хотите выйти?\nВведенные данные не сохранятся", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialogRes == MessageBoxResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            List<users> user = DBHelper.sE.users.ToList();
            if(!String.IsNullOrEmpty(loginTB.Text) && !String.IsNullOrEmpty(nicknameTB.Text) && !String.IsNullOrEmpty(passwordPB.Password) && !String.IsNullOrEmpty(repeatPB.Password))
            {
                if (user.Where(x => x.userLogin.Equals(loginTB.Text)).Count() == 0)
                {
                    if (!passwordPB.Password.Contains(" "))
                    {
                        if (passwordPB.Password.Length >= 8)
                        {
                            if(Regex.IsMatch(passwordPB.Password, @"[A-Z]+"))
                            {
                                if (Regex.IsMatch(passwordPB.Password, @"(?=.[0-9]){2,}"))
                                {
                                    if (Regex.IsMatch(passwordPB.Password, @"[a-z]+.*[a-z]+.*[a-z]"))
                                    {
                                        if (Regex.IsMatch(passwordPB.Password, @"\W"))
                                        {
                                            if (passwordPB.Password.Equals(repeatPB.Password))
                                            {
                                                users newUser = new users()
                                                {
                                                    nickname = nicknameTB.Text,
                                                    userBalance = 0,
                                                    userLogin = loginTB.Text,
                                                    userPassword = passwordPB.Password.GetHashCode().ToString(),
                                                    roleId = 2
                                                };
                                                DBHelper.sE.users.Add(newUser);
                                                DBHelper.sE.SaveChanges();

                                                MessageBox.Show("Регистрация прошла успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                                this.Close();
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
                    else
                    {
                        MessageBox.Show("Пароль содержит пробел, что недопустимо", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Указанное имя аккаунта уже занято, придумайте что-то другое", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Поля не заполнены!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

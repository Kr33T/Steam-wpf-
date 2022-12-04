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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Данные для входа администратора:
        //admin1232
        //321322
        public MainWindow()
        {
            InitializeComponent();
            DBHelper.sE = new steamEntities();
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            registrationWindow regWin = new registrationWindow();
            regWin.Show();
            this.Hide();

            regWin.Closed += (obj, args) =>
            {
                this.Show();
            };
        }

        public static int userRole;
        public static string userNickname;
        public static int userId;

        private void enterBtn_Click(object sender, RoutedEventArgs e)
        {
            List<users> user = DBHelper.sE.users.ToList();
            if(user.Where(x => x.userLogin.Equals(loginTB.Text) && x.userPassword.Equals(passwordPB.Password.GetHashCode().ToString())).Count() == 1)
            {
                userRole = (int)user.Where(x => x.userLogin.Equals(loginTB.Text) && x.userPassword.Equals(passwordPB.Password.GetHashCode().ToString())).First().roleId;
                userNickname = user.Where(x => x.userLogin.Equals(loginTB.Text) && x.userPassword.Equals(passwordPB.Password.GetHashCode().ToString())).First().nickname;
                userId = user.FirstOrDefault(x => x.userLogin.Equals(loginTB.Text) && x.userPassword.Equals(passwordPB.Password.GetHashCode().ToString())).idUser;
                main window = new main();
                window.Show();
                this.Hide();

                window.Closed += (obj, args) =>
                {
                    loginTB.Text = "";
                    passwordPB.Password = "";
                    this.Show();
                };
            }
            else
            {
                MessageBox.Show("Неверно введенны данные");
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void loginTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userRole = 1;
            userNickname = "admin";
            userId = 9;
            main window = new main();
            window.Show();
            this.Hide();

            window.Closed += (obj, args) =>
            {
                loginTB.Text = "";
                passwordPB.Password = "";
                this.Show();
            };
        }
    }
}

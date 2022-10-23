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

        private void enterBtn_Click(object sender, RoutedEventArgs e)
        {
            List<users> user = DBHelper.sE.users.ToList();
            if(user.Where(x => x.userLogin.Equals(loginTB.Text) && x.userPassword.Equals(passwordPB.Password.GetHashCode().ToString())).Count() == 1)
            {
                MessageBox.Show("Авторизация прошла успшено");
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
    }
}

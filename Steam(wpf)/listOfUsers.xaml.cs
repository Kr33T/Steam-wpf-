using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для listOfUsers.xaml
    /// </summary>
    public partial class listOfUsers : Page
    {
        public listOfUsers()
        {
            InitializeComponent();
            searchByField.SelectedIndex = 0;
            sortingBy.SelectedIndex = 0;
            listOfUsersDg.ItemsSource = usersList;
        }

        List<users> usersList = DBHelper.sE.users.ToList();
        List<users> usersTemp;

        bool order;

        void updDataGrid()
        {
            switch (sortingBy.SelectedIndex)
            {
                case 0:
                    order = true;
                    break;
                case 1:
                    order = false;
                    break;
            }
            switch (searchByField.SelectedIndex)
            {
                case 0:
                    usersTemp = usersList.Where(x => x.nickname.ToLower().Contains(searchTB.Text.ToLower())).ToList();
                    break;
                case 1:
                    usersTemp = usersList.Where(x => x.userLogin.ToLower().Contains(searchTB.Text.ToLower())).ToList();
                    break;
                case 2:
                    usersTemp = usersList.Where(x => x.userSurname.ToLower().Contains(searchTB.Text.ToLower())).ToList();
                    break;
                case 3:
                    usersTemp = usersList.Where(x => x.userName.ToLower().Contains(searchTB.Text.ToLower())).ToList();
                    break;
                case 4:
                    usersTemp = usersList.Where(x => x.userMidname.ToLower().Contains(searchTB.Text.ToLower())).ToList();
                    break;
            }
            if (order)
            {
                usersTemp = usersTemp.OrderBy(x => x.idUser).ToList();
            }
            else
            {
                usersTemp = usersTemp.OrderByDescending(x => x.idUser).ToList();
            }

            listOfUsersDg.ItemsSource = usersTemp;
            usersTemp = usersList.ToList();
        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            updDataGrid();
        }

        private void sortingBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updDataGrid();
        }

        private void clearParams_Click(object sender, RoutedEventArgs e)
        {
            searchByField.SelectedIndex = 0;
            sortingBy.SelectedIndex = 0;
            searchTB.Text = "";
            updDataGrid();
        }
    }
}

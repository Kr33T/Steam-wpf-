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

namespace Steam_wpf_
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Window
    {
        public main()
        {
            InitializeComponent();
            profileL.Content = MainWindow.userNickname;
            frameClass.mainFrame = mainFrame;
            if(MainWindow.userRole == 1)
            {
                adminItem.Visibility = Visibility.Visible;
            }
            else
            {
                adminItem.Visibility = Visibility.Collapsed;
            }
        }

        private void storeL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frameClass.mainFrame.Navigate(new storePage());
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }

        private void storeL_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseOut(sender);
        }

        void mouseEnter(object obj)
        {
            (obj as Label).Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        void mouseOut(object obj)
        {
            (obj as Label).Foreground = new SolidColorBrush(Color.FromRgb(210, 210, 210));
        }

        private void libraryL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frameClass.mainFrame.Navigate(new libraryPage());
        }

        private void profileL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frameClass.mainFrame.Navigate(new profilePage());
        }

        private void exitProg_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        private void exitAccount_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void openUserList_Click(object sender, RoutedEventArgs e)
        {
            frameClass.mainFrame.Navigate(new listOfUsers());
        }

        private void goBackL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (frameClass.mainFrame.CanGoBack)
                frameClass.mainFrame.GoBack();
        }

        private void goForwardL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (frameClass.mainFrame.CanGoForward)
                frameClass.mainFrame.GoForward();
        }

        private void goBackL_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }

        private void goForwardL_MouseEnter(object sender, MouseEventArgs e)
        {
            mouseEnter(sender);
        }

        private void goBackL_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseOut(sender);
        }

        private void goForwardL_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseOut(sender);
        }

        private void openGameList_Click(object sender, RoutedEventArgs e)
        {
            frameClass.mainFrame.Navigate(new listOfGamesUpdated());
        }
    }
}

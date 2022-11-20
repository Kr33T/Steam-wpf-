using Microsoft.Win32;
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

namespace Steam_wpf_.page
{
    /// <summary>
    /// Логика взаимодействия для gameEdit.xaml
    /// </summary>
    public partial class gameEdit : Page
    {
        games Game;
        bool editing;

        void loadingLists()
        {

            ListOfTagsLV.ItemsSource = DBHelper.sE.tags.ToList();
            ListOfTagsLV.SelectedValuePath = "idTag";
            ListOfTagsLV.DisplayMemberPath = "tagName";

            ListOfGenresLV.ItemsSource = DBHelper.sE.genres.ToList();
            ListOfGenresLV.SelectedValuePath = "idGenre";
            ListOfGenresLV.DisplayMemberPath = "genreName";

            ListOfDevelopersLV.ItemsSource = DBHelper.sE.developers.ToList();
            ListOfDevelopersLV.SelectedValuePath = "idDeveloper";
            ListOfDevelopersLV.DisplayMemberPath = "developerName";

            ListtOfPublishersLV.ItemsSource = DBHelper.sE.publishers.ToList();
            ListtOfPublishersLV.SelectedValuePath = "idPublisher";
            ListtOfPublishersLV.DisplayMemberPath = "publisherName";

            ListOfLanguagesLV.ItemsSource = DBHelper.sE.languages.ToList();
            ListOfLanguagesLV.SelectedValuePath = "idLanguage";
            ListOfLanguagesLV.DisplayMemberPath = "languageName";
        }

        public gameEdit()
        {
            InitializeComponent();

            actionBtn.Content = "Добавить";
            editing = false;
            loadingLists();
        }

        public gameEdit(int id)
        {
            InitializeComponent();

            actionBtn.Content = "Обновить";
            deleteBtn.Visibility = Visibility.Visible;
            editing = true;
            loadingLists();

            Game = DBHelper.sE.games.FirstOrDefault(x => x.idGame == id);
            gameNameTB.Text = Game.gameName;
            releaseDateDP.SelectedDate = Game.releaseDate;
            gamePriceTB.Text = Game.gamePrice.ToString();
            gameDescriptionTB.Text = Game.gameDescription;

            List<tagsForGame> tag = DBHelper.sE.tagsForGame.Where(x => x.idGame == id).ToList();

            foreach (tags item in ListOfTagsLV.Items)
            {
                if(tag.FirstOrDefault(x => x.idTag == item.idTag) != null)
                {
                    ListOfTagsLV.SelectedItems.Add(item);
                }
            }

            List<genresForGame> genre = DBHelper.sE.genresForGame.Where(x => x.idGame == id).ToList();

            foreach (genres item in ListOfGenresLV.Items)
            {
                if (genre.FirstOrDefault(x => x.idGenre == item.idGenre) != null)
                {
                    ListOfGenresLV.SelectedItems.Add(item);
                }
            }

            List<developersForGame> dev = DBHelper.sE.developersForGame.Where(x => x.idGame == id).ToList();

            foreach (developers item in ListOfDevelopersLV.Items)
            {
                if (dev.FirstOrDefault(x => x.idDeveloper == item.idDeveloper) != null)
                {
                    ListOfDevelopersLV.SelectedItems.Add(item);
                }
            }

            List<publishersForGame> pub = DBHelper.sE.publishersForGame.Where(x => x.idGame == id).ToList();

            foreach (publishers item in ListtOfPublishersLV.Items)
            {
                if (pub.FirstOrDefault(x => x.idPublisher == item.idPublisher) != null)
                {
                    ListtOfPublishersLV.SelectedItems.Add(item);
                }
            }

            List<languagesForGame> lng = DBHelper.sE.languagesForGame.Where(x => x.idGame == id).ToList();

            foreach (languages item in ListOfLanguagesLV.Items)
            {
                if (lng.FirstOrDefault(x => x.idLanguage == item.idLanguage) != null)
                {
                    ListOfLanguagesLV.SelectedItems.Add(item);
                }
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        string path;

        private void AddPic_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog OFD = new OpenFileDialog();
            //OFD.ShowDialog();
            //path = OFD.FileName;
            //string[] arrayPath = path.Split('\\');
            //path = "\\" + arrayPath[arrayPath.Length - 2] + "\\" + arrayPath[arrayPath.Length - 1];
            MessageBox.Show("Не реализовано");
        }

        private void actionBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (editing)
                {
                    Game.gameName = gameNameTB.Text;
                    Game.releaseDate = Convert.ToDateTime(releaseDateDP.SelectedDate);
                    Game.gamePrice = Convert.ToInt32(gamePriceTB.Text);
                    Game.gameDescription = gameDescriptionTB.Text;

                    List<tagsForGame> tag = DBHelper.sE.tagsForGame.Where(x => x.idGame == Game.idGame).ToList();
                    if (tag.Count > 0)
                    {
                        foreach (tagsForGame item in tag)
                        {
                            DBHelper.sE.tagsForGame.Remove(item);
                        }
                    }
                    foreach (tags item in ListOfTagsLV.SelectedItems)
                    {
                        tagsForGame tfg = new tagsForGame()
                        {
                            idGame = Game.idGame,
                            idTag = item.idTag
                        };
                        DBHelper.sE.tagsForGame.Add(tfg);
                    }

                    List<genresForGame> genre = DBHelper.sE.genresForGame.Where(x => x.idGame == Game.idGame).ToList();
                    if (genre.Count > 0)
                    {
                        foreach (genresForGame item in genre)
                        {
                            DBHelper.sE.genresForGame.Remove(item);
                        }
                    }
                    foreach (genres item in ListOfGenresLV.SelectedItems)
                    {
                        genresForGame gfg = new genresForGame()
                        {
                            idGame = Game.idGame,
                            idGenre = item.idGenre
                        };
                        DBHelper.sE.genresForGame.Add(gfg);
                    }

                    List<developersForGame> dev = DBHelper.sE.developersForGame.Where(x => x.idGame == Game.idGame).ToList();
                    if (dev.Count > 0)
                    {
                        foreach (developersForGame item in dev)
                        {
                            DBHelper.sE.developersForGame.Remove(item);
                        }
                    }
                    foreach (developers item in ListOfDevelopersLV.SelectedItems)
                    {
                        developersForGame dfg = new developersForGame()
                        {
                            idGame = Game.idGame,
                            idDeveloper = item.idDeveloper
                        };
                        DBHelper.sE.developersForGame.Add(dfg);
                    }

                    List<publishersForGame> pub = DBHelper.sE.publishersForGame.Where(x => x.idGame == Game.idGame).ToList();
                    if (pub.Count > 0)
                    {
                        foreach (publishersForGame item in pub)
                        {
                            DBHelper.sE.publishersForGame.Remove(item);
                        }
                    }
                    foreach (publishers item in ListtOfPublishersLV.SelectedItems)
                    {
                        publishersForGame pfg = new publishersForGame()
                        {
                            idGame = Game.idGame,
                            idPublisher = item.idPublisher
                        };
                        DBHelper.sE.publishersForGame.Add(pfg);
                    }

                    List<languagesForGame> lng = DBHelper.sE.languagesForGame.Where(x => x.idGame == Game.idGame).ToList();
                    if (lng.Count > 0)
                    {
                        foreach (languagesForGame item in lng)
                        {
                            DBHelper.sE.languagesForGame.Remove(item);
                        }
                    }
                    foreach (languages item in ListOfLanguagesLV.SelectedItems)
                    {
                        languagesForGame lfg = new languagesForGame()
                        {
                            idGame = Game.idGame,
                            idLanguage = item.idLanguage
                        };
                        DBHelper.sE.languagesForGame.Add(lfg);
                    }

                    DBHelper.sE.SaveChanges();
                    MessageBox.Show("Обновление успешно");
                }
                else
                {
                    Game = new games();
                    Game.gameName = gameNameTB.Text;
                    Game.releaseDate = Convert.ToDateTime(releaseDateDP.SelectedDate);
                    Game.gamePrice = Convert.ToInt32(gamePriceTB.Text);
                    Game.gameDescription = gameDescriptionTB.Text;

                    DBHelper.sE.games.Add(Game);

                    foreach (tags item in ListOfTagsLV.SelectedItems)
                    {
                        tagsForGame tag = new tagsForGame()
                        {
                            idGame = Game.idGame,
                            idTag = item.idTag
                        };
                        DBHelper.sE.tagsForGame.Add(tag);
                    }

                    foreach (genres item in ListOfGenresLV.SelectedItems)
                    {
                        genresForGame genre = new genresForGame()
                        {
                            idGame = Game.idGame,
                            idGenre = item.idGenre
                        };
                        DBHelper.sE.genresForGame.Add(genre);
                    }

                    foreach (developers item in ListOfDevelopersLV.SelectedItems)
                    {
                        developersForGame dfg = new developersForGame()
                        {
                            idGame = Game.idGame,
                            idDeveloper = item.idDeveloper
                        };
                        DBHelper.sE.developersForGame.Add(dfg);
                    }

                    foreach (publishers item in ListtOfPublishersLV.SelectedItems)
                    {
                        publishersForGame pfg = new publishersForGame()
                        {
                            idGame = Game.idGame,
                            idPublisher = item.idPublisher
                        };
                        DBHelper.sE.publishersForGame.Add(pfg);
                    }

                    foreach (languages item in ListOfLanguagesLV.SelectedItems)
                    {
                        languagesForGame lfg = new languagesForGame()
                        {
                            idGame = Game.idGame,
                            idLanguage = item.idLanguage
                        };
                        DBHelper.sE.languagesForGame.Add(lfg);
                    }

                    DBHelper.sE.SaveChanges();
                    MessageBox.Show("Запись добавлена");
                }
                frameClass.mainFrame.Navigate(new listOfGamesUpdated());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var res = MessageBox.Show("Вы уверены что хотите удалить игру?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if(res == MessageBoxResult.Yes)
            {
                List<tagsForGame> tag = DBHelper.sE.tagsForGame.Where(x => x.idGame == Game.idGame).ToList();
                if (tag.Count > 0)
                {
                    foreach (tagsForGame item in tag)
                    {
                        DBHelper.sE.tagsForGame.Remove(item);
                    }
                }

                List<genresForGame> genre = DBHelper.sE.genresForGame.Where(x => x.idGame == Game.idGame).ToList();
                if (genre.Count > 0)
                {
                    foreach (genresForGame item in genre)
                    {
                        DBHelper.sE.genresForGame.Remove(item);
                    }
                }

                List<developersForGame> dev = DBHelper.sE.developersForGame.Where(x => x.idGame == Game.idGame).ToList();
                if (dev.Count > 0)
                {
                    foreach (developersForGame item in dev)
                    {
                        DBHelper.sE.developersForGame.Remove(item);
                    }
                }

                List<publishersForGame> pub = DBHelper.sE.publishersForGame.Where(x => x.idGame == Game.idGame).ToList();
                if (pub.Count > 0)
                {
                    foreach (publishersForGame item in pub)
                    {
                        DBHelper.sE.publishersForGame.Remove(item);
                    }
                }

                List<languagesForGame> lng = DBHelper.sE.languagesForGame.Where(x => x.idGame == Game.idGame).ToList();
                if (lng.Count > 0)
                {
                    foreach (languagesForGame item in lng)
                    {
                        DBHelper.sE.languagesForGame.Remove(item);
                    }
                }

                DBHelper.sE.games.Remove(Game);
                DBHelper.sE.SaveChanges();
                MessageBox.Show("Игра удалена");
                frameClass.mainFrame.Navigate(new listOfGamesUpdated());
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (frameClass.mainFrame.CanGoBack)
                frameClass.mainFrame.GoBack();
        }
    }
}

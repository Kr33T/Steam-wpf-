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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Steam_wpf_
{
    /// <summary>
    /// Логика взаимодействия для advertisement.xaml
    /// </summary>
    public partial class advertisement : Window
    {
        public advertisement()
        {
            InitializeComponent();

            DoubleAnimation WA = new DoubleAnimation(); // создание объекта для настройки анимации
            WA.From = moreInfo.Width; // начальное значение свойства
            WA.To = moreInfo.Width + 120; // конечное значение свойства
            WA.Duration = TimeSpan.FromSeconds(2); // продолжительность анимации (в секундах)
            WA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            moreInfo.BeginAnimation(WidthProperty, WA); // «навешивание» анимации на свойство ширины кнопки

            DoubleAnimation HA = new DoubleAnimation(); // создание объекта для настройки анимации
            HA.From = moreInfo.Height; // начальное значение свойства
            HA.To = moreInfo.Height + 20; // конечное значение свойства
            HA.Duration = TimeSpan.FromSeconds(2); // продолжительность анимации (в секундах)
            HA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            HA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            moreInfo.BeginAnimation(HeightProperty, HA); // «навешивание» анимации на свойство ширины кнопки

            ColorAnimation BA = new ColorAnimation(); // создание объекта для настройки анимации
            ColorConverter CC = new ColorConverter(); // создание объекта для конвертации кода в цвет
            Color Cstart = (Color)CC.ConvertFrom("#3D4450"); // присваивание начального цвета эл-ту
            Color Cend = (Color)CC.ConvertFrom("#56627B"); // присваивание начального цвета эл-ту
            BA.From = Cstart; // начальное значение свойства
            BA.To = Cend; // конечное значение свойства
            BA.Duration = TimeSpan.FromSeconds(2);
            BA.AutoReverse = true;
            BA.RepeatBehavior = RepeatBehavior.Forever;
            moreInfo.Background.BeginAnimation(SolidColorBrush.ColorProperty, BA);

            ThicknessAnimation MA = new ThicknessAnimation(); // анимация границ
            MA.From = new Thickness(35, 0, 0, 0); 
            MA.To = new Thickness(70, 0, 0, 0);
            MA.Duration = TimeSpan.FromSeconds(2);
            MA.RepeatBehavior = RepeatBehavior.Forever;
            MA.AutoReverse = true;
            moreInfo.BeginAnimation(PaddingProperty, MA);

            DoubleAnimation FSA = new DoubleAnimation(); // создание объекта для настройки анимации
            FSA.From = moreInfo.FontSize; // начальное значение свойства
            FSA.To = moreInfo.FontSize + 8; // конечное значение свойства
            FSA.Duration = TimeSpan.FromSeconds(2); // продолжительность анимации (в секундах)
            FSA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            FSA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            moreInfo.BeginAnimation(FontSizeProperty, FSA); // «навешивание» анимации на свойство ширины кнопки

            DoubleAnimation WdA = new DoubleAnimation(); // создание объекта для настройки анимации
            WdA.From = atomic_heartIMG.Width; // начальное значение свойства
            WdA.To = atomic_heartIMG.Width + 15; // конечное значение свойства
            WdA.Duration = TimeSpan.FromSeconds(0.5); // продолжительность анимации (в секундах)
            WdA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WdA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            atomic_heartIMG.BeginAnimation(WidthProperty, WdA); // «навешивание» анимации на свойство ширины кнопки

            DoubleAnimation HtA = new DoubleAnimation(); // создание объекта для настройки анимации
            HtA.From = atomic_heartIMG.Height; // начальное значение свойства
            HtA.To = atomic_heartIMG.Height + 15; // конечное значение свойства
            HtA.Duration = TimeSpan.FromSeconds(0.5); // продолжительность анимации (в секундах)
            HtA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            HtA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            atomic_heartIMG.BeginAnimation(HeightProperty, HtA); // «навешивание» анимации на свойство ширины кнопки
        }

        private void closeAdWindowBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void moreInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Релиз состоится 21 февраля 2023г.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

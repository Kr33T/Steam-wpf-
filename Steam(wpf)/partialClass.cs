using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Steam_wpf_
{
    public partial class games
    {
        public string gamePriceUpd
        {
            get
            {
                return gamePrice + " руб.";
            }
        }

        public string gamePriceWithDiscount
        {
            get
            {
                return $"Скидка: {priceWithDiscount} руб.";
            }
        }

        public string releaseDateUpd
        {
            get
            {
                return releaseDate.ToString("dd MMM. yyyy");
            }
        }

        public SolidColorBrush discount
        {
            get
            {
                if (isDiscounted)
                {
                    return new SolidColorBrush(Color.FromRgb(185, 235, 22));
                }
                else
                {
                    return new SolidColorBrush(Color.FromRgb(136, 136, 136));
                }
            }
        }

    }
}

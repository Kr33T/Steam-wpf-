using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string releaseDateUpd
        {
            get
            {
                return releaseDate.ToString("dd MMM. yyyy");
            }
        }
    }
}

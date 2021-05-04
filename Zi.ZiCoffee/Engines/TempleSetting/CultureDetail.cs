using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.ZiCoffee.Engines.TempleSetting
{
    public class CultureDetail
    {
        public Image FlagIcon { get; set; }
        public string CultureChar { get; set; }
        public string LanguageName { get; set; }

        public CultureDetail(Image flagIcon, string cultureChar, string languageName)
        {
            FlagIcon = flagIcon;
            CultureChar = cultureChar;
            LanguageName = languageName;
        }
    }
}

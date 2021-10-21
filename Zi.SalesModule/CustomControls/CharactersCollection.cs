using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zi.SalesModule.CustomControls
{
    public class CharactersCollection
    {
        public string LowerLatinChars { get; set; }
        public string UpperLatinChars { get; set; }
        public string NumericChars { get; set; }
        public string LowerUnicodeChars { get; set; }
        public string UpperUnicodeChars { get; set; }
        public string UnicodeChars { get; set; }
        public string CommonSpecialChars { get; set; }
        public string BackSpaceChars { get; set; }

        public CharactersCollection()
        {
            LowerLatinChars = "abcdefghijklmnopqrstuvwxyz";
            UpperLatinChars = LowerLatinChars.ToUpper();
            NumericChars = "0123456789";
            LowerUnicodeChars = "aàảãáạăằẳẵắặâầẩẫấậdđeèẻẽéẹêềểễếệiìỉĩíịoòỏõóọôồổỗốộơờởỡớợuùủũúụưừửữứựyỳỷỹýỵ";
            UpperUnicodeChars = LowerUnicodeChars.ToUpper();
            UnicodeChars = LowerUnicodeChars + UpperUnicodeChars;
            CommonSpecialChars = "!@#$%^&*()_+-/,.';[]`<>?:|{}\"\\";
            BackSpaceChars = " ";
        }
    }
}

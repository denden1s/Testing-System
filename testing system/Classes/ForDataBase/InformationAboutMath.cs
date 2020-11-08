using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_system.Classes.ForDataBase
{
    class InformationAboutMath
    {
        public InformationAboutMath()
        { }

        public InformationAboutMath(string _name, string _content)
        {
            Name = _name;
            ThemeContent = _content;
        }
        public InformationAboutMath(int _themeID, string _name, string _content)
            : this(_name, _content)
        {
            ThemeID = _themeID;
            //Name = _name;
            //ThemeContent = _content;
        }
        public int ThemeID { get; set; }
        public string Name { get; set; }
        public string ThemeContent { get; set; }
    }
}
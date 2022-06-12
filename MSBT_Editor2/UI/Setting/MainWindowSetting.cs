using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalaxyText_Editor.UI.Setting
{
    public class MainWindowSetting
    {
        public static Dictionary<string,string> PictureFontListFromTxt{ get; private set; }
        
        public static void Initialize() 
        {
            PictureFontListFromTxt = new Dictionary<string, string>();
            GetPictureFontList();
        }

        private static void GetPictureFontList()
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);


            File.ReadAllText(filePath);
        }
    }
}

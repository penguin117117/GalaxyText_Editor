using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace FileSystemLibrary
{
    public interface IBasicDataInfo 
    {
        string Path { get; }
        string PathExtention { get;}
        string BinExtention { get; }
    }

    public class GalaxyMessageData_Modify 
    {
        private readonly IBasicDataInfo _basicDataInfo;
        public string OpenFile => Open();
        
        public GalaxyMessageData_Modify(IBasicDataInfo basicDataInfo) 
        {
            _basicDataInfo = basicDataInfo;

        }

        private string Open() 
        {
            return "OpenPath";
        }
    }

    public class FileDialogLibrary
    {
        internal readonly string[] fileExtentions = null;
        public enum DialogMode 
        {
            Open,
            Save
        }
        public FileDialogLibrary(string[] FileExtentions,DialogMode dialogMode) 
        {
            
            foreach (string str in FileExtentions) 
            {
                if (str.Length < 2) return;
                string top2 = str.Substring(0, 2);
                if (top2[0] != '.') return;
                if (Regex.IsMatch(str.Substring(1,str.Length-1), @"[^a-z0-9]")) return;
            }
            
            Console.WriteLine("Checked: Extention");

            fileExtentions = FileExtentions;
            
            
            if (dialogMode == DialogMode.Open) Console.WriteLine("Mode Open");
        }

        private void Test() 
        {
            
        }

    }
}

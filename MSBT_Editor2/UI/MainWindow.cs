using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FileSystemLibrary;
using GalaxyFileLibrary.FileExtentionType.MsbtData;

namespace GalaxyText_Editor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            string[] SupportExtentions = { ".msbt" };
            FileDialogLibrary fileDialogLibrary = new FileDialogLibrary(SupportExtentions,FileDialogLibrary.DialogMode.Open);

        }

        private string InitialDirectoryCheck() 
        {
            string InitialDirectory = Properties.Settings.Default.InitialDirectoryForOpenAndSave;
            if (InitialDirectory != string.Empty &&  Directory.Exists(InitialDirectory)) 
            {
                return InitialDirectory; 
            }
            return Application.StartupPath;
        }

        private void ToolStripMenuOpen_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.FileName = ofd.SafeFileName;
                ofd.InitialDirectory = InitialDirectoryCheck();
                ofd.Filter = "すべてのファイル(*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.Title = "ファイルを開く";
                ofd.RestoreDirectory = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                
                if (ofd.ShowDialog() == DialogResult.OK) 
                {
                    if (!IsSupportedFile(ofd.FileName)) 
                    {
                        
                        return;
                    }
                    Properties.Settings.Default.InitialDirectoryForOpenAndSave = Path.GetDirectoryName(ofd.FileName);
                    Properties.Settings.Default.Save();
                    Console.WriteLine(ofd.SafeFileName);
                } 
            };
        }

        private bool IsSupportedFile(string path) 
        {
            var Extension = Path.GetExtension(path).ToLower();
            switch (Extension) 
            {
                case ".msbt":
                    Msbt msbt = new Msbt(File.ReadAllBytes(path));
                    msbt.Load();
                    break;
                case ".msbf":
                    break;
                case ".arc":
                    break;
                default:
                    Console.WriteLine("ErrorLog:「" + Extension + "」Unsupported file");
                    return false;
            }
            Console.WriteLine("Log: " + "Supported file");
            return true;
        }
    }
}

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
using GalaxyFileLibrary.FileExtentionType.SectionDataSys.LBL1Data;

namespace GalaxyText_Editor {
    public partial class MainWindow : Form  {
    
        protected Msbt MsbtData { get; set; }

        public MainWindow() {
            InitializeComponent();
            //string[] SupportExtentions = { ".msbt" };
            //FileDialogLibrary fileDialogLibrary = new FileDialogLibrary(SupportExtentions, FileDialogLibrary.DialogMode.Open);
        }

        private string InitialDirectoryCheck() {

            string initialDirectory = Properties.Settings.Default.InitialDirectoryForOpenAndSave;

            if (initialDirectory != string.Empty && Directory.Exists(initialDirectory)) {
                return initialDirectory;
            }

            return Application.StartupPath;
        }

        private void ToolStripMenuOpen_Click(object sender, EventArgs e) {

            using (OpenFileDialog ofd = new OpenFileDialog()) {

                ofd.FileName = ofd.SafeFileName;
                ofd.InitialDirectory = InitialDirectoryCheck();
                ofd.Filter = "すべてのファイル(*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.Title = "ファイルを開く";
                ofd.RestoreDirectory = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;

                if (ofd.ShowDialog() != DialogResult.OK) {
                    return;
                }
                    
                if (!IsSupportedFile(ofd.FileName)){
                    return;
                }

                Properties.Settings.Default.InitialDirectoryForOpenAndSave = Path.GetDirectoryName(ofd.FileName);
                Properties.Settings.Default.Save();
                Console.WriteLine(ofd.SafeFileName);

            };
        }

        private bool IsSupportedFile(string path) {

            var extension = Path.GetExtension(path).ToLower();

            switch (extension)  {
                case ".msbt":
                    MsbtData = new Msbt(File.ReadAllBytes(path));
                    MsbtData.Load();

                    if (MsbtNameListBox.Items.Count != default) MsbtNameListBox.Items.Clear();
                    foreach(LabelNameEntry labelNameEntry in MsbtData.LBL1.LabelNameEntries.FromBinary)
                    MsbtNameListBox.Items.Add(labelNameEntry.LabelName);
                    break;
                case ".msbf":
                    break;
                case ".arc":
                    break;
                default:
                    Console.WriteLine("ErrorLog:「" + extension + "」Unsupported file");
                    return false;
            }

            Console.WriteLine("Log: " + "Supported file");
            return true;
        }
    }
}

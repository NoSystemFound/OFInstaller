using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace OFInstaller
{
    public partial class configurator : Form
    {
        public configurator()
        {
            InitializeComponent();
        }
        string fileName;

        private void button1_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.ShowHiddenItems = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBox1.Text = dialog.FileName;
                fileName = dialog.FileName;
            }
            else
            {
                fileName = "";
            }
        }

        private void configurator_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string archive = "assets.zip";
            string targetdir = "tmp";
            ZipFile.ExtractToDirectory(archive, targetdir);
            string[] paths = Directory.GetFiles(targetdir);
            Directory.CreateDirectory("OFvers");
            foreach (string file in paths)
            {
                Thread.Sleep(50);
                File.Copy(file, file.Replace("tmp\\", "OFvers\\"));
                progressBar1.PerformStep();
            }
            Directory.Delete(targetdir, true);
            File.Create("config.txt").Close();
            using (var sw = new StreamWriter("config.txt"))
            {
                sw.WriteLine(fileName);
                sw.Close();
            }
            this.Close();
            System.Diagnostics.Process.Start("OFInstaller 1.1.exe");
        }
    }
}

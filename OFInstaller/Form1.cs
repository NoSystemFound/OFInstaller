using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack;

namespace OFInstaller
{
    public partial class OFInstaller : Form
    {
        public OFInstaller()
        {
            InitializeComponent();
        }
        funcs cls = new funcs();
        //OF versions array
        string[] folders = Directory.GetDirectories("C:\\Users\\HyperWin\\curseforge\\minecraft\\Instances\\"); //Array with builds
        public void Form1_Load(object sender, EventArgs e)
        {
            //Preparing logs
            cls.logPrepare();
            string usr = Environment.GetEnvironmentVariable("username");
            string logPath = "C:\\Users\\" + usr + "\\Desktop\\log.txt";
            cls.logWrite("Log write tool initialized");
            if (folders != null)
            {
                cls.logWrite("Saved folder list");
            }
            else
            {
                cls.logWrite("Cannot save folder list");
            }
            foreach (string input in folders)
            {
                string name = input.Replace("C:\\Users\\HyperWin\\curseforge\\minecraft\\Instances\\", String.Empty);
                listBox1.Items.Add(name);
            }
        }
        public string selectedOFVer;

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item first!");
            }
            else
            {
                int select = listBox1.SelectedIndex; cls.logWrite("Saved selected build"); //Saving selected build
                string manifestPath = folders[select] + "\\manifest.json"; cls.logWrite("Created manifest path"); //Building manifest path
                string buildVersion = File.ReadLines(manifestPath).Skip(2).FirstOrDefault(); cls.logWrite("Manifest read success"); //Reading line 3, where build version located
                buildVersion = buildVersion.Replace("\"version\": \"", String.Empty); buildVersion = buildVersion.Remove(buildVersion.Length - 2); buildVersion = buildVersion.Replace(" ", ""); buildVersion = "OFvers\\of_" + buildVersion + ".jar"; cls.logWrite("buildVersion var ready"); //Extracting build version
                string targetOFFilePath = folders[select] + "\\mods\\" + buildVersion.Replace("OFvers\\", String.Empty); cls.logWrite("Mods folder path built"); //Building mods folder path
                File.Copy(buildVersion, targetOFFilePath, true); cls.logWrite("OF version installed"); //Installing selected OF version
            }
        }
        public void msg(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}

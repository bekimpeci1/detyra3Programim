using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Detyra3Programim
{
    public partial class Form1 : Form
    {
        string filePath;
        ReadWrite fileRead = new ReadWrite();
        ReadWrite fileWrite = new ReadWrite();
        KeyBoardShortcut keyPad = new KeyBoardShortcut();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            keyPad.BrowseKey(e, btnBrowse);
            keyPad.ReadKey(e, btnRead);
            keyPad.SaveKey(e, btnSave);
        }


        private void btnRead_Click(object sender, EventArgs e)
        {
            filePath = @"" + txtFile.Text;
            fileRead.ReadFileText(filePath,txtEditor);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            filePath = @"" + txtFile.Text;
            fileWrite.WriteOnFile(filePath, txtEditor);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string UserNamePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            FileDialog(UserNamePath);

        }
        private void FileDialog (string userNamePath)
        {
            browseDialog.InitialDirectory = userNamePath + @"\desktop";
            browseDialog.RestoreDirectory = true;
            browseDialog.Filter = "txt Files(*.txt)|*.txt";
            browseDialog.FileName = "";
            browseDialog.ShowDialog();
            try
            {          
                filePath = @"" +  browseDialog.FileName;
                txtFile.Text = filePath;
                txtEditor.Text = File.ReadAllText(filePath);// + Environment.NewLine;
            }
            catch (Exception)
            {

                MessageBox.Show("Ju lutem selektoni nje File");
            }
        }

      
    }
}

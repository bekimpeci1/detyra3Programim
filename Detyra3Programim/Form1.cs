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
        /// <summary>
        /// Krijohen instanca te klasave, ne menyr qe te kryhet
        /// Leximi, Shrkimi dhe gjithashtu te krijohen shortcut-e 
        /// per qasje te elementeve me ane te tastieres
        /// </summary>
        string filePath;
        ReadWrite fileRead = new ReadWrite();
        ReadWrite fileWrite = new ReadWrite();
        KeyBoardShortcut keyPad = new KeyBoardShortcut();
        
        public Form1()
        {
            InitializeComponent();
         

        }


        #region Evnetet
        /// <summary>
        /// Me posht gjendet Event-i i cili e ben te mendur
        /// Dhe ne te gjinden metodat te cilat s
        /// </summary>
        /// <param btn="button">Parametri i par tregon butonin i cili klikohet
        /// nepermjet  shortcut-i i cakuar</param>
        /// <param keyEvent="e">Tregon eventin i cili do te ndodh</param>
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
          
            //P.Sh. Butoni btnBrowse hapet kur klikohet Ctrl+B
            keyPad.BrowseKey(btnBrowse,e);
            keyPad.ReadKey(btnRead,e);
            keyPad.SaveKey(btnSave,e);
            keyPad.CloseKey(btnClosee, e);
        }

        //Merr vendodhjen e e file-it qe shfrytezuesi deshiron ta shoh
        //Dhe te gjithe tekstin e merr dhe e shonon ne RichTextBox
        private void btnRead_Click(object sender, EventArgs e)
        {
            filePath = @"" + txtFile.Text;
            fileRead.ReadFileText(filePath, richTxtEditor);

        }
        //Merr vendodhjen e e file-it qe shfrytezuesi deshiron ta ruaj ndryshimet
        //Dhe te gjithe tekstin e merr nga RichTextBox dhe e vendos ne file-in perkates 
        private void btnSave_Click(object sender, EventArgs e)
        {
            filePath = @"" + txtFile.Text;
            fileWrite.WriteOnFile(filePath, richTxtEditor);
        }
        //mundeson qe te hapet nje dialog ku shfrytezuesi zgjedh file-in qe deshiron
        //ta hap
        //fillimisht, direktoriumi qe do hapet pas klikimit
        //do te jete Desktop, ku dhe me pastaj
        //shfrytezuesi mund te navigoj neper direktoriume te tjera
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string UserNamePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            FileDialog(UserNamePath);

        }
        //Mundeson mbylljen e Formes
        private void btnClosee_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion


        #region Metodat
        /// <summary>
        /// Ben shfaqjen e dilaogun per hapje te file-it
        /// Ne dialog do te shfaqen vetem file-it te tipit "txt"(text)
        /// Dhe me pastaj pas zgjedhjes se file-it, teksti i cili 
        /// gjindet ne ate file vendoset ne RichTextBox
        /// Ku dhe ne mund te fillojm edit-imin e atij teksti
        /// </summary>
        /// <param name="userNamePath"> merr direktoriumin e User-it
        /// i cili per momentin eshte aktiv</param>
        private void FileDialog (string userNamePath)
        {
            browseDialog.RestoreDirectory = true;
            browseDialog.InitialDirectory = userNamePath + @"\desktop";
            browseDialog.ValidateNames = true;
            browseDialog.Filter = "txt Files(*.txt)|*.txt";
            browseDialog.FileName = "";
            browseDialog.ShowDialog();
            try
            {          
                filePath = @"" +  browseDialog.FileName;
                txtFile.Text = filePath;
                richTxtEditor.Text = File.ReadAllText(filePath);// + Environment.NewLine;
            }
            //Nese shfrytezuesi mbyll dialogun pa zgjedhur ne file, shfaqet MSGBox
            catch (Exception)
            {

                MessageBox.Show("Ju lutem selektoni nje File");
            }
        }





        #endregion

       
    }
}

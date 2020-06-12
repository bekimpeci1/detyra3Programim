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
using System.Text.RegularExpressions;

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
        /// <param keyEvent="e">Emri i keyEventit, te cilin do e perdorim per
        /// te shiquar se a jane mbushur kushtet ne if statements
        /// qe jane vendosur ne klasen KeyBoardShortcut</param>
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {

            //P.Sh. Butoni btnBrowse hapet kur klikohet Ctrl+B
            keyPad.CancelKey(btnCancel, e);
            keyPad.BrowseKey(btnBrowse, e);
            keyPad.ReadKey(btnRead, e);
            keyPad.SaveKey(btnSave, e);
            keyPad.SearchKey(btnSearch, e, txtSearch, errorProvider1);
            keyPad.CountKey(btnCount, e, txtCount, errorProvider1);

        }

        //Merr vendodhjen e e file-it qe shfrytezuesi deshiron ta shoh
        //Dhe te gjithe tekstin e merr dhe e shonon ne RichTextBox
        private void btnRead_Click(object sender, EventArgs e)
        {
            filePath = @"" + txtFile.Text;
            if (!String.IsNullOrEmpty(File.ReadAllText(filePath)))
            {
                try
                {
                    txtFile.Text = filePath;
                    richTxtEditor.Text = File.ReadAllText(filePath);
                }
                catch (Exception)
                {

                    MessageBox.Show("Ju lutem zgjedhni nje file");
                }

            }
            else
            {
                MessageBox.Show("File-i nuk mund te jete i zbrazet");
            }
        }




        //Merr vendodhjen e e file-it qe shfrytezuesi deshiron ta ruaj ndryshimet
        //Dhe te gjithe tekstin e merr nga RichTextBox dhe e vendos ne file-in perkates 
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                filePath = @"" + txtFile.Text;
                fileWrite.WriteOnFile(filePath, richTxtEditor);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        //mundeson qe te hapet nje dialog ku shfrytezuesi zgjedh file-in qe deshiron
        //ta hap
        //fillimisht, direktoriumi qe do hapet pas klikimit
        //do te jete Desktop, ku dhe me pastaj
        //shfrytezuesi mund te navigoj neper direktoriume te tjera
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                string UserNamePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                FileDialog(UserNamePath);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        //Mundeson mbylljen e Formes
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnCount_Click(object sender, EventArgs e)
        {
            int totaliIShkronjave = 0;
            string tekstiIPerzgjedhur;
            try
            {
                if (txtCount.Text == "")
                {
                    throw new ValueEmptyException();
                }
                else
                {
                    Regex shkronjaRegex = new Regex(@"[a-za-z]");
                    tekstiIPerzgjedhur = txtCount.Text;
                    for (int i = 0; i < tekstiIPerzgjedhur.Length; i++)
                    {
                        string prova = tekstiIPerzgjedhur[i].ToString();
                        Match matchShkronja = shkronjaRegex.Match(prova);
                        if (matchShkronja.Success)
                        {
                            totaliIShkronjave++;
                        }

                    }
                    double totaliIShkronjaveNePerqindje = (Convert.ToDouble(totaliIShkronjave) / (tekstiIPerzgjedhur.Length) * 100);
                    pbCountResults.Value = Convert.ToInt32(totaliIShkronjaveNePerqindje);
                    lblResult.Text = "Totali i shkronjave te perdorura eshte: " + totaliIShkronjave;
                    lblProgress.Text = Math.Round(totaliIShkronjaveNePerqindje) + "% e tekstit eshte e perbere nga shkronjat";
                    lblProgress.Visible = true;
                    pbCountResults.Visible = true;
                }

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Ju lutem shkruani para se the shtypni buttonin");
            }

            catch (ValueEmptyException ex)
            {
                MessageBox.Show(ex.Message);
                txtSearch.Focus();
                errorProvider1.SetError(txtCount, "Fusha duhet te jete e plotesuar");
            }






        }

        int VleraFillestare = 0;
        int counter = 0;


        private void btnSearch_Click(object sender, EventArgs e)
        {




            try
            {
                if (txtSearch.Text == "")
                {
                    throw new ValueEmptyException();

                }
                else if (richTxtEditor.Text == "")
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    int returnValue = richTxtEditor.Find(txtSearch.Text, VleraFillestare, RichTextBoxFinds.MatchCase);
                    richTxtEditor.Find(txtSearch.Text, VleraFillestare, richTxtEditor.TextLength, RichTextBoxFinds.MatchCase);
                    richTxtEditor.BackColor = Color.White;
                    richTxtEditor.SelectionBackColor = Color.Red;

                    VleraFillestare = VleraFillestare + 1;
                    VleraFillestare = richTxtEditor.Text.IndexOf(txtSearch.Text, VleraFillestare) + 1;

                    if (returnValue > 0)
                    {

                        counter++;
                    }

                    if (returnValue < 0)
                    {
                        if (counter > 0)
                        {
                            MessageBox.Show("Teksti u gjend gjithsej " + counter + " here");
                            counter = 0;
                        }
                        else if (counter <= 0)
                        {
                            MessageBox.Show("Teksti nuk u gjet");
                            counter = 0;


                        }
                    }
                }

            }
            catch (ValueEmptyException ex)
            {
                MessageBox.Show(ex.Message);
                txtSearch.Focus();
                errorProvider1.SetError(txtSearch, "Fusha duhet te jete e plotesuar");
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show("Ju lutem plotesoni text editorin per te filluar kerkimin");
            }


        }
        #endregion


        #region Metodat
        /// <summary>
        /// Ben shfaqjen e dilaogun per hapje te file-it
        /// si fillim gjithmon direktoriumin fillestar e ka desktop-in
        /// e shfrytezuesit
        /// Ne dialog do te shfaqen vetem file-it te tipit "txt"(text)
        /// Dhe me pastaj pas zgjedhjes se file-it, teksti i cili 
        /// gjindet ne ate file vendoset ne RichTextBox
        /// Ku dhe ne mund te fillojm edit-imin e atij teksti
        /// </summary>
        /// <param name="userNamePath"> merr direktoriumin e User-it
        /// i cili per momentin eshte aktiv</param>
        private void FileDialog(string userNamePath)
        {
            browseDialog.InitialDirectory = userNamePath + @"\desktop";
            browseDialog.RestoreDirectory = true;
            browseDialog.Filter = "txt Files(*.txt)|*.txt";
            browseDialog.FileName = "";
            browseDialog.ShowDialog();
            filePath = @"" + browseDialog.FileName;

            if (!String.IsNullOrEmpty(File.ReadAllText(filePath)))
            {
                try
                {
                    txtFile.Text = filePath;
                    richTxtEditor.Text = File.ReadAllText(filePath);
                }
                catch (Exception)
                {

                    MessageBox.Show("Ju lutem zgjedhni nje file");
                }

            }
            else
            {
                MessageBox.Show("File-i nuk mund te jete i zbrazet");
            }
        }
        //Nese shfrytezuesi mbyll dialogun pa zgjedhur ne file, shfaqet MSGBox

    }
}







        #endregion

       
    



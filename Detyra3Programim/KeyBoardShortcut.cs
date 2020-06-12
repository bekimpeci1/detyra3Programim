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


    class KeyBoardShortcut
    {
        /// <summary>
        /// Kodet e me poshtme mundesojn qe ndermjet tastieres ne te mund 
        /// te i klikojm butonet
        /// </summary>
        /// <param name="btn">Zgjedhet butoni ne te cilin do te perdoret shortvut </param>
        /// <param name="e"></param>

        //Perdoret System.Windows.Forms para KeyEventArgs
        //Per arsye se krijohet nje konflikt ne mes
        //System.Windows.Forms.KeyEventArgs dhe using System.Windows.Input;
        //Pasi qe te dyjat kan KeyEventArgs
        //Dhe ne menyr qe t'i shmangemi ketij konflikti
        //specifikohet ne kete menyre
        public void BrowseKey(Button btn, KeyEventArgs e)
        {
            //e.Control --> Shiqon se a eshte shtyper Ctrl
            if (e.Control && e.KeyCode == Keys.B)
            {
                //Ben klikimin e butonit te caktuar ne parametra
                btn.PerformClick();
            }

        }
        public void ReadKey(Button btn, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                btn.PerformClick();
            }
        }
        public void SaveKey(Button btn, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btn.PerformClick();
            }
        }
        public void CancelKey(Button btn, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.K)
            {
                btn.PerformClick();
            }
        }
        public void SearchKey(Button btn, KeyEventArgs e, TextBox txtBox, ErrorProvider err1)
        {


            if (e.Shift && e.KeyCode == Keys.S)
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtBox.Text))
                    {
                        string teksti = txtBox.Text.Remove(txtBox.Text.Length - 1, 1);
                        txtBox.Text = teksti;
                        btn.PerformClick();
                    }
                    else
                    {
                        throw new ValueEmptyException();

                    }
                }

                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show("Ju lutem plotesoni text editorin per te filluar kerkimin");
                }
                catch (ValueEmptyException ex)
                {
                    MessageBox.Show(ex.Message);
                    txtBox.Focus();
                    err1.SetError(txtBox, "Fusha duhet te jete e plotesuar");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

        }
        public void CountKey(Button btn, KeyEventArgs e, TextBox txtBox, ErrorProvider err1)
        {


            if (e.Shift && e.KeyCode == Keys.C)
            {
                try
                {
                    if (!String.IsNullOrEmpty(txtBox.Text))
                    {
                        string teksti = txtBox.Text.Remove(txtBox.Text.Length - 1, 1);
                        txtBox.Text = teksti;
                        btn.PerformClick();
                    }
                    else
                    {
                        throw new ValueEmptyException();
                    }
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Ju lutem shkruani para se the shtypni buttonin");
                }

                catch (ValueEmptyException ex)
                {
                    MessageBox.Show(ex.Message);
                    txtBox.Focus();
                    err1.SetError(txtBox, "Fusha duhet te jete e plotesuar");
                }

            }
        }

    }
}


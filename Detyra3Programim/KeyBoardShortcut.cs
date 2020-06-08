using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



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
    }

}


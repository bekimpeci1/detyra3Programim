using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace Detyra3Programim
{
 
   
    class KeyBoardShortcut
    {
        
        public void BrowseKey(KeyEventArgs e,Button btn)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                btn.PerformClick();
            }
        }
        public void ReadKey (KeyEventArgs e, Button btn)
        {
            if (e.Control && e.KeyCode == Keys.R)
            {
                btn.PerformClick();
            }
        }
        public void SaveKey(KeyEventArgs e, Button btn)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btn.PerformClick();
            }
        }
    }

    }


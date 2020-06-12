using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Detyra3Programim
{
    class ReadWrite
    {
        /// <summary>
        /// Metodat e me poshtme mundesojne
        /// Leximin dhe Shkrimin e File-ve te perzgjedhur
        /// </summary>
        /// <param name="path">Tregon adresen se ku mund te gjindet ai File</param>
        /// <param name="txtBox">Tregon se ne cilin RichTextBox te shenohet
        /// Permbajtja e atij File-i</param>
        public void ReadFileText(string path, RichTextBox txtBox)
        {
            
            try
            {
                //Encoding.UTF8 --> Tregon tipin e enkodimit i cili perdoret ne
                //File-in ne te cilin deshirojme te manipulojm
                string[] fileText = File.ReadAllLines(path, Encoding.UTF8);
                //Shton cdo rresht ne fileText ne RichTexBox
                foreach (string line in fileText)
                {
                    txtBox.Text += line + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        public void WriteOnFile(string path, RichTextBox txtBox)
        {
            try
            {
                File.WriteAllText(path, txtBox.Text);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }




        }
    }
}

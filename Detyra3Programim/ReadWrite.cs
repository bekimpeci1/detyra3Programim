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
        public void ReadFileText(string path, TextBox txtBox)
        {
            try
            {
            string[] fileText = File.ReadAllLines(path, Encoding.UTF8);
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
        public void WriteOnFile(string path, TextBox txtBox)
        {
            FileStream fileStream = File.OpenWrite(path);
            try
            {
                   string teksti = txtBox.Text; 
                    byte[] bytes = Encoding.UTF8.GetBytes(teksti);
                    fileStream.Write(bytes, 0, bytes.Length);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            finally
            {
                fileStream.Close();

            }


        }
    }
}

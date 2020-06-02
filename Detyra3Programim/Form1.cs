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
        public Form1()
        {
            InitializeComponent();
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
    }
}

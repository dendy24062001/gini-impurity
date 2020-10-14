using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gini_Impurity
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        OpenFileDialog open;

        private void buttonLoad_Click(object sender, EventArgs e)
		{
            open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Comma Separated|*.csv"
            };

            open.ShowDialog();

            try
            {
                if (open.FileName != "")
                {
                    using (TextFieldParser csvParser = new TextFieldParser(open.FileName))
                    {
                        csvParser.CommentTokens = new string[] { "#" };
                        csvParser.SetDelimiters(new string[] { "," });
                        csvParser.HasFieldsEnclosedInQuotes = true;

                        csvParser.ReadLine();

                        while (!csvParser.EndOfData)
                        {
                            string[] fields = csvParser.ReadFields();
                            //Isi sesuatu disini
                        }
                    }
                }
                else
                {
                    MessageBox.Show("File Kosong", "Error");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Terjadi sebuah kesalahan. Pesan Error: " + error, "Error");
            }

        }
	}
}

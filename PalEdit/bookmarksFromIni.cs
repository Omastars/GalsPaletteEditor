using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PalEdit
{
    public partial class bookmarksFromIni : Form
    {
        Form1 ths;
        public bookmarksFromIni(Form1 frm)
        {
            InitializeComponent();
            ths = frm;
        }





        private void bookmarksFromIni_Load(object sender, EventArgs e)
        {

            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);//Gets the folder directory of the program's executable
            
            StreamReader sr = new StreamReader(directory+@"\bookmarks.ini");
           

            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();

            string[] color1 = sr.ReadLine().Split('=');
            int lnumber = Convert.ToInt16(color1[1]);



            for (int x = 0; x < lnumber; x++)
            {
                string[] offset;

                offset = sr.ReadLine().Split('=');

                comboBox1.Items.Add(offset[0] + " " + offset[1]);


            }
            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);//Gets the folder directory of the program's executable

            StreamReader sr = new StreamReader(directory + @"\bookmarks.ini");
            
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                
                string[] color1 = sr.ReadLine().Split('=');
                int lnumber = Convert.ToInt16(color1[1]);

                comboBox1.Items.Clear();

                for (int x = 0; x < lnumber; x++)
                {
                    string[] offset;

                   offset = sr.ReadLine().Split('=');
                   
                   comboBox1.Items.Add(offset[0]+" "+offset[1]);

                    
                }
                sr.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                ths.toolStripTextBox1.Text = "";


            }
            else
            {
                string[] offset1 = comboBox1.Text.Split(' ');
                string offset = offset1[1];
                ths.toolStripTextBox1.Text = offset;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Process.Start(directory + @"\bookmarks.ini");

        }
    }
}

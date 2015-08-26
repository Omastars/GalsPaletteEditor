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
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;

namespace PalEdit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(openFileDialog1.FileName))) //The BinaryWriter is what writes to the rom
            {
                bw.Seek(Convert.ToInt32(toolStripTextBox1.Text, 16), SeekOrigin.Begin); //Here I set where I want to write. Obviously, I want it to write where the user wants
                ushort u = Convert.ToUInt16(textBox1.Text, 16); //Converts to UInt16 the text in the textbox (the color)
                bw.Write((byte)((u >> 8) & 255)); // In the default, the BinaryWriter writes at little endian format. We do not want that. This is why there is the other part, other than just "bw.Write()"
                bw.Write((byte)(u & 255)); //Read above^
                ushort u2 = Convert.ToUInt16(textBox2.Text, 16);
                bw.Write((byte)((u2 >> 8) & 255));
                bw.Write((byte)(u2 & 255));
                ushort u3 = Convert.ToUInt16(textBox3.Text, 16);
                bw.Write((byte)((u3 >> 8) & 255));
                bw.Write((byte)(u3 & 255));
                ushort u4 = Convert.ToUInt16(textBox4.Text, 16);
                bw.Write((byte)((u4 >> 8) & 255));
                bw.Write((byte)(u4 & 255));
                ushort u5 = Convert.ToUInt16(textBox5.Text, 16);
                bw.Write((byte)((u5 >> 8) & 255));
                bw.Write((byte)(u5 & 255));
                ushort u6 = Convert.ToUInt16(textBox6.Text, 16);
                bw.Write((byte)((u6 >> 8) & 255));
                bw.Write((byte)(u6 & 255));
                ushort u7 = Convert.ToUInt16(textBox7.Text, 16);
                bw.Write((byte)((u7 >> 8) & 255));
                bw.Write((byte)(u7 & 255));
                ushort u8 = Convert.ToUInt16(textBox8.Text, 16);
                bw.Write((byte)((u8 >> 8) & 255));
                bw.Write((byte)(u8 & 255));
                ushort u9 = Convert.ToUInt16(textBox9.Text, 16);
                bw.Write((byte)((u9 >> 8) & 255));
                bw.Write((byte)(u9 & 255));
                ushort u10 = Convert.ToUInt16(textBox10.Text, 16);
                bw.Write((byte)((u10 >> 8) & 255));
                bw.Write((byte)(u10 & 255));
                ushort u11 = Convert.ToUInt16(textBox11.Text, 16);
                bw.Write((byte)((u11 >> 8) & 255));
                bw.Write((byte)(u11 & 255));
                ushort u12 = Convert.ToUInt16(textBox12.Text, 16);
                bw.Write((byte)((u12 >> 8) & 255));
                bw.Write((byte)(u12 & 255));
                ushort u13= Convert.ToUInt16(textBox13.Text, 16);
                bw.Write((byte)((u13 >> 8) & 255));
                bw.Write((byte)(u13 & 255));
                ushort u14 = Convert.ToUInt16(textBox14.Text, 16);
                bw.Write((byte)((u14 >> 8) & 255));
                bw.Write((byte)(u14 & 255));
                ushort u15 = Convert.ToUInt16(textBox15.Text, 16);
                bw.Write((byte)((u15 >> 8) & 255));
                bw.Write((byte)(u15 & 255));
                ushort u16 = Convert.ToUInt16(textBox16.Text, 16);
                bw.Write((byte)((u16 >> 8) & 255));
                bw.Write((byte)(u16 & 255));

            
            
            
            
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "GBA File(*.gba)|*.gba"; //We want the user to open only GBA files
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //If the user chooses a file
            {
                string gameCode = string.Empty; //A new string that will be used to read the game code
                using (BinaryReader br = new BinaryReader(File.OpenRead(openFileDialog1.FileName))) //The BinaryReader is what reads data in the file

                {
                    br.BaseStream.Seek(0xAC, SeekOrigin.Begin); //The game code's location is at 0xAC, therefore I want the binary reader to read at 0xAC
                    gameCode = Encoding.UTF8.GetString(br.ReadBytes(4)); //The game code is 4 bytes long and is at UTF8 
                }
                toolStripLabel3.Text = gameCode; //Sets the label's text to the game code obtained earlier
                toolStripTextBox1.Enabled = true;
                button1.Enabled = true;
                toolStripButton2.Enabled = true;
                MessageBox.Show("Successfuly opened "+gameCode, "Success");

            }
            else //If the user didn't choose a file to open (for example clicks cancel in the dialog)
            {
                toolStripTextBox1.Enabled = false;
                button1.Enabled = false;
                toolStripButton2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

                int gba_color; //The GBA color is an integer
                int red = Convert.ToInt16(textBox17.Text);  //Converts the text written in text box number 17 to a 16-bit integer
                int green = Convert.ToInt16(textBox18.Text); //Converts the text written in text box number 18 to a 16-bit integer
                int blue = Convert.ToInt16(textBox19.Text); //Converts the text written in text box number 19 to a 16-bit integer

            gba_color = (((red >> 3) & 31) | (((green >> 3) & 31) << 5) | (((blue >> 3) & 31) << 10)); //Converts the 3 RGB colors to one GBA color. Thank Lost Heart for the formula
            int reversed = ((gba_color >> 8) & 255) + ((gba_color & 255) << 8); //The result that the formula gives is at little endian format. We don't want that.
           textBox20.Text= reversed.ToString("X"); //Converts to string and makes it stay in hex


        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
            {
                MessageBox.Show("Please load a file", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);


            }
            else
            {

                if (toolStripTextBox1.Text == "")
                {

                    MessageBox.Show("Please enter an offset", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (toolStripTextBox1.Text == "lol")
                {
                    MessageBox.Show("LOL", "LOL");


                }
                else
                {

                    using (BinaryReader br = new BinaryReader(File.OpenRead(openFileDialog1.FileName)))
                    {
                        br.BaseStream.Seek(Convert.ToInt32(toolStripTextBox1.Text, 16), SeekOrigin.Begin); // Seeks for the offset the user provided
                        byte[] temp = br.ReadBytes(2); //Every color has 2 bytes length. It reads them as a byte array because again, it reads them at little endian format which we don't want it to do
                        textBox36.Text = temp[0].ToString("X2") + temp[1].ToString("X2"); //Sets the text in the text box to the two bytes in the ROM
                        byte[] temp1 = br.ReadBytes(2);
                        textBox35.Text = temp1[0].ToString("X2") + temp1[1].ToString("X2");
                        byte[] temp2 = br.ReadBytes(2);
                        textBox34.Text = temp2[0].ToString("X2") + temp2[1].ToString("X2");
                        byte[] temp3 = br.ReadBytes(2);
                        textBox33.Text = temp3[0].ToString("X2") + temp3[1].ToString("X2");
                        byte[] temp4 = br.ReadBytes(2);
                        textBox32.Text = temp4[0].ToString("X2") + temp4[1].ToString("X2");
                        byte[] temp5 = br.ReadBytes(2);
                        textBox31.Text = temp5[0].ToString("X2") + temp5[1].ToString("X2");
                        byte[] temp6 = br.ReadBytes(2);
                        textBox30.Text = temp6[0].ToString("X2") + temp6[1].ToString("X2");
                        byte[] temp7 = br.ReadBytes(2);
                        textBox29.Text = temp7[0].ToString("X2") + temp7[1].ToString("X2");
                        byte[] temp8 = br.ReadBytes(2);
                        textBox28.Text = temp8[0].ToString("X2") + temp8[1].ToString("X2");
                        byte[] temp9 = br.ReadBytes(2);
                        textBox27.Text = temp9[0].ToString("X2") + temp9[1].ToString("X2");
                        byte[] temp10 = br.ReadBytes(2);
                        textBox26.Text = temp10[0].ToString("X2") + temp10[1].ToString("X2");
                        byte[] temp11 = br.ReadBytes(2);
                        textBox25.Text = temp11[0].ToString("X2") + temp11[1].ToString("X2");
                        byte[] temp12 = br.ReadBytes(2);
                        textBox24.Text = temp12[0].ToString("X2") + temp12[1].ToString("X2");
                        byte[] temp13 = br.ReadBytes(2);
                        textBox23.Text = temp13[0].ToString("X2") + temp13[1].ToString("X2");
                        byte[] temp14 = br.ReadBytes(2);
                        textBox22.Text = temp14[0].ToString("X2") + temp14[1].ToString("X2");
                        byte[] temp15 = br.ReadBytes(2);
                        textBox21.Text = temp15[0].ToString("X2") + temp15[1].ToString("X2");
                    }

                }
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
            using (StreamReader sr = new StreamReader(openFileDialog2.FileName)){ 
                sr.ReadLine(); //Reads the first line in the PAL file
                string format = sr.ReadLine(); //Reads the second line and stores it in a string
                string colors = sr.ReadLine(); //Reads the third line and stores it in a string

                if (format == "0100") //0100 is the standart PAL file format, and the one we want to read
                {
                    if (colors == "16") //The program only knows how to read 16 colors, obviously.
                    {
                        string line = sr.ReadLine();//The fourth line and beyond are the lines where the RGB colors are stored
                        string[] color1 = line.Split(' ');//The three colors are seperated by spaces. What this does it splitting the 3 colors.
                        int r1 = Convert.ToInt16(color1[0]);//Index 0 is the red color
                        int g1 = Convert.ToInt16(color1[1]);//Index 1 is the green color
                        int b1 = Convert.ToInt16(color1[2]);//Index 2 is the blue color
                        int c1 = (((r1 >> 3) & 31) | (((g1 >> 3) & 31) << 5) | (((b1 >> 3) & 31) << 10));
                        int re = ((c1 >> 8) & 255) + ((c1 & 255) << 8);
                        textBox1.Text = re.ToString("X");

                        string line1 = sr.ReadLine();
                        string[] color2 = line1.Split(' ');
                        int r2 = Convert.ToInt16(color2[0]);
                        int g2 = Convert.ToInt16(color2[1]);
                        int b2 = Convert.ToInt16(color2[2]);
                        int c2 = (((r2 >> 3) & 31) | (((g2 >> 3) & 31) << 5) | (((b2 >> 3) & 31) << 10));
                        int re1 = ((c2 >> 8) & 255) + ((c2 & 255) << 8);

                        textBox2.Text = re1.ToString("X");

                        string line2 = sr.ReadLine();
                        string[] color3 = line2.Split(' ');
                        int r3 = Convert.ToInt16(color3[0]);
                        int g3 = Convert.ToInt16(color3[1]);
                        int b3 = Convert.ToInt16(color3[2]);
                        int c3 = (((r3 >> 3) & 31) | (((g3 >> 3) & 31) << 5) | (((b3 >> 3) & 31) << 10));
                        int re2 = ((c3 >> 8) & 255) + ((c3 & 255) << 8);
                        textBox3.Text = re2.ToString("X");

                        string line3 = sr.ReadLine();
                        string[] color4 = line3.Split(' ');
                        int r4 = Convert.ToInt16(color4[0]);
                        int g4 = Convert.ToInt16(color4[1]);
                        int b4 = Convert.ToInt16(color4[2]);
                        int c4 = (((r4 >> 3) & 31) | (((g4 >> 3) & 31) << 5) | (((b4 >> 3) & 31) << 10));
                        int re3 = ((c4 >> 8) & 255) + ((c4 & 255) << 8);
                        textBox4.Text = re3.ToString("X");

                        string line4 = sr.ReadLine();
                        string[] color5 = line4.Split(' ');
                        int r5 = Convert.ToInt16(color5[0]);
                        int g5 = Convert.ToInt16(color5[1]);
                        int b5 = Convert.ToInt16(color5[2]);
                        int c5 = (((r5 >> 3) & 31) | (((g5 >> 3) & 31) << 5) | (((b5 >> 3) & 31) << 10));
                        int re4 = ((c5 >> 8) & 255) + ((c5 & 255) << 8);
                        textBox5.Text = re4.ToString("X");

                        string line5 = sr.ReadLine();
                        string[] color6 = line5.Split(' ');
                        int r6 = Convert.ToInt16(color6[0]);
                        int g6 = Convert.ToInt16(color6[1]);
                        int b6 = Convert.ToInt16(color6[2]);
                        int c6 = (((r6 >> 3) & 31) | (((g6 >> 3) & 31) << 5) | (((b6 >> 3) & 31) << 10));
                        int re5 = ((c6 >> 8) & 255) + ((c6 & 255) << 8);
                        textBox6.Text = re5.ToString("X");

                        string line6 = sr.ReadLine();
                        string[] color7 = line6.Split(' ');
                        int r7 = Convert.ToInt16(color7[0]);
                        int g7 = Convert.ToInt16(color7[1]);
                        int b7 = Convert.ToInt16(color7[2]);
                        int c7 = (((r7 >> 3) & 31) | (((g7 >> 3) & 31) << 5) | (((b7 >> 3) & 31) << 10));
                        int re6 = ((c7 >> 8) & 255) + ((c7 & 255) << 8);
                        textBox7.Text = re6.ToString("X");

                        string line7 = sr.ReadLine();
                        string[] color8 = line7.Split(' ');
                        int r8 = Convert.ToInt16(color8[0]);
                        int g8 = Convert.ToInt16(color8[1]);
                        int b8 = Convert.ToInt16(color8[2]);
                        int c8 = (((r8 >> 3) & 31) | (((g8 >> 3) & 31) << 5) | (((b8 >> 3) & 31) << 10));
                        int re7 = ((c8 >> 8) & 255) + ((c8 & 255) << 8);
                        textBox8.Text = re7.ToString("X");

                        string line8 = sr.ReadLine();
                        string[] color9 = line8.Split(' ');
                        int r9 = Convert.ToInt16(color9[0]);
                        int g9 = Convert.ToInt16(color9[1]);
                        int b9 = Convert.ToInt16(color9[2]);
                        int c9 = (((r9 >> 3) & 31) | (((g9 >> 3) & 31) << 5) | (((b9 >> 3) & 31) << 10));
                        int re8 = ((c9 >> 8) & 255) + ((c9 & 255) << 8);
                        textBox9.Text = re8.ToString("X");

                        string line9 = sr.ReadLine();
                        string[] color10 = line9.Split(' ');
                        int r10 = Convert.ToInt16(color10[0]);
                        int g10 = Convert.ToInt16(color10[1]);
                        int b10 = Convert.ToInt16(color10[2]);
                        int c10 = (((r10 >> 3) & 31) | (((g10 >> 3) & 31) << 5) | (((b10 >> 3) & 31) << 10));
                        int re9 = ((c10 >> 8) & 255) + ((c10 & 255) << 8);
                        textBox10.Text = re9.ToString("X");

                        string line10 = sr.ReadLine();
                        string[] color11 = line10.Split(' ');
                        int r11 = Convert.ToInt16(color11[0]);
                        int g11 = Convert.ToInt16(color11[1]);
                        int b11 = Convert.ToInt16(color11[2]);
                        int c11 = (((r11 >> 3) & 31) | (((g11 >> 3) & 31) << 5) | (((b11 >> 3) & 31) << 10));
                        int re10 = ((c11 >> 8) & 255) + ((c11 & 255) << 8);
                        textBox11.Text = re10.ToString("X");

                        string line11 = sr.ReadLine();
                        string[] color12 = line11.Split(' ');
                        int r12 = Convert.ToInt16(color12[0]);
                        int g12 = Convert.ToInt16(color12[1]);
                        int b12 = Convert.ToInt16(color12[2]);
                        int c12 = (((r12 >> 3) & 31) | (((g12 >> 3) & 31) << 5) | (((b12 >> 3) & 31) << 10));
                        int re11 = ((c12 >> 8) & 255) + ((c12 & 255) << 8);
                        textBox12.Text = re11.ToString("X");

                        string line12 = sr.ReadLine();
                        string[] color13 = line12.Split(' ');
                        int r13 = Convert.ToInt16(color13[0]);
                        int g13 = Convert.ToInt16(color13[1]);
                        int b13 = Convert.ToInt16(color13[2]);
                        int c13 = (((r13 >> 3) & 31) | (((g13 >> 3) & 31) << 5) | (((b13 >> 3) & 31) << 10));
                        int re12 = ((c13 >> 8) & 255) + ((c13 & 255) << 8);
                        textBox13.Text = re12.ToString("X");

                        string line13 = sr.ReadLine();
                        string[] color14 = line13.Split(' ');
                        int r14 = Convert.ToInt16(color14[0]);
                        int g14 = Convert.ToInt16(color14[1]);
                        int b14 = Convert.ToInt16(color14[2]);
                        int c14 = (((r14 >> 3) & 31) | (((g14 >> 3) & 31) << 5) | (((b14 >> 3) & 31) << 10));
                        int re13 = ((c14 >> 8) & 255) + ((c14 & 255) << 8);
                        textBox14.Text = re13.ToString("X");

                        string line14 = sr.ReadLine();
                        string[] color15 = line14.Split(' ');
                        int r15 = Convert.ToInt16(color15[0]);
                        int g15 = Convert.ToInt16(color15[1]);
                        int b15 = Convert.ToInt16(color15[2]);
                        int c15 = (((r15 >> 3) & 31) | (((g15 >> 3) & 31) << 5) | (((b15 >> 3) & 31) << 10));
                        int re14 = ((c15 >> 8) & 255) + ((c15 & 255) << 8);
                        textBox15.Text = re14.ToString("X");

                        string line15 = sr.ReadLine();
                        string[] color16 = line15.Split(' ');
                        int r16 = Convert.ToInt16(color16[0]);
                        int g16 = Convert.ToInt16(color16[1]);
                        int b16 = Convert.ToInt16(color16[2]);
                        int c16 = (((r16 >> 3) & 31) | (((g16 >> 3) & 31) << 5) | (((b16 >> 3) & 31) << 10));
                        int re15 = ((c16 >> 8) & 255) + ((c16 & 255) << 8);
                        textBox16.Text = re15.ToString("X");


                    }
                    else
                    {
                        MessageBox.Show("The palette imported isn't a 16 colors palette","Error");
                    }
                   
                }
                else
                {
                    MessageBox.Show("The format is not possible to read", "Error");


                }

                

                
                

            }
            
            
            }
            
            else
            {
                toolStripTextBox1.Enabled = false;
                
                toolStripButton2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            int gba_color = Convert.ToInt16(textBox40.Text, 16);

            int r = (gba_color & 31) << 3;
            int g = ((gba_color >> 5) & 31) << 3;
            int b = ((gba_color >> 10) & 31) << 3;

            textBox39.Text = r.ToString("X4");
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "GBA File(*.gba)|*.gba";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string gameCode = string.Empty;
                using (BinaryReader br = new BinaryReader(File.OpenRead(openFileDialog1.FileName)))
                {
                    br.BaseStream.Seek(0xAC, SeekOrigin.Begin);
                    gameCode = Encoding.UTF8.GetString(br.ReadBytes(4));
                }
                toolStripLabel3.Text = gameCode;
                toolStripTextBox1.Enabled = true;
                button1.Enabled = true;
                toolStripButton2.Enabled = true;

                
            }
            else
            {
                toolStripTextBox1.Enabled = false;
                button1.Enabled = false;
                toolStripButton2.Enabled = false;
                bookmarksToolStripMenuItem1.Enabled = true;

            }
        }

        private void charizardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "EAD5E8";
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "EAE094";
        }

        private void symbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "40270C";
        }

        private void backgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "402630";
        }

        private void starsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "402ABD";
        }

        private void pressStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "EAE094";
        }

        private void backgroundToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "46056A";
        }

        private void underneathOakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "4629D0";
        }

        private void controlGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "471E2C";

        }

        private void controlButtonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "4605C8";
        }

        private void flamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "3BF77C";
        }

        private void logoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "EAB6C4";
            
        }

        private void textboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "471DEC";
        }

        private void rayquazaBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "DDE418";
        }

        private void versionLogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "DDE438";
        }

        private void textboxToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "DDD728";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit? Any unsaved progress will be lost.", "u sure m8?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
               
            }
            
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox1 ab1 = new AboutBox1();
            ab1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear? Any unsaved progress will be lost.", "u sure m8?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void fromINIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new bookmarksFromIni(this).Show();
        }

        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new instructions().Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }


    }
}

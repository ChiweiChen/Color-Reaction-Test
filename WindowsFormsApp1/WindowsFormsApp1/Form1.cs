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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DateTime startTime, afterTime;
        string org, change,number;
        double y=0.0, switchTime;
        int color1, color2, color3, color4, color5, color6,test_count=0,org_wave,reac_wave;
        Color myColor, myColor2;
        Random rnd = new Random();
        TimeSpan timeElapsed,timeElapsed2;
        Boolean changed = false, chosen1=false,chosen2=false, started=false, name_input=false;

        List<string> combs = new List<string>();
        List<string> reactions = new List<string>();
        List<string> freq = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {



            
            started = true;
            if (chosen1==true && chosen2 == true &&org!=change &&textBox2.Text!="")
            {
                button1.Visible = false;
                ListBox1.Visible = false;
                button2.Visible = false;
                chooseColorToolStripMenuItem.Enabled = false;
                chooseReactionColorToolStripMenuItem.Enabled = false;
                //chooseColorToolStripMenuItem.Visible = false;
                //chooseReactionColorToolStripMenuItem.Visible= false;
                button3.Visible = false;
                startTime = DateTime.Now;
                timer1.Enabled = true;
                button1.Enabled = false;
                textBox2.Enabled = false;
            }
            else if (chosen1 == false && chosen2==true)
            {
                MessageBox.Show("Please finish choosing the original color.");
            }
            else if (chosen1==true && chosen2 == false)
            {
                MessageBox.Show("Please finish choosing the reaction color.");
            }


            else if ( chosen1==true && chosen2==true && org == change)
            {
                MessageBox.Show("Please don't pick same color for the reaction color and starting color. (Most people can't tell the difference)");
            }
            else if (chosen1==false && chosen2==false)
            {
                MessageBox.Show("Plesae at least choose a color.");
            }
            else
            {
                MessageBox.Show("Enter you student number please (Ex. 9Ping #31= 91231).");
            }
            
           
            
            
            
           
            
        }

        private void ChooseColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

            DialogResult upload = MessageBox.Show("Are you sure you want to turn in the results? (The program will be reset)", "Turn In", MessageBoxButtons.YesNo);
            if (upload == DialogResult.Yes)
            {
                
                var csv = new StringBuilder();

                var filePath = @"D:\Science_Fair_DT\" + textBox2.Text + ".csv";
                var filePath2 = @"D:\Science_Fair_DT\MasterSheet.csv";

                

                int i = 0;

                while (i < test_count)
                {

                    
                    var newLine = string.Format("{0},{1},{2}", combs[i], freq[i],reactions[i]);
                    csv.AppendLine(newLine);
                    i++;
                }


                
                File.AppendAllText(filePath, csv.ToString());
                File.AppendAllText(filePath2, csv.ToString());
                ListBox1.Items.Clear();
                chosen1 = false;
                chosen2 = false;
                label1.BackColor = Color.White;
                test_count = 0;
                myColor2 = Color.FromArgb(0, 0, 0);
                textBox2.Text = "";
                freq.Clear();
                combs.Clear();
                reactions.Clear();
                number = "";
                textBox2.Enabled = true;

            }
            else if (upload == DialogResult.No)
            {
                //do something else
            }

            

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            if (switchTime < y &&started==true && chosen1==true && chosen2==true &&changed==true)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timeElapsed2 = DateTime.Now - afterTime;

                button1.Visible = true;
                ListBox1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                switchTime = rnd.NextDouble() * 4;
                y = 0;
                started = false;
                changed = false;
                chooseColorToolStripMenuItem.Enabled= true;
                chooseReactionColorToolStripMenuItem.Enabled = true;

                label1.BackColor = myColor;
                
                ListBox1.Items.Add((org) + " to " + (change) + ":" + timeElapsed2.TotalSeconds.ToString("0.000"));
                button1.Enabled = true;
                combs.Add((org) + " to " + (change));
                reactions.Add(timeElapsed2.TotalSeconds.ToString("0.000"));

                freq.Add(Convert.ToString(org_wave - reac_wave));

                test_count++;
                
                

                
            }
            else if (chosen1==true && chosen2==true &&  started==true && changed==false)
            {
                
                timer1.Enabled = false;
                timer2.Enabled = false;
                timeElapsed2 = DateTime.Now - afterTime;

                button1.Visible = true;
                ListBox1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;

                
                switchTime = rnd.NextDouble() * 4;
                y = 0;
                label1.BackColor = myColor;


                ListBox1.Items.Add((org) + "to" + (change) + ":" + "Too Early");
                MessageBox.Show("Click after the color changes");
                //combs.Add((org) + " to " + (change));
                //reactions.Add(null);
                //test_count++;
                started = false;
                button1.Enabled = true;
                changed = false;
                chooseColorToolStripMenuItem.Enabled = true;
                chooseReactionColorToolStripMenuItem.Enabled = true;







            }
            started = false;
            
        }

        private void RedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color1 = 255;
            color2 = 0;
            color3 = 0;
            myColor = Color.FromArgb(color1, color2, color3);
            label1.BackColor = myColor;
            org = "Red";
            chosen1 = true;
            org_wave = (750 + 620) / 2;
        }

        private void OrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color1 = 255;
            color2 = 165;
            color3 = 0;
            myColor = Color.FromArgb(color1, color2, color3);
            label1.BackColor = myColor;
            org = "Orange";
            chosen1 = true;
            org_wave = (590 + 620) / 2;

        }

        private void YellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color1 = 255;
            color2 = 255;
            color3 = 0;
            myColor = Color.FromArgb(color1, color2, color3);
            label1.BackColor = myColor;
            org = "Yellow";
            chosen1 = true;
            org_wave = (570+ 590) / 2;
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            DialogResult choice= MessageBox.Show("Are you sure you want to reset the program?", "Reset", MessageBoxButtons.YesNo);
            if (choice == DialogResult.Yes)
            {
                ListBox1.Items.Clear();
                chosen1 = false;
                chosen2 = false;
                label1.BackColor = Color.White;
                test_count = 0;
                myColor2 = Color.FromArgb(0, 0, 0);
                textBox2.Text = "";
                freq.Clear();
                combs.Clear();
                reactions.Clear();
                started =false;
                changed = false;
                number = "";

                textBox2.Enabled = true;
            }
            else if (choice == DialogResult.No)
            {
                //do something else
            }
            
        }

        private void GreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color1 = 0;
            color2 = 128;
            color3 = 0;
            myColor = Color.FromArgb(color1, color2, color3);
            label1.BackColor = myColor;
            org = "Green";

            chosen1 = true;
            org_wave = (495 + 570) / 2;
        }

        private void BlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            color1 = 0;
            color2 = 0;
            color3 = 255;
            myColor = Color.FromArgb(color1, color2, color3);
            label1.BackColor = myColor;
            org = "Blue";
            chosen1 = true;
            org_wave = (450 + 495) / 2;
        }

        private void PurpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color1 = 128;
            color2 = 0;
            color3 = 128;
            myColor = Color.FromArgb(color1, color2, color3);
            label1.BackColor = myColor;
            org = "Purple";
            chosen1 = true;
            org_wave = (380 + 450) / 2;
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            timeElapsed = DateTime.Now - startTime;
            
            y = timeElapsed.TotalSeconds;
            if (switchTime < y-2 && changed==false)
            {
                label1.BackColor = myColor2;
                afterTime=DateTime.Now;
                changed = true;
            }


        }

        private void OrangeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            color4 = 255;
            color5 = 165;
            color6 = 0;
            myColor2 = Color.FromArgb(color4, color5, color6);
            switchTime = rnd.NextDouble()*4;
            change = "Orange";
            chosen2 = true;
            reac_wave = (590 + 620) / 2;
        }

        private void RedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            color4 = 255;
            color5 = 0;
            color6 = 0;
            myColor2 = Color.FromArgb(color4, color5, color6);
            switchTime = rnd.NextDouble()*4;
            change = "Red";
            chosen2 = true;
            reac_wave = (750 + 620) / 2;
        }

        private void YellowToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            color4 = 255;
            color5 = 255;
            color6 = 0;
            myColor2 = Color.FromArgb(color4, color5, color6);
            switchTime = rnd.NextDouble()*4;
            change = "Yellow";
            chosen2 = true;
            reac_wave = (590 + 570) / 2;
        }

        private void GreenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            color4 = 0;
            color5 = 128;
            color6 = 0;
            myColor2 = Color.FromArgb(color4, color5, color6);
            switchTime = rnd.NextDouble()*4;
            change = "Green";
            chosen2 = true;
            reac_wave = (495 + 570) / 2;
        }

        private void BlueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            color4 = 0;
            color5 = 0;
            color6 = 255;
            myColor2 = Color.FromArgb(color4, color5, color6);
            switchTime = rnd.NextDouble()*4;
            change = "Blue";
            chosen2 = true;
            reac_wave = (450 + 495) / 2;
        }

        private void PurpleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            color4 = 128;
            color5 = 0;
            color6 = 128;
            myColor2 = Color.FromArgb(color4, color5, color6);
            switchTime = rnd.NextDouble()*4;
            change = "Purple";
            chosen2 = true;

            reac_wave = (380 + 450) / 2;



        }

        private void OrangeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            color1 = 255;
            color2 = 165;
            color3 = 0;
            myColor = Color.FromArgb(color1, color2, color3);
            label1.BackColor = myColor;
            org = "Orange";
            chosen1 = true;
            org_wave = (590 + 620) / 2;

        }
    }
}

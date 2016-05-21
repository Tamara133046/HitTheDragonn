using DontHitTheDragonn.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DontHitTheDragonn
{
    public partial class Form1 : Form
    {
        
        private bool secondChance = true;
        private int score = 0;
        public Form1()
        {
            InitializeComponent();
            tm.Interval = 400;
            tm.Tick += new EventHandler(tm_Tick);
            tm.Start();
            timer1.Interval = 1000;
            timer1.Start();
        }
                
        public PictureBox[] pb = new PictureBox[24];

        private void Form1_Load(object sender, EventArgs e)
            {
            pb[0] = pictureBox1;
            pb[1] = pictureBox2;
            pb[2] = pictureBox3;
            pb[3] = pictureBox4;
            pb[4] = pictureBox5;
            pb[5] = pictureBox6;
            pb[6] = pictureBox7;
            pb[7] = pictureBox8;
            pb[8] = pictureBox9;
            pb[9] = pictureBox10;
            pb[10] = pictureBox11;
            pb[11] = pictureBox12;
            pb[12] = pictureBox13;
            pb[13] = pictureBox14;
            pb[14] = pictureBox15;
            pb[15] = pictureBox16;
            pb[16] = pictureBox17;
            pb[17] = pictureBox18;
            pb[18] = pictureBox19;
            pb[19] = pictureBox20;
        }
        Timer tm = new Timer();
        int X;
        int Y;
        void tm_Tick(object sender, EventArgs e)
        {
            int random = (int)new Random().Next(0, 19); // se izbira random lokacija od slika 0 do slika 23 
            X = pb[random].Location.X; // se zema X pozicija na random slika 
            Y = pb[random].Location.Y; // se zema Y pozicija na istata random slika
            int thisX = pictureBox6.Location.X; // se zema X pozicija na slikata sto se menuva
            int thisY = pictureBox6.Location.Y; // se zema Y pozicija na slikata sto se menuva
            pictureBox6.Location = new Point(X, Y); // na mestoto na slikata sto se menuva se postavuvaat 
                                                    // koordinatite na random slikata
            pb[random].Location = new Point(thisX, thisY);// na mestoto na random slikata se postavuvaat 
                                                          // koordinatite na slikata sto se menuva
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tm.Stop();
            score = score + 30;
            if (!secondChance)
            {
                MessageBox.Show("Congratulations. You succeed. Your score is: " + score / 2);
                tm.Stop();
                timer1.Stop();
            }
            else {
                tm.Stop();
                timer1.Stop();
                MessageBox.Show("Congratulations. You succeed. Your score is: " + score);
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int broj;
            broj = int.Parse(label2.Text);
                broj--;
                label2.Text = broj.ToString();
            if(broj == 0)
            {
                tm.Stop();
                timer1.Stop();
                if (secondChance) { 
                if (MessageBox.Show("Time elapsed. If you want to save the game for another 25 seconds, you must solve the memory game.", "Continue the game?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    
                    if(secondChance)
                    {
                        CustomForm form2 = new CustomForm();
                        label2.Text = "15";
                        this.Hide();
                        if (form2.ShowDialog(this) == DialogResult.Yes)
                        {
                            secondChance = false;
                            tm.Start();
                            timer1.Start();
                            this.Show();
                        }
                        else
                        {
                            secondChance = false;
                            this.Close();
                        }
                        //this.Show();
                        }
                    else
                    {
                        MessageBox.Show("Game is over. Your score is:" + score);
                        this.Close();
                    }
                }
                    else
                    {
                        MessageBox.Show("Game is over. More luck next time.");
                        this.Close();
                    }
                }

                else
                {
                    MessageBox.Show("Game is over. More luck next time.");
                    this.Close();
                }

            }
        }
    }
    }

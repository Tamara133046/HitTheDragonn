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
    public partial class CustomForm : Form
    {
        public DialogResult resultGameOver2;
        private bool click = true;
        private PictureBox first;
        private readonly Random random = new Random();
        private readonly Timer timer1 = new Timer();
        int tick = 25;
        readonly Timer timer2 = new Timer { Interval = 1000 };
        public CustomForm()
        {
            InitializeComponent();
            setRandomImages();
            hideImages();
            startGameTimer();
            timer1.Interval = 500;
            timer1.Tick += click_Tick;
        }

        private PictureBox[] PictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        private static IEnumerable<Image> Images
        {
            get
            {
                return new Image[]
                {
                    Resources.alliser_thorne,
                    Resources.barristan_selmy,
                    Resources.brienne_of_tarth,
                    Resources.daario_naharis,
                    Resources.davos_seaworth,
                    Resources.mace_tyrell
                };
            }
        }

        private void startGameTimer()
        {
            timer2.Start();
            timer2.Tick += delegate
            {
                tick--;
                if (tick == -1)
                {
                    timer2.Stop();
                    MessageBox.Show("Times up. Game is over. Your score is: 0");
                    this.DialogResult = DialogResult.No;
                    Close();
                }
                
                var time = TimeSpan.FromSeconds(tick);
                label2.Text = time.ToString("ss");
            };
        }

        private void resetImages()
        {
            foreach(var img in PictureBoxes)
            {
                img.Tag = null;
                img.Visible = true;
            }
            hideImages();
            setRandomImages();
            tick = 25;
            this.Close();
        }

        private void hideImages()
        {
            foreach(var img in PictureBoxes)
            {
                img.Image = Resources.gameOfThrones;
            }
        }

        private PictureBox getFreeSlot()
        {
            int num;
            do
            {
                num = random.Next(0, PictureBoxes.Count());
            }
            while (PictureBoxes[num].Tag != null);
            return PictureBoxes[num];
        }

        private void setRandomImages()
        {
            foreach(var img in Images)
            {
                getFreeSlot().Tag = img;
                getFreeSlot().Tag = img;
            }
        }
        private void CustomForm_Load(object sender, EventArgs e)
        {

        }

        private void ClickImage(object sender, EventArgs e)
        {
            if (!click) return;
            var img = (PictureBox)sender;
            if(first == null)
            {
                first = img;
                img.Image = (Image)img.Tag;
                return;
            }
            img.Image = (Image)img.Tag;
            if(img.Image == first.Image && img != first)
            {
                img.Visible = first.Visible = false;
                {
                    first = img;
                }
                hideImages();
            }
            else
            {
                click = false;
                timer1.Start();
            }
            first = null;
            if (PictureBoxes.Any(p => p.Visible)) return;
            timer2.Stop();
            MessageBox.Show("You succeed. Now you can try again to hit the dragon.");
            //this.Hide();
            //Form1 form1 = new Form1();
            //form1.ShowDialog();
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void click_Tick(object sender, EventArgs e)
        {
            hideImages();
            click = true;
            timer1.Stop();
        }
    }
}

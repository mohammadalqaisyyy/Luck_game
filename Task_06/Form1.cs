using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Mohammad Al-Qaisy

namespace Task_06
{
    public partial class Form1 : Form
    {
        List<Character> list = new List<Character>();
        String[] IDs = { "Red", "Blue", "Pink", "White", "Orange"};
        List<Panel> panels = new List<Panel>();
        Image[] images = { Properties.Resources.red1, Properties.Resources.blue1, Properties.Resources.pink1,
        Properties.Resources.gray1, Properties.Resources.orange1
        };
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        Random random = new Random(System.DateTime.Now.Millisecond);
        int num, killer;
        public Form1()
        {
            InitializeComponent();
            num = random.Next(1, 4);
            Panel p;
            Character t;
            for (int i = 0; i < 5; i++)
            {
                p = new Panel();
                t = new Character(IDs[i], random.Next(0, this.Size.Width-150), 
                    random.Next(50, this.Size.Height - 200), random.Next(50, 150), random.Next(50, 150));
                panels.Add(p);
                list.Add(t);
            }
            for (int i = 5; i-5 < num; i++)
            {
                p = new Panel();
                t = new Character(IDs[i%5], random.Next(0, this.Size.Width-150), 
                    random.Next(50, this.Size.Height - 200), random.Next(50, 150), random.Next(50, 150));
                panels.Add(p);
                list.Add(t);
            }
            num += 5;
            killer = random.Next(0, num);
            player.SoundLocation = "music.wav";
            player.Play();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            show();
        }
        ~Form1()
        {
            list.Clear();
            panels.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            replay();
        }

        void show()
        {
            killer = random.Next(0, num);
            list[killer].SetAsKiller();
            list[killer].Kill(list);
            for (int i = 0; i < num; i++)
            {
                if (list[i]._alive)
                    panels[i].BackColor = Color.Transparent;
                else
                    continue;
                panels[i].BackgroundImage = images[i % 5];
                panels[i].BackgroundImageLayout = ImageLayout.Zoom;
                panels[i].Size = new System.Drawing.Size(list[i]._width, list[i]._hieght);
                panels[i].Location = new Point(list[i]._x, list[i]._y);
                this.Controls.Add(panels[i]);
            }
            reset();
            for (int i = 0; i < list.Count; i++)
            {
                list[i]._x = random.Next(0, this.Size.Width - 150);
                list[i]._y = random.Next(20, this.Size.Height - 200);
            }
        }
        void reset()
        {
            button1.Visible = true; button2.Visible = true; button3.Visible = true; 
            button4.Visible = true; button5.Visible = true;
            for (int i = 0; i < num; i++)
            {
                list[i]._alive = true;
                list[i]._killer = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Win(button1.Text))
            {
                button1.BackColor = Color.Green;
                button1.Text = "Win";
                button1.ForeColor = Color.White;
                button2.Visible = false; button3.Visible = false; button4.Visible = false; button5.Visible = false;
            }
            else
            {
                button1.BackColor = Color.Red;
                button1.Text = "X";
                button1.ForeColor = Color.Black;
            }
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Win(button2.Text))
            {
                button2.BackColor = Color.Green;
                button2.Text = "Win";
                button2.ForeColor = Color.White;
                button1.Visible = false; button3.Visible = false; button4.Visible = false; button5.Visible = false;
            }
            else
            {
                button2.BackColor = Color.Red;
                button2.Text = "X";
                button2.ForeColor = Color.Black;
            }
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Win(button3.Text))
            {
                button3.BackColor = Color.Green;
                button3.Text = "Win";
                button3.ForeColor = Color.White;
                button2.Visible = false; button1.Visible = false; button4.Visible = false; button5.Visible = false;
            }
            else
            {
                button3.BackColor = Color.Red;
                button3.Text = "X";
                button3.ForeColor = Color.Black;
            }
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Win(button4.Text))
            {
                button4.BackColor = Color.Green;
                button4.Text = "Win";
                button4.ForeColor = Color.White;
                button2.Visible = false; button3.Visible = false; button1.Visible = false; button5.Visible = false;
            }
            else
            {
                button4.BackColor = Color.Red;
                button4.Text = "X";
                button4.ForeColor = Color.Black;
            }
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Win(button5.Text))
            {
                button5.BackColor = Color.Green;
                button5.Text = "Win";
                button5.ForeColor = Color.White;
                button2.Visible = false; button3.Visible = false; button4.Visible = false; button1.Visible = false;
            }
            else
            {
                button5.BackColor = Color.Red;
                button5.Text = "X";
                button5.ForeColor = Color.Black;
            }
            button5.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Application.Restart();
            replay();
        }
        void replay()
        {
            for (int i = 0; i < list.Count; i++)
                this.Controls.Remove(panels[i]);
            show();
            button1.Enabled = true; button1.Text = "Red"; button1.BackColor = Color.Black; button1.ForeColor = Color.Red;
            button2.Enabled = true; button2.Text = "Pink"; button2.BackColor = Color.Black; button2.ForeColor = Color.Magenta;
            button3.Enabled = true; button3.Text = "White"; button3.BackColor = Color.Black; button3.ForeColor = Color.White;
            button4.Enabled = true; button4.Text = "Orange"; button4.BackColor = Color.Black; button4.ForeColor = Color.FromArgb(255, 128, 0);
            button5.Enabled = true; button5.Text = "Blue"; button5.BackColor = Color.Black; button5.ForeColor = Color.Blue;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            timer1.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool Win(String str)
        {
            if (str == list[killer]._id)
            {
                return true;
                button1.Enabled = false; button2.Enabled = false; button3.Enabled = false;
                button4.Enabled = false; button5.Enabled = false;
            }
            else
                return false;
        }
    }
}

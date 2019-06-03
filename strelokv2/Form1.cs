using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace strelokv2
{
    public partial class Strelok : Form
    {
        public Random r = new Random();
        public static Graphics g;
        public static int a, b, with, heght;
        public static int trai = 0;
        public static int hitcount = 0;
        public Strelok()
        {

            InitializeComponent();
        }

        public void trycount()
        {
            label5.Text = Convert.ToString("Попытка №" + " " + (trai + 1));
            label6.Text = Convert.ToString("Попаданий" + " " + hitcount);
        }

        public void point()
        {
            a = r.Next(20, 350);
            b = r.Next(20, 350);
            int with = 5, heght = 5;
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawEllipse(Pens.Black, a, b, with, heght);
            g.FillEllipse(brush, a, b, with, heght);
        }

        public void field()
        {
            
            g.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(2000, 0));

            g.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(0, 2000));
            int x1 = 20, x2 = 20, y1 = 0, y2 = 10;
            for (int i = 0; i < 50; i++)
            {
                g.DrawLine(new Pen(Color.Red, 2), new Point(x1, y1), new Point(x2, y2));
                x1 += 20; x2 += 20;
            }
            int x3 = 0, y3 = 20, x4 = 10, y4 = 20;
            for (int i = 0; i < 50; i++)
            {
                g.DrawLine(new Pen(Color.Red, 2), new Point(x3, y3), new Point(x4, y4));
                y3 += 20; y4 += 20;
            }
        }
        public void target()
        {
            int x = 350;
            int y = 150;
            int width = 200; int height = 200;
            for (int i = 0; i < 10; i++)
            {
                SolidBrush br;
                if (i % 2 == 0)
                    br = new SolidBrush(Color.Black);
                else
                    br = new SolidBrush(Color.White);
                g.DrawEllipse(Pens.Black, x, y, width, height);
                g.FillEllipse(br, x, y, width, height);
                height -= 24; width -= 24;
                x += 12; y += 12;
            }          
        }

        public void shoot()
        {
            int x = Convert.ToInt32(textBox1.Text) + a;
            int y = Convert.ToInt32(textBox3.Text) + b;

            SolidBrush brush = new SolidBrush(Color.Red);
            g.DrawEllipse(Pens.Black, x, y, with, heght);
            g.FillEllipse(brush, x, y, 5, 5);

            if (Math.Pow(x - 450, 2) + Math.Pow(y - 250, 2) <= 10000)
                MessageBox.Show("Попал");
            else
            
                MessageBox.Show("Не попал");
            if (Math.Pow(x - 450, 2) + Math.Pow(y - 250, 2) <= 10000)
            { hitcount++; }
                
                trai++;
            trycount();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trycount();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = panel1.CreateGraphics();

            point();
            field();
            target();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shoot();
        }
    }
}

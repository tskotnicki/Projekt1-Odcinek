using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odcinek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int x1 = 0;
        public int y1 = 0;
        public int x2 = 0;
        public int y2 = 0;
        public Bitmap tlo;
        //zabezpieczenie wejścia
        private void textBox1_TextChanged(object sender, EventArgs e){}
        private void textBox2_TextChanged(object sender, EventArgs e){}
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int wynik) == true && int.TryParse(textBox2.Text, out int wynik2) == true && int.TryParse(textBox3.Text, out int wynik3) == true && int.TryParse(textBox4.Text, out int wynik4) == true)
            {     
                x1 = int.Parse(textBox1.Text);
                y1 = int.Parse(textBox3.Text);
                x2 = int.Parse(textBox2.Text);
                y2 = int.Parse(textBox4.Text);
                if (x1<0)
                {
                    x2 += 2*Math.Abs(x1);
                    x1 = Math.Abs(x1);
                }
                if (x2 < 0)
                {
                    x1 += 2 * Math.Abs(x2);
                    x2 = Math.Abs(x2);
                }
                if (y1 < 0)
                {
                    y2 += 2 * Math.Abs(y1);
                    y1 = Math.Abs(y1);
                }
                if (y2 < 0)
                {
                    y1 += 2 * Math.Abs(y2);
                    y2 = Math.Abs(y2);
                }
                {
                    MessageBox.Show("Dane zostały przyjęte.");
                }
            }
            else
            {
                MessageBox.Show("Podno błędne dane! Podaj liczby typu int!");
            }
        }

        //przyrostowy
        private void button1_Click(object sender, EventArgs e)
        {
            double x,y,dx,dy,m;
            int temp, xwie, ywie;
            xwie = x2;
            ywie = y2;
            if (x1 > x2)
            {
                xwie = x1;
                temp = x1;
                x1 = x2;
                x2 = temp;
                temp = y1;
                y1 = y2;
                y2 = temp;
            }
            if (y1 > y2)
            {
                ywie = y1;
            }
            else { ywie = y2; }

            dx = x2 - x1;
            dy = y2 - y1;
            m = dy / dx;
            tlo = new Bitmap(xwie + 1, ywie + 1);

            //osie
            for (int i = 0; i < xwie; i++)
            {
                tlo.SetPixel(i, 0, Color.Black);
            }
            for (int j = 0; j < ywie; j++)
            {
                tlo.SetPixel(0, j, Color.Black);
            }

            //linia
            if (Math.Abs(m) <= 1)
            {
                y = y1;
                for (x = x1; x < x2; x++)
                {
                    tlo.SetPixel((int)Math.Round(x,1), (int)Math.Round(y,1), Color.Blue);
                    y +=m;
                }
            }
            else
            {
                x = x1;
                for (y = y1; y < y2; y++)
                {         
                    tlo.SetPixel((int)Math.Round(x,1),(int)Math.Round(y,1), Color.Blue);
                    x += (1 / m);
                }
            }
            pbox.Image = tlo;
        }

        //bresenham
        private void button2_Click(object sender, EventArgs e)
        {
            int d, dx, dy, ai, bi, xi, yi, xwie, ywie;
            int x = x1, y = y1;
            if (x1 < x2)
            {
                xwie = x2;
                xi = 1;
                dx = x2 - x1;
            }
            else
            {
                xwie = x1;
                xi = -1;
                dx = x1 - x2;
            }
            if (y1 < y2)
            {
                ywie = y2;
                yi = 1;
                dy = y2 - y1;
            }
            else
            {
                ywie = y1;
                yi = -1;
                dy = y1 - y2;
            }
            tlo = new Bitmap(xwie+1, ywie+1);
            //osie
            for (int i = 0; i < xwie; i++)
            {
                tlo.SetPixel(i, 0, Color.Black);
            }
            for (int j = 0; j < ywie; j++)
            {
                tlo.SetPixel(0, j, Color.Black);
            }
            tlo.SetPixel(x, y, Color.Red);
            //OX szybkie
            if (dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                while (x != x2)
                {
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        x += xi;
                    }
                    tlo.SetPixel(x, y, Color.Red);
                }
            }
            //OY szybkie
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                while (y != y2)
                {
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        y += yi;
                    }
                    tlo.SetPixel(x, y, Color.Red);
                }
            }
            pbox.Image = tlo;
        }
    }
}

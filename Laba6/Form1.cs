using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen myPen = new Pen(Color.White);
            g.DrawRectangle(myPen, 1, 1, 1, 1);
        }

        Graphics g;
        float coeff;
        float fi;
        int count = 0;
        static RectangleF[] pEllipse =
             {
                 new RectangleF(200, 300,30,50),
                 new RectangleF(300, 300,30,50),
            };
        RectangleF[] pEllipseFI = new RectangleF[2];
        private void button1_Click(object sender, EventArgs e) // Draw Hexagon
        {
            int startPoint = 30;
            Point[] points =
             {
                 new Point(startPoint, startPoint),
                 new Point(startPoint - 10, startPoint +10),
                 new Point(startPoint - 10, startPoint +20),
                 new Point(startPoint, startPoint+30),
                 new Point(startPoint+10, startPoint+20),
                 new Point(startPoint+10, startPoint+10),
                 new Point(startPoint-9, startPoint-9)
            };
            Random r = new Random();
            int cr = r.Next(255);
            int cg = r.Next(255);
            int cb = r.Next(255);
            Pen myPen = new Pen(Color.FromArgb(cr, cg, cb), 25);
            g = Graphics.FromHwnd(pictureBox1.Handle);
            g.DrawLines(myPen,points);
        }
        private void button2_Click(object sender, EventArgs e) // Draw Circle
        {
            Random r = new Random();
            g = Graphics.FromHwnd(pictureBox1.Handle);
            int cr = r.Next(255);
            int cg = r.Next(255);
            int cb = r.Next(255);
            Pen myPen = new Pen(Color.FromArgb(cr, cg, cb), 5);
            g.DrawEllipse(myPen, 430, 10, 50, 50);
        }
        private void button3_Click(object sender, EventArgs e) // Draw Ellipse
        {
            Random r = new Random();
            g = Graphics.FromHwnd(pictureBox1.Handle);
            int cr = r.Next(255);
            int cg = r.Next(255);
            int cb = r.Next(255);
            Pen myPen = new Pen(Color.FromArgb(cr, cg, cb), 25);
            g.DrawEllipse(myPen, 20, 410, 50, 20);
        }
        private void button4_Click(object sender, EventArgs e) // Draw Rectangle
        {
            Random r = new Random();
            g = Graphics.FromHwnd(pictureBox1.Handle);
            int cr = r.Next(255);
            int cg = r.Next(255);
            int cb = r.Next(255);
            Pen myPen = new Pen(Color.FromArgb(cr, cg, cb), 5);
            g.DrawRectangle(myPen, 380, 380, 100, 50);
        }

        private void button5_Click(object sender, EventArgs e) // Draw Viecle
        {
            Random r = new Random();
            g.Clear(Color.White);
            Point[] points1 =
            {
                 new Point(190,104),
                 new Point(160,104),
                 new Point(160,75),
                 new Point(190,75),
                 new Point(218,50),
                 new Point(280,50),
                 new Point(300,75),
                 new Point(325,75),
                 new Point(325,104),
                 new Point(303,104)
            }; 
            Point[] points2 =
             {
                 new Point(273,104),
                 new Point(220,104)
            };
            int cr = r.Next(255);
            int cg = r.Next(255);
            int cb = r.Next(255);
            Pen myPen = new Pen(Color.FromArgb(cr, cg, cb), 5);
            g.DrawEllipse(myPen, 190, 90, 30, 30);
            g.DrawEllipse(myPen, 270, 90, 30, 30);
            g.DrawLines(myPen, points1);
            g.DrawLines(myPen, points2);
        }

        private void button6_Click(object sender, EventArgs e) // Draw Animated Ellipse
        {
            coeff = 0;
            button7.Show();
            timer1.Start();
        }
        private void button7_Click(object sender, EventArgs e) // Stop 1
        {
            g.Clear(Color.White);
            button7.Hide();
            timer1.Stop();
            coeff = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e) // Timer 1 
        {
            g.Clear(Color.White);
            g = Graphics.FromHwnd(pictureBox1.Handle);
            Pen myPen = new Pen(Color.Black, 5);
            fi = coeff * (float)Math.PI;
            for (int i = 0; i < 2; i++)
            {
                pEllipseFI[i] = EllipseBuilder(fi, pEllipse[i]);
                g.DrawEllipse(myPen, pEllipseFI[i]);
            }
            coeff += 0.05f;
            if (coeff == 2)
                coeff = 0;   
        }
        static RectangleF EllipseBuilder(float fi, RectangleF ptt)
        {
            float dx = ptt.X - (pEllipse[0].X + pEllipse[1].X)/2;
            float dy = ptt.Y - (pEllipse[0].Y + pEllipse[1].Y) / 2;
            float dxn = dx * (float)Math.Cos(fi) - dy * (float)Math.Sin(fi);
            float dyn = dx * (float)Math.Sin(fi) + dy * (float)Math.Cos(fi);
            RectangleF pt = new RectangleF(((pEllipse[0].X + pEllipse[1].X) / 2) + dxn, ((pEllipse[0].Y + pEllipse[1].Y) / 2) + dyn, 30, 50);
            return pt;
        }

        private void button8_Click(object sender, EventArgs e) // Draw Animated Hammer
        {
            timer2.Start();
            button9.Show();
        }
        private void button9_Click(object sender, EventArgs e) // Stop 2
        {
            g.Clear(Color.White);
            timer2.Stop();
            button9.Hide();
        }

        private void timer2_Tick(object sender, EventArgs e) // Timer 2
        {
            g.Clear(Color.White);
            Pen myPen = new Pen(Color.Black, 5);
            g.DrawRectangle(myPen, 60, 300, 300, 50); // Wood
            g.DrawRectangle(myPen, 150, 260, 15, 40); // Nail (base) 
            g.DrawRectangle(myPen, 137, 250, 40, 10); // Nail (hat) 
            g.DrawRectangle(myPen, 320, 70, 20, 150); // Hammer (handle) |
            g.DrawRectangle(myPen, 290, 10, 80, 60); // Hammer |
            System.Threading.Thread.Sleep(500);

            g.Clear(Color.White);
            g.DrawRectangle(myPen, 60, 300, 300, 50); // Wood
            g.DrawRectangle(myPen, 150, 265, 15, 35); // Nail (base) 
            g.DrawRectangle(myPen, 137, 255, 40, 10); // Nail (hat) 
            g.DrawRectangle(myPen, 190, 200, 150, 20); // Hammer (handle) -
            g.DrawRectangle(myPen, 130, 170, 60, 80); // Hammer -
            System.Threading.Thread.Sleep(500);

            g.Clear(Color.White);
            g.DrawRectangle(myPen, 60, 300, 300, 50); // Wood
            g.DrawRectangle(myPen, 150, 265, 15, 35); // Nail (base) 
            g.DrawRectangle(myPen, 137, 255, 40, 10); // Nail (hat)  
            g.DrawRectangle(myPen, 320, 75, 20, 150); // Hammer (handle) |
            g.DrawRectangle(myPen, 290, 15, 80, 60); // Hammer |
            System.Threading.Thread.Sleep(500);

            g.Clear(Color.White);
            g.DrawRectangle(myPen, 60, 300, 300, 50); // Wood
            g.DrawRectangle(myPen, 150, 270, 15, 30); // Nail (base) 
            g.DrawRectangle(myPen, 137, 260, 40, 10); // Nail (hat)  
            g.DrawRectangle(myPen, 190, 205, 150, 20); // Hammer (handle) -
            g.DrawRectangle(myPen, 130, 175, 60, 80); // Hammer -
            System.Threading.Thread.Sleep(500);

            g.Clear(Color.White);
            g.DrawRectangle(myPen, 60, 300, 300, 50); // Wood
            g.DrawRectangle(myPen, 150, 270, 15, 30); // Nail (base) 
            g.DrawRectangle(myPen, 137, 260, 40, 10); // Nail (hat) 
            g.DrawRectangle(myPen, 320, 80, 20, 150); // Hammer (handle) |
            g.DrawRectangle(myPen, 290, 20, 80, 60); // Hammer |
            System.Threading.Thread.Sleep(500);

            g.Clear(Color.White);
            g.DrawRectangle(myPen, 60, 300, 300, 50); // Wood
            g.DrawRectangle(myPen, 150, 275, 15, 25); // Nail (base) 
            g.DrawRectangle(myPen, 137, 265, 40, 10); // Nail (hat)  
            g.DrawRectangle(myPen, 190, 210, 150, 20); // Hammer (handle) -
            g.DrawRectangle(myPen, 130, 180, 60, 80); // Hammer -
            System.Threading.Thread.Sleep(500);
        }
    }
}

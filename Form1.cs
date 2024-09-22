using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabaTriangle
{
    public partial class Form1 : Form
    {
        Point startPoint = new Point(170, 450);

        int sizeX = 700;
        int sizeY = 800;

        public Form1()
        {
            this.Size = new Size(sizeX, sizeY);
            this.Paint += new PaintEventHandler(Painter);
        }

        private void Painter(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            PaintBackground(g, Color.Black);
            //PaintTriangles(g, startPoint, Color.Black);
            PaintTriangless(g, startPoint, 50, Color.White);
        }

        private void PaintBackground(Graphics g, Color black)
        {
            g.FillRectangle(new SolidBrush(black), new Rectangle(0, 0, sizeX, sizeY));
        }

        private void PaintTriangles(Graphics g, Point startPoint, Color color)
        {
            Point[] points = new Point[3];
            points[0] = startPoint;
            points[1].X = startPoint.X * 2;
            points[1].Y = startPoint.Y / 2;
            points[2].X = startPoint.X * 3;
            points[2].Y = startPoint.Y;

            g.FillPolygon(new SolidBrush(color), points);
            g.DrawPolygon(new Pen(Color.White), points);


        }

        private void PaintTriangless(Graphics g, Point startPoint, int countTriangles, Color color)
        {
            for (int i = 0; i <= countTriangles; i++)
            {
                Point[] points = new Point[3];
                points[0] = startPoint;
                points[1].X = startPoint.X * 2 + i;
                points[1].Y = startPoint.Y / 2 - i;
                points[2].X = startPoint.X * 3 - i;
                points[2].Y = startPoint.Y - i;

                //g.FillPolygon(new SolidBrush(color), points);
                g.DrawPolygon(new Pen(Color.FromArgb(244,244,244- i)), points);
            }
        }
    }
}

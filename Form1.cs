using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabaTriangle
{
    public partial class Form1 : Form
    {
        private Point startPoint = new Point(170, 450);

        private int sizeX = 700;
        private int sizeY = 800;

        public Form1()
        {
            this.Size = new Size(sizeX, sizeY);
            this.Paint += new PaintEventHandler(Painter);
        }

        private void Painter(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            PaintBackground(g, Color.Black);
            PaintLines(g, startPoint);
            PaintLine(g, startPoint, Color.White);
            PaintTriangless(g, startPoint, 30, Color.White);
            DrawTriangle(g, startPoint);
        }

        private void PaintBackground(Graphics g, Color black)
        {
            g.FillRectangle(new SolidBrush(black), new Rectangle(0, 0, sizeX, sizeY));
        }

        private void PaintLines(Graphics g, Point startPos)
        {
            Color[] colors = new[]
            {
                Color.Red,
                Color.Orange,
                Color.Yellow,
                Color.Green,
                Color.Blue,
                Color.Indigo,
                Color.Violet
            };
            float spasing = 10f;
            for (int i = 0; i < 7; i++)
            {
                Color col = colors[i % colors.Length];
                float startPosX = startPos.X * 2.3f + i * 2;
                float startPosY = startPos.Y / 1.5f + (i * spasing);

                float endX = Width;
                float endY = Height / 2 + i * spasing;

                g.DrawLine(new Pen(col, spasing), startPosX, startPosY, endX, endY);
            }
        }

        private void PaintLine(Graphics g, Point startPos, Color color)
        {
            float posX = -Width;
            float posY = Height / 1.4f;

            float endX = startPoint.X * 2f;
            float endY = startPoint.Y / 1.5f;

            g.DrawLine(new Pen(color, 7), posX, posY, endX, endY);
        }

        private void DrawTriangle(Graphics g, Point startPoint)
        {
            PointF[] trianglePoints = new PointF[]
            {
                new PointF(startPoint.X * 1.5f, startPoint.Y / 1.4f),
                new PointF(startPoint.X * 1.9f, startPoint.Y / 1.5f - 10),
                new PointF(startPoint.X * 1.9f, startPoint.Y / 1.5f + 20)
            };

            LinearGradientBrush gradientBrush = new LinearGradientBrush(
                new PointF(startPoint.X * 1.5f, startPoint.Y / 2),
                new PointF(startPoint.X * 1.9f, startPoint.Y / 2),
                Color.White,
                Color.Black
            );

            g.FillPolygon(gradientBrush, trianglePoints);

            gradientBrush.Dispose();
        }

        private Point[] GetPoints(Point startPoint)
        {
            Point[] points = new Point[3];
            points[0] = startPoint;
            points[1].X = startPoint.X * 2;
            points[1].Y = startPoint.Y / 2;
            points[2].X = startPoint.X * 3;
            points[2].Y = startPoint.Y;
            return points;
        }

        private void PaintTriangless(Graphics g, Point startPoint, int countTriangles, Color color)
        {
            Point[] points = GetPoints(startPoint);

            g.FillPolygon(new SolidBrush(Color.Black), points);

            for (int i = 0; i <= countTriangles; i++)
            {
                points[0].X = startPoint.X + i;
                points[0].Y = startPoint.Y - i / 3;
                points[1].X = startPoint.X * 2;
                points[1].Y = startPoint.Y / 2 + i;
                points[2].X = startPoint.X * 3 - i;
                points[2].Y = startPoint.Y - i / 3;

                g.DrawPolygon(new Pen(Color.FromArgb(255 / (i + 1), color), 2), points);
            }
        }
    }
}

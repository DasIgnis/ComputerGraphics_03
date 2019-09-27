using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloodFill
{
    public partial class Form1 : Form
    {

        List<CheckBox> buttons = new List<CheckBox>();
        Bitmap bmp;
        private Graphics g;
        Point lastPoint = Point.Empty;
        Point mouseCoord;
        int penThickness = 1;
        Color borderColor = Color.FromArgb(255, 0, 0, 0);
        Pen fillPen;
        Pen borderPen;
        bool isMouseDown = false;
        Color fillColor;

        public Form1()
        {

            InitializeComponent();

            colorPanel.BackColor = Color.Green;
            fillColor = colorPanel.BackColor;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            update_pens();
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            this.Text = "Color Flood Fill";

        }

        private void update_pens()
        {
            borderPen = new Pen(Color.Black, penThickness);
            fillPen = new Pen(colorPanel.BackColor, 1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = e.Location;
            isMouseDown = true;
            mouseCoord = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown && penBtn.Checked && lastPoint != null)
            {
                g.DrawLine(borderPen, lastPoint, e.Location);
                lastPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            lastPoint = Point.Empty;
        }

        private void colorPanel_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorPanel.BackColor = colorDialog1.Color;
                fillColor = colorDialog1.Color;
                update_pens();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Invalidate();
        }

        private Color getColorAt(Point point)
        {
            if (pictureBox1.ClientRectangle.Contains(point))
                return ((Bitmap)pictureBox1.Image).GetPixel(point.X, point.Y);
            else
                return Color.Black;
        }

        private void simpleFloodFill(Point p)
        {
            Color curr = getColorAt(p);
            Point leftPoint = p;
            Point rightPoint = p;
            if (curr != borderColor && curr != fillColor && pictureBox1.ClientRectangle.Contains(p))
            {
                while (curr != borderColor && pictureBox1.ClientRectangle.Contains(leftPoint))
                {
                    leftPoint.X -= 1;
                    curr = getColorAt(leftPoint);
                }

                leftPoint.X += 1;
                curr = getColorAt(p);

                while (curr != borderColor && pictureBox1.ClientRectangle.Contains(rightPoint))
                {
                    rightPoint.X += 1;
                    curr = getColorAt(rightPoint);
                }

                rightPoint.X -= 1;
                g.DrawLine(fillPen, leftPoint, rightPoint);

                for (int i = leftPoint.X; i <= rightPoint.X; ++i)
                {
                    Point upPoint = new Point(i, p.Y + 1);
                    Color upC = getColorAt(upPoint);
                    if (upC.ToArgb() != borderColor.ToArgb() && upC.ToArgb() != fillColor.ToArgb() && pictureBox1.ClientRectangle.Contains(upPoint))
                        simpleFloodFill(upPoint);
                }

                for (int i = leftPoint.X; i < rightPoint.X; ++i)
                {
                    Point downPoint = new Point(i, p.Y - 1);
                    Color downC = getColorAt(downPoint);
                    if (downC.ToArgb() != borderColor.ToArgb() && downC.ToArgb() != fillColor.ToArgb() && pictureBox1.ClientRectangle.Contains(downPoint))
                        simpleFloodFill(downPoint);
                }

                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (fillBtn.Checked)
            {
                MouseEventArgs m = (MouseEventArgs)e;
                Point p = m.Location;
                Console.WriteLine(p);

                simpleFloodFill(p);
            }
            pictureBox1.Invalidate();
        }
    }
}

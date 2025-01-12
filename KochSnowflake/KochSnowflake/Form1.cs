using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace KochSnowflake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Color backgroundColor = Color.White;
        private Color lineColor = Color.Black;
        private double scale = 1.0;
        private void DrawKochSnowflake(Graphics g, PointF p1, PointF p2, int level)
        {
            if (level == 0)
            {
                g.DrawLine(new Pen(lineColor), p1, p2);
            }
            else
            {
                PointF p4 = new PointF(p1.X + (p2.X - p1.X) / 3, p1.Y + (p2.Y - p1.Y)/ 3);
                PointF p5 = new PointF(p1.X + (p2.X - p1.X) * 2 / 3, p1.Y + (p2.Y - p1.Y) * 2 / 3);
                PointF p3 = new PointF(
                    (p1.X + p2.X) / 2 + (float)Math.Sqrt(3) * (p1.Y - p2.Y) / 6,
                    (p1.Y + p2.Y) / 2 + (float)Math.Sqrt(3) * (p2.X - p1.X) / 6);
                DrawKochSnowflake(g, p1, p4, level - 1);
                DrawKochSnowflake(g, p4, p3, level - 1);
                DrawKochSnowflake(g, p3, p5, level - 1);
                DrawKochSnowflake(g, p5, p2, level - 1);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialogue = new ColorDialog())
            {
                colorDialogue.Color = backgroundColor;
                if (colorDialogue.ShowDialog() == DialogResult.OK) backgroundColor = colorDialogue.Color;
            }
            button1.BackColor = backgroundColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialogue = new ColorDialog())
            {
                colorDialogue.Color = lineColor;
                if (colorDialogue.ShowDialog() == DialogResult.OK) lineColor = colorDialogue.Color;
            }
            button2.BackColor = lineColor;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                double scl = Convert.ToDouble(textBox1.Text);
                scale = scl;
            }
            catch { }
            panel1.BackColor = backgroundColor;
            int level = comboBox1.SelectedIndex;
            using (Graphics g = panel1.CreateGraphics())
            {
                g.Clear(panel1.BackColor);
                DrawKochSnowflake(g, new PointF(339 * (float)scale, 106 * (float)scale), new PointF(189 * (float)scale, 356 * (float)scale), level);
                DrawKochSnowflake(g, new PointF(189 * (float)scale, 356 * (float)scale), new PointF(489 * (float)scale, 356 * (float)scale), level);
                DrawKochSnowflake(g, new PointF(489 * (float)scale, 356 * (float)scale), new PointF(339 * (float)scale, 106 * (float)scale), level);

            }
        }
        private void SaveImage()
        {
            Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(backgroundColor);
                int level = comboBox1.SelectedIndex;
                DrawKochSnowflake(g, new PointF(339 * (float)scale, 106 * (float)scale), new PointF(189 * (float)scale, 356 * (float)scale), level);
                DrawKochSnowflake(g, new PointF(189 * (float)scale, 356 * (float)scale), new PointF(489 * (float)scale, 356 * (float)scale), level);
                DrawKochSnowflake(g, new PointF(489 * (float)scale, 356 * (float)scale), new PointF(339 * (float)scale, 106 * (float)scale), level);
            }
            bitmap.Save("snowflake.jpg", ImageFormat.Jpeg);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveImage();
        }
    }
}

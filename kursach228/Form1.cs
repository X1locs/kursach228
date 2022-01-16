using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursach228
{
    public partial class Form1 : Form
    {
        Emitter emitter;

        PaintPoint ColorOne;  //Первый круг
        PaintPoint ColorTwo;  //Второй круг
        PaintPoint ColorThree;  //Третий круг
        PaintPoint ColorFour;  //Четвёртый круг
        PaintPoint ColorFive;  //Пятый круг
        PaintPoint ColorSix;  //Шестой круг
        PaintPoint ColorSeven;  //Седьмой круг
        PaintPoint ColorEight;  //Восьмой круг
        PaintPoint ColorNine;  //Девятый круг
        CounterPoint cp;

        public Form1()
        {
            InitializeComponent();          

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            this.MouseWheel += new MouseEventHandler(this_MouseWheel);



            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f,
                Speedmin = 10,
                SpeedMax = 50,
                ParticlesCount = 100
            };

            cp = new CounterPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            };

            emitter.impactPoints.Add(cp);


            ColorOne = new PaintPoint    // Расположение первого круга
            {
                X = picDisplay.Width / 2 - 420,
                Y = picDisplay.Height / 2,
                FillColor = Color.Red,
                FellColor = Color.Red

            };
            emitter.impactPoints.Add(ColorOne);

            ColorTwo = new PaintPoint    // Расположение второго круга
            {
                X = picDisplay.Width / 2 - 315,
                Y = picDisplay.Height / 2,
                FillColor = Color.Green,
                FellColor = Color.Green

            };
            emitter.impactPoints.Add(ColorTwo);

            ColorThree = new PaintPoint    // Расположение третьего круга
            {
                X = picDisplay.Width / 2 - 210,
                Y = picDisplay.Height / 2,
                FillColor = Color.Blue,
                FellColor = Color.Blue

            };
            emitter.impactPoints.Add(ColorThree);

            ColorFour = new PaintPoint    // Расположение четвёртого круга
            {
                X = picDisplay.Width / 2 - 105,
                Y = picDisplay.Height / 2,
                FillColor = Color.Magenta,
                FellColor = Color.Magenta

            };
            emitter.impactPoints.Add(ColorFour);

            ColorFive = new PaintPoint    // Расположение пятого круга
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
                FillColor = Color.Yellow,
                FellColor = Color.Yellow

            };
            emitter.impactPoints.Add(ColorFive);


            ColorSix = new PaintPoint    // Расположение шестого круга
            {
                X = picDisplay.Width / 2 + 105,
                Y = picDisplay.Height / 2,
                FillColor = Color.Purple,
                FellColor = Color.Purple

            };
            emitter.impactPoints.Add(ColorSix);

            ColorSeven = new PaintPoint    // Расположение седьмого круга
            {
                X = picDisplay.Width / 2 + 210,
                Y = picDisplay.Height / 2,
                FillColor = Color.Orange,
                FellColor = Color.Orange

            };
            emitter.impactPoints.Add(ColorSeven);

            ColorEight = new PaintPoint    // Расположение восьмого круга
            {
                X = picDisplay.Width / 2 + 315,
                Y = picDisplay.Height / 2,
                FillColor = Color.Pink,
                FellColor = Color.Pink

            };
            emitter.impactPoints.Add(ColorEight);

            ColorNine = new PaintPoint    // Расположение девятого круга
            {
                X = picDisplay.Width / 2 + 420,
                Y = picDisplay.Height / 2,
                FillColor = Color.Brown,
                FellColor = Color.Brown

            };
            emitter.impactPoints.Add(ColorNine);
        }


        void this_MouseWheel(object sender, MouseEventArgs e)  //   Изменение размера кругов с помощью колёсика мыши
        {
            if (e.Delta > 0)
            {
                if (ColorOne.Power < 359)
                {
                    ColorOne.Power += 15;
                    ColorTwo.Power += 15;
                    ColorThree.Power += 15;
                    ColorFour.Power += 15;
                    ColorFive.Power += 15;
                    ColorSix.Power += 15;
                    ColorSeven.Power += 15;
                    ColorEight.Power += 15;
                    ColorNine.Power += 15;
                }
            }
            else if (e.Delta < 0)
            {
                if (ColorOne.Power > 20)
                {
                    ColorOne.Power -= 15;
                    ColorTwo.Power -= 15;
                    ColorThree.Power -= 15;
                    ColorFour.Power -= 15;
                    ColorFive.Power -= 15;
                    ColorSix.Power -= 15;
                    ColorSeven.Power -= 15;
                    ColorEight.Power -= 15;
                    ColorNine.Power -= 15;
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ColorOne.Y = picDisplay.Height * (1f - trackBar1.Value / 100f);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ColorTwo.Y = picDisplay.Height * (1f - trackBar2.Value / 100f);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            ColorThree.Y = picDisplay.Height * (1f - trackBar3.Value / 100f);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            ColorFour.Y = picDisplay.Height * (1f - trackBar4.Value / 100f);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            ColorFive.Y = picDisplay.Height * (1f - trackBar5.Value / 100f);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            ColorSix.Y = picDisplay.Height * (1f - trackBar6.Value / 100f);
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            ColorSeven.Y = picDisplay.Height * (1f - trackBar7.Value / 100f);
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            ColorEight.Y = picDisplay.Height * (1f - trackBar8.Value / 100f);
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = trackBar9.Value;
            label2.Text = emitter.ParticlesPerTick.ToString();
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            emitter.Speedmin = trackBar10.Value;
            label1.Text = emitter.Speedmin.ToString();
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            ColorNine.Y = picDisplay.Height * (1f - trackBar11.Value / 100f);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorOne.FellColor = colorDialog1.Color;
                ColorOne.FillColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorTwo.FellColor = colorDialog1.Color;
                ColorTwo.FillColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorThree.FellColor = colorDialog1.Color;
                ColorThree.FillColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorFour.FellColor = colorDialog1.Color;
                ColorFour.FillColor = colorDialog1.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorFive.FellColor = colorDialog1.Color;
                ColorFive.FillColor = colorDialog1.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorSix.FellColor = colorDialog1.Color;
                ColorSix.FillColor = colorDialog1.Color;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorSeven.FellColor = colorDialog1.Color;
                ColorSeven.FillColor = colorDialog1.Color;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorEight.FellColor = colorDialog1.Color;
                ColorEight.FillColor = colorDialog1.Color;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorNine.FellColor = colorDialog1.Color;
                ColorNine.FillColor = colorDialog1.Color;
            }
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            List<IImpactPoint> temp = new List<IImpactPoint>();
            switch (e.Button)
            {

                case MouseButtons.Left:
                    cp = new CounterPoint
                    {
                        X = emitter.MousePositionX,
                        Y = emitter.MousePositionY
                    };

                    emitter.impactPoints.Add(cp);
                    break;

                case MouseButtons.Right:
                    foreach (var ep in emitter.impactPoints)
                    {
                        if (ep.GetType().Name == "CounterPoint")
                        {
                            double distance = Math.Sqrt(Math.Pow(emitter.MousePositionX - ep.X, 2) + Math.Pow(emitter.MousePositionX - ep.X, 2));
                            if (distance < ep.Power / 2) temp.Add(ep);

                        }
                    }
                    break;
            }
            foreach (var t in temp)
            {
                emitter.impactPoints.Remove(t);
            }
        }
    }
}

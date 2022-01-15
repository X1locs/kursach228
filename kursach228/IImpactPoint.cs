using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static kursach228.Particle;

namespace kursach228
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;
        public Color FillColor;
        public Color FellColor;

        public int Power = 100;

        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }

    public class PaintPoint : IImpactPoint
    {

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < Power / 1.5) // если частица оказалось внутри окружности
            {
                // то притягиваем ее
                var color = particle as ParticleColorful;
                color.FromColor = FillColor;
                color.ToColor = FellColor;
            }

        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(FellColor, 5),
                X - Power / 2,
                Y - Power / 2,
                Power,
                Power
                );
        }
    }
    public class CounterPoint : IImpactPoint
    {
        public int counter = 0;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < Power / 1.5) // если частица оказалось внутри окружности
            {
                if (particle.lastVisited != this) counter++;
                particle.lastVisited = this;
                particle.Life = 0;
            }

        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(Color.White, 5),
                X - Power / 2,
                Y - Power / 2,
                Power,
                Power
                );

            var stringFormat = new StringFormat(); // создаем экземпляр класса
            stringFormat.Alignment = StringAlignment.Center; // выравнивание по горизонтали
            stringFormat.LineAlignment = StringAlignment.Center; // выравнивание по вертикали

            g.DrawString(
                counter.ToString(),
                new Font("Verdana", 10),
                new SolidBrush(Color.White),
                X,
                Y,
                stringFormat

            );
        }
    }
}

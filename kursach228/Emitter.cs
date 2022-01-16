using System;
using System.Collections.Generic;
using System.Drawing;

namespace kursach228
{
    public class Emitter
    {
        public float GravitationX = 0;
        public float GravitationY = 0;

        public List<Particle> particles = new List<Particle>();

        public int MousePositionX;
        public int MousePositionY;

        public int ParticlesPerTick = 10;

        public int Speedmin = 1;    // Минимальная скорость падения частиц
        public int SpeedMax = 10;    // Максимальная скорость падения частиц

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        public int ParticlesCount = 100;  // Количество частиц
        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = 70 + Particle.rand.Next(100);
            particle.X = MousePositionX;
            particle.Y = MousePositionY;

            var direction = (double)Particle.rand.Next(360);
            var speed = Speedmin + Particle.rand.Next(10);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = 2 + Particle.rand.Next(10);

            if (particle.Life > 0)
            {
                var color = particle as ParticleColorful;
                color.FromColor = Color.White;
                color.ToColor = Color.White;
            }
        }

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
        public void UpdateState()
        {
            // изменение состояния частиц
            int particlesToCreate = ParticlesPerTick;

            foreach (var particle in particles)
            {
                particle.Life -= 1;
                if (particle.Life < 0)
                {
                    if (particlesToCreate > 0)
                    {
                        /* у нас как сброс частицы равносилен созданию частицы */
                        particlesToCreate -= 1; // поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle);
                    }
                }
                else
                {
                    // двигаем частицу
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    // перебираем все точки и пересчитываем их влияние на частицы
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    // изменяем скорость частиц под действием гравитации
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }

            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                if (particle.Life > 0)
                {
                    particle.Draw(g);
                }
            }

            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }
    }

    public class TopEmitter : Emitter
    {
        public int Width;

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.X = Particle.rand.Next(Width);
            particle.Y = 0;

            particle.SpeedY = Speedmin;

            particle.SpeedX = Particle.rand.Next(-2, 2);
        }
    }
}

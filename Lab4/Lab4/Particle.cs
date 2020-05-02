using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Particle
    {
        public int Radius; //Радуис
        public float X; //X координата 
        public float Y; //Y координата

        public float Direction; //Направление
        public float Speed; //Cкорость

        public float Life; // запас здоровья частицы

        public static Random rand = new Random();

        public static Particle Generate()
        {
            return new Particle
            {
                Direction = rand.Next(360),
                Speed = 1 + rand.Next(10),
                Radius = 2 + rand.Next(10),
                Life = 20 + rand.Next(100), // Добавили в генератор, исходный запас здоровья от 20 до 120
            };
        }

        public virtual void Draw(Graphics g)
        {
            // рассчитываем коэффициент прозрачности по шкале от 0 до 1.0
            float k = Math.Min(1f, Life / 100);
            // рассчитываем значение альфа канала в шкале от 0 до 255
            // по аналогии с RGB, он используется для задания прозрачности
            int alpha = (int)(k * 255);

            // создаем цвет из уже существующего, но привязываем к нему еще и значение альфа канала
            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color);

            // остальное все так же
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }

    public class ParticleColorful : Particle
    {
        // два новых поля под цвет начальный и конечный
        public Color FromColor;
        public Color ToColor;

        // для смеси цветов
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        // подменяем метод генерации на новый, который будет возвращать ParticleColorful
        public new static ParticleColorful Generate()
        {
            return new ParticleColorful
            {
                Direction = rand.Next(360),
                Speed = 1 + rand.Next(10),
                Radius = 2 + rand.Next(10),
                Life = 20 + rand.Next(100),
            };
        }

        // ну и отрисовку перепишем
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            // так как k уменшается от 1 до 0, то порядок цветов обратный
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }

    public class ParticleImage : Particle
    {
        public Image image;
        public Color FromColor;
        public Color ToColor;

        public new static ParticleImage Generate()
        {
            return new ParticleImage
            {
                Direction = rand.Next(360),
                Speed = 1 + rand.Next(10),
                Radius = 2 + rand.Next(10),
                Life = 20 + rand.Next(100),
            };
        }

        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            var color = ParticleColorful.MixColor(ToColor, FromColor, k);

            // матрица преобразования цвета
            // типа аналога матрицы трансформации, но для цвета
            ColorMatrix matrix = new ColorMatrix(new float[][]{
            new float[] {0, 0, 0, 0, 0}, // умножаем текущий красный цвет на 0
            new float[] {0, 0, 0, 0, 0}, // умножаем текущий зеленый цвет на 0
            new float[] {0, 0, 0, 0, 0}, // умножаем текущий синий цвет на 0
            new float[] {0, 0, 0, k, 0}, // тут подставляем k который прозрачность задает
            new float[] {(float)color.R / 255, (float)color.G / 255, (float)color.B/255, 0, 1F}});

            // эту матрицу пихают в атрибуты
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(matrix);

            // ну и тут хитрый метод рисования
            g.DrawImage(image,
                // куда рисовать
                new Rectangle((int)(X - Radius), (int)(Y - Radius), Radius * 2, Radius * 2),
                // и какую часть исходного изображения брать, в нашем случае все изображения
                0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel, // надо передать
                imageAttributes // наши атрибуты с матрицей преобразования
               );
        }
    }

    public abstract class EmiterBase
    {
        List<Particle> particles = new List<Particle>();
    
        // количество частиц эмитера храним в переменной
        int particleCount = 0;
        // и отдельной свойство которое возвращает количество частиц

        public int ParticlesCount
        {
            get
            {
                return particleCount;
            }
            set
            {
                // при изменении этого значения
                particleCount = value;
                // удаляем лишние частицы если вдруг
                if (value < particles.Count)
                {
                    particles.RemoveRange(value, particles.Count - value);
                }
            }
        }

        // три абстрактных метода мы их переопределим позже
        public abstract void ResetParticle(Particle particle);
        public abstract void UpdateParticle(Particle particle);
        public abstract Particle CreateParticle();

        // тут общая логика обновления состояния эмитера
        // по сути копипаста
        public void UpdateState()
        {
            foreach (var particle in particles)
            {
                particle.Life -= 1;
                if (particle.Life < 0)
                {
                    ResetParticle(particle);
                }
                else
                {
                    UpdateParticle(particle);
                }
            }

            for (var i = 0; i < 10; ++i)
            {
                if (particles.Count < 500)
                {
                    particles.Add(CreateParticle());
                }
                else
                {
                    break;
                }
            }
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }
    }

    public class PointEmiter : EmiterBase
    {
        public Point Position;

        public override Particle CreateParticle()
        {
            var particle = ParticleColorful.Generate();
            particle.FromColor = Color.Yellow;
            particle.ToColor = Color.FromArgb(0, Color.Magenta);
            particle.X = Position.X;
            particle.Y = Position.Y;
            return particle;
        }

        public override void ResetParticle(Particle particle)
        {
            particle.Life = 20 + Particle.rand.Next(100);
            particle.Speed = 1 + Particle.rand.Next(10);
            particle.Direction = Particle.rand.Next(360);
            particle.Radius = 2 + Particle.rand.Next(10);
            particle.X = Position.X;
            particle.Y = Position.Y;
        }

        public override void UpdateParticle(Particle particle)
        {
            var directionInRadians = particle.Direction / 180 * Math.PI;
            particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
            particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
        }
    }

    public class DirectionColorfulEmiter : PointEmiter
    {
        public int Direction = 0; // направление частиц
        public int Spread = 10; // разброс частиц
        public Color FromColor = Color.Yellow; // исходный цвет
        public Color ToColor = Color.Magenta; // конечный цвет

        public override Particle CreateParticle()
        {
            var particle = ParticleColorful.Generate();
            particle.FromColor = this.FromColor;
            particle.ToColor = Color.FromArgb(0, this.ToColor);
            particle.Direction = this.Direction + Particle.rand.Next(-Spread / 2, Spread / 2);

            particle.X = Position.X;
            particle.Y = Position.Y;
            return particle;
        }

        public override void ResetParticle(Particle particle)
        {
            var particleColorful = particle as ParticleColorful;
            if (particleColorful != null)
            {
                particleColorful.Life = 20 + Particle.rand.Next(100);
                particleColorful.Speed = 1 + Particle.rand.Next(10);

                particleColorful.FromColor = this.FromColor;
                particleColorful.ToColor = Color.FromArgb(0, this.ToColor);
                particleColorful.Direction = this.Direction + Particle.rand.Next(-Spread / 2, Spread / 2);

                particleColorful.X = Position.X;
                particleColorful.Y = Position.Y;
            }
        }
    }
}

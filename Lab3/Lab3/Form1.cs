using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        // Список с животными
        List<Animal> animalsList = new List<Animal>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRefil_Click(object sender, EventArgs e)
        {
            //Очищаем список, чтобы сгенерировать новый
            this.animalsList.Clear();

            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                // Получаем случайное число из 0, 1, 2 
                switch (rnd.Next() % 3)
                {
                    // Создаем соотвественный объект в зависимости от результата
                    case 0:
                        this.animalsList.Add(Cow.Generate()); 
                        break;
                    case 1: 
                        this.animalsList.Add(Cat.Generate());
                        break;
                    case 2: 
                        this.animalsList.Add(Dog.Generate());
                        break;
                }
            }

            // Обновим информацию
            ShowInfo();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            // Проверим, вдруг животные кончились
            if (this.animalsList.Count == 0)
            {
                txtOut.Text = "Пусто";
                return;
            }

            // Получим первого из очереди
            var animal = this.animalsList[0];

            //Удалим первого из очереди
            this.animalsList.RemoveAt(0);

            // Получим информацию о этом животном
            txtOut.Text = animal.GetInfo();

            //Обновим информацию
            ShowInfo();
        }

        // Обновление информации о количестве животных
        private void ShowInfo()
        {
            // Счетчики
            int cowsCount = 0;
            int dogsCount = 0;
            int catsCount = 0;

            txtThread.Text = "Очередь:\n";

            int i = 0;

            //Перебираем элементы списка и считаем сколько каких животных, заодно записываем их в очередь
            foreach (var animal in this.animalsList)
            {
                i++;
                if (animal is Cow)
                {
                    cowsCount++;
                    txtThread.Text += i + ". Корова\n";
                }
                else if (animal is Dog)
                {
                    dogsCount++;
                    txtThread.Text += i + ". Собака\n";
                }
                else if (animal is Cat)
                {
                    catsCount++;
                    txtThread.Text += i + ". Кот\n";
                }
            }

            //Выведем информацию о количестве животных
            txtInfo.Text = "Коровы\tКоты\tСобаки\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", cowsCount, catsCount, dogsCount);
        }
    }
}

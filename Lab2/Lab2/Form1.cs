using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Plenty plantyA;
            Plenty plantyB;
            Plenty res;
            int num;

            labelRes.Text = "Результат:\n";

            switch (cmbOperation.Text)
            {
                case "Объединение":
                    plantyA = new Plenty(txtPlentyA.Text);
                    plantyB = new Plenty(txtPlentyB.Text);

                    res = plantyA + plantyB;

                    labelRes.Text += res.MatrixToString();
                    break;
                case "Пересечение":
                    plantyA = new Plenty(txtPlentyA.Text);
                    plantyB = new Plenty(txtPlentyB.Text);

                    res = plantyA * plantyB;
                    labelRes.Text += res.MatrixToString();
                    break;
                case "Разность":
                    plantyA = new Plenty(txtPlentyA.Text);
                    plantyB = new Plenty(txtPlentyB.Text);

                    res = plantyA - plantyB;

                    labelRes.Text += res.MatrixToString();
                    break;
                case "Добавление элемента":
                    plantyA = new Plenty(txtPlentyA.Text);
                    num = int.Parse(txtPlentyB.Text);

                    res = plantyA + num;

                    labelRes.Text += res.MatrixToString();
                    break;
                case "Удаление элемента":
                    plantyA = new Plenty(txtPlentyA.Text);
                    num = int.Parse(txtPlentyB.Text);

                    res = plantyA - num;

                    labelRes.Text += res.MatrixToString();
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbOperation.Text) 
            {
                case "Добавление элемента":
                    labelPlentyB.Text = "Элемент";
                    break;
                case "Удаление элемента":
                    labelPlentyB.Text = "Элемент";
                    break;
            }
        }

    }




    public class Plenty {

        private int[] plenty;
        private int n;

        // Чтобы заполнить матрицу случайными числами
        static Random rand = new Random();

        // Несколько конструкторов
        public Plenty(int n_)
        {
            var plenty_ = new int[n];

            for (int i = 0; i < n; i++)
            {
                var tmp = rand.Next() % 100;

                if (plenty.Any(num => num == tmp))
                {
                   i--;
                }
                else
                {
                    plenty[i] = tmp;
                }
                
            }

            this.plenty = NormalizeSet(plenty_);
            this.n = plenty.Length;
        }

        public Plenty(int[] plenty_)
        {
            this.plenty = NormalizeSet(plenty_);
            this.n = plenty.Length;
        }

        public Plenty(string text)
        {
            this.plenty = NormalizeSet(TextToMatrix(text));
            this.n = plenty.Length;
        }

        // Получить размер вектора
        public int Size
        {
            get 
            {
                return n;
            }
        }

        // Посмотреть какой вектор лежит внутри объекта
        public int[] Array
        {
            get
            {
                return plenty;
            }
        }

        // Индексатор
        public int this[int i]
        {
            get
            {
                return plenty[i];
            }
            set
            {
                plenty[i] = value;
            }
        }

        public override bool Equals(object obj)
        {
            // Преобразовываем переданный объект в множетсво
            var B = obj as Plenty;

            if (B == null)
                return false; // Если не множество, то значит точно не совпадает

            for (var i = 0; i < this.Size; ++i)
            {
                //  ищем первый несовпавший элемент
                if (this[i] != B[i])
                    return false; // если найдем, значит не совпадают

            }
            return true; // Иначе все совпало
        }

        public static Plenty operator +(Plenty plentyFirst, Plenty plentySecond)
        {
            var numbers = new List<int>();

            numbers.AddRange(plentyFirst.Array);

            for (int i = 0; i < plentySecond.Size; i++)
            {
                //Проверим, чтобы числа в массиве не повторялись
                if (!numbers.Contains(plentySecond[i]))
                {
                    numbers.Add(plentySecond[i]);
                }
            }

            //Приводим numbers в объект Plenty
            var resPlenty = new Plenty(numbers.ToArray<int>());

            return resPlenty;
        }

        public static Plenty operator *(Plenty plentyFirst, Plenty plentySecond)
        {
            var numbers = new List<int>();

            for (int i = 0; i < plentyFirst.Size; i++)
            {
                for (int j = 0; j < plentySecond.Size; j++)
                {
                    //Если число есть в обоих массивах и мы его еще не получали, то
                    if (plentyFirst[i] == plentySecond[j] && !numbers.Contains(plentyFirst[i]))
                    {
                        //Добавляем
                        numbers.Add(plentyFirst[i]);
                    }
                }
            }

            //Приводим numbers в объект Plenty
            var resPlenty = new Plenty(numbers.ToArray<int>());

            return resPlenty;
        }

        public static Plenty operator -(Plenty plentyFirst, Plenty plentySecond)
        {
            var numbers = new List<int>();

            //Добавим в numbers, элементы, полученного объекта
            numbers.AddRange(plentyFirst.Array);

            for (int i = 0; i < plentySecond.Size; i++)
            {
                //Если число не содержится в массиве, то
                if (!numbers.Contains(plentySecond[i]))
                {
                    //Добавляем
                    numbers.Add(plentySecond[i]);
                } else
                {
                    //Удаляем
                    numbers.Remove(plentySecond[i]);
                }
            }

            //Приводим numbers в объект Plenty
            var resPlenty = new Plenty(numbers.ToArray<int>());

            return resPlenty;
        }

        public static Plenty operator +(Plenty plentyFirst, int num)
        {
            var numbers = new List<int>();
            //Добавим в numbers, элементы, полученного объекта
            numbers.AddRange(plentyFirst.Array);

            //Если число не содержится в массиве, то
            if (!numbers.Contains(num))
            {
                //Добавляем
                numbers.Add(num); 
            }

            //Приводим numbers в объект Plenty
            var resPlenty = new Plenty(numbers.ToArray<int>());

            return resPlenty;
        }

        public static Plenty operator -(Plenty plentyFirst, int num)
        {
            var numbers = new List<int>();
            //Добавим в numbers, элементы, полученного объекта
            numbers.AddRange(plentyFirst.Array);

            //Если число содержится в массиве, то
            if (numbers.Contains(num))
            {
                //Удаляем
                numbers.Remove(num);
            }

            //Приводим numbers в объект Plenty
            var resPlenty = new Plenty(numbers.ToArray<int>());

            return resPlenty;
        }

        //Обратные операторы
        public static Plenty operator +(int num, Plenty plentyFirst)
        {
            return plentyFirst + num;
        }

        public static Plenty operator -(int num, Plenty plentyFirst)
        {
            return plentyFirst - num;
        }

        //Преобразуем текст в матрицу
        private int[] TextToMatrix(string text)
        {
            //Разделим строку на элементы
            var line = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            //Узнаем количество элементов
            var colsCount = line.Length;

            //Преобразуем в матрицу
            var matrix = new int[colsCount];
            for (var i = 0; i < line.Length; ++i)
            { 
                matrix[i] = int.Parse(line[i]);
            }

            return matrix;
        }

        private int[] NormalizeSet(int[] setSrc)
        {
            return setSrc.Distinct().ToArray();
        }

        public string MatrixToString()
        {
            string res = "";

            for (int i = 0; i < this.Size; i++)
            {
                if (i == this.Size - 1)
                {
                    res += plenty[i].ToString();
                }
                else
                {
                    res += plenty[i] + " ";
                }
            }

            return res;
        }
    }


}

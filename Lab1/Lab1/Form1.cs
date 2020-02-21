using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {

        Matrix matrixA;
        Matrix matrixB;
        Matrix matrixC;

        public Form1()
        {
            InitializeComponent();            
        }      

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMatrixA.Text == "")
            {
                matrixA = new Matrix(4);
            }
            else
            {
                matrixA = new Matrix(txtMatrixA.Text);
            }
            if (txtMatrixB.Text == "")
            {
                matrixB = new Matrix(4);             
            }
            else
            {
                matrixB = new Matrix(txtMatrixB.Text);
            }
            if (txtMatrixC.Text == "")
            {
                matrixC = new Matrix(4);
            }
            else
            {
                matrixC = new Matrix(txtMatrixC.Text);
            }

            resultLabel.Text = Logic.SomeMatrixOperation(matrixA, matrixB, matrixC);
            txtMatrixA.Text = matrixA.PrintMatrix();
            txtMatrixB.Text = matrixB.PrintMatrix();
            txtMatrixC.Text = matrixC.PrintMatrix();
        }

    }
    
    public class Matrix
    {
        private int[,] matrix;
        //Размер матрицы
        private int n;
        
        //Число четных и нечетных элементов матрицы
        public int evenNumbers;
        public int oddNumbers;

        static Random rand = new Random();
        delegate bool IsEqual(int x);

        //Если передали матрицу, то запишем ее
        public Matrix(int[,] matrix_)
        {
            this.matrix = matrix_;

            //Посчитаем четные и нечетные элементы нашей матрицы, кроме нолика. Нолик ни четное, ни нечетное!
            evenNumbers = GetNumberCount(this, x => x % 2 == 0 && x != 0);
            oddNumbers = GetNumberCount(this, x => x % 2 == 1);
        }

        //Формируем матрицу на основе заданного размера
        public Matrix(int n)
        {
            this.matrix = new int[n, n];
            this.n = n;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next() % 10;
                }
            }

            //Посчитаем четные и нечетные элементы нашей матрицы, кроме нолика. Нолик ни четное, ни нечетное!
            evenNumbers = GetNumberCount(this, x => x % 2 == 0 && x != 0);
            oddNumbers = GetNumberCount(this, x => x % 2 == 1);
        }

        public Matrix(string text)
        {
            this.matrix = TextToMatrix(text);
        }

        public object Clone()
        {
            return new Matrix(matrix);
        }

        //Вернем размер нашей матрицы
        public int Size
        {
            get 
            {
                return n;
            }
        }

        //Индексатор для обращения
        public int this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                matrix[i, j] = value;
            }
        }

        //Сравнение для тестов
        public override bool Equals(object obj)
        {
            //Объект преобразовываем в матрицу
            var B = obj as Matrix;

            // если преобразование не удалось, то есть если B не матрица, то в B окажется null
            if (B == null)
                return false;

            // Если это матрица
            for (var i = 0; i < this.Size; ++i)
            {
                for (var j = 0; j < this.Size; ++j)
                {
                    //  ищем первый несовпавший элемент
                    if (this[i, j] != B[i, j])
                        return false;
                }
            }
            return true;
        }

        //Найдем числа, удовлетворяющие переданной функции
        private int GetNumberCount(Matrix matrix, IsEqual func)
        {
            int count = 0;

            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    //Если функция вернет вернет true, значит это число нам подходит
                    if (func(matrix[i, j]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static Matrix operator -(Matrix matrixFirst, Matrix matrixSecond)
        {

            var resMatrix = new Matrix(matrixFirst.Size);

            for (int i = 0; i < matrixFirst.Size; i++)
            {
                for (int j = 0; j < matrixFirst.Size; j++)
                {
                    resMatrix[i, j] = matrixFirst[i, j] - matrixSecond[i, j];
                }
            }

            return resMatrix;
        }

        public static Matrix operator +(Matrix matrixFirst, Matrix matrixSecond)
        {

            var resMatrix = new Matrix(matrixFirst.Size);

            for (int i = 0; i < matrixFirst.Size; i++)
            {
                for (int j = 0; j < matrixFirst.Size; j++)
                {
                    resMatrix[i, j] = matrixFirst[i, j] + matrixSecond[i, j];
                }
            }

            return resMatrix;
        }

        public static Matrix operator +(Matrix matrixFirst, int number)
        {
            var resMatrix = new Matrix(matrixFirst.Size);

            for (int i = 0; i < matrixFirst.Size; i++)
            {
                for (int j = 0; j < matrixFirst.Size; j++)
                {
                    //Проверяем, находится ли число на главной диагонали
                    if (i == j)
                    {
                        //Увеличиваем элемент главной диагонали, т. к. число с матрицей складывается как матрица и матрица, на главной диагонали которой это число
                        resMatrix[i, j] = matrixFirst[i, j] + number;
                    }
                    else
                    {
                        resMatrix[i, j] = matrixFirst[i, j];
                    }
                }
            }

            return resMatrix;
        }
        //Обратный оператор сложения
        public static Matrix operator +(int number, Matrix matrixFirst)
        {
            return matrixFirst + number;
        }
 
        public static Matrix operator *(Matrix matrix, int coeff)
        {
            var resMatrix = new Matrix(matrix.Size);

            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    resMatrix[i, j] = matrix[i, j] * coeff;
                }
            }

            return resMatrix;
        }
        //Обратный оператор умножения
        public static Matrix operator *(int coeff, Matrix matrix)
        {
            return coeff * matrix;
        }

        //Вернем строковое представление матрицы
        public string PrintMatrix()
        {
            string res = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res += matrix[i, j] + " ";
                }

                res += "\n";
            }

            return res;
        }

        //Транспонируем матрицу
        public Matrix GetTransposeMatrix()
        {
            Matrix resMatrix = new Matrix(this.Size);

            for (int i = 0; i < this.Size; i++)
            {
                //Нужно перебрать половину матрицы, для транспонирования
                for (int j = i; j < this.Size; j++)
                {
                    /*int tmp = resMatrix[i, j];
                    resMatrix[i, j] = resMatrix[j, i];
                    resMatrix[j, i] = tmp;*/
                    resMatrix[i, j] = this[j, i];
                }
            }

            return resMatrix;
        }

        //Преобразуем текст в матрицу
        private int[,] TextToMatrix(string text)
        {
            //Разделим на строки
            var lines = text.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
            //Узнаем количество строк
            var colsCount = lines[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
            var rowsCount = lines.Length;

            //Преобразуем в матрицу
            var matrix = new int[rowsCount, colsCount];
            for (var i = 0; i < lines.Length; ++i)
            {
                var elements = lines[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (var j = 0; j < elements.Length; ++j)
                {
                    matrix[i, j] = int.Parse(elements[j]);
                }
            }

            return matrix;        
        }
    }

    class Logic
    {
        //Посчитаем наше уравнение
        public static string SomeMatrixOperation(Matrix matrixA, Matrix matrixB, Matrix matrixC)
        {
            string msg;

            if (matrixB.evenNumbers > matrixA.evenNumbers + matrixC.oddNumbers)
            {
                Matrix resMatrix;

                resMatrix = matrixB - matrixC;
                resMatrix = resMatrix.GetTransposeMatrix();

                resMatrix *= 3;

                resMatrix += matrixA;

                msg = resMatrix.PrintMatrix();
            }
            else
            {
                Matrix resMatrix;

                resMatrix = matrixA * 3;
                resMatrix -= matrixB.GetTransposeMatrix();

                resMatrix += 2;

                resMatrix -= matrixC;

                msg = resMatrix.PrintMatrix();
            }

            return msg;
        }
    }
}


/*int[,] matrixA = new int[4, 4] {
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12},
    {13, 14, 15, 16}
};
int[,] matrixB = new int[4, 4] {
    {10, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12},
    {13, 14, 15, 16}
};
int[,] matrixC = new int[4, 4] {
    {1, 2, 3, 4},
    {5, 6, 7, 8},
    {9, 10, 11, 12},
    {13, 14, 15, 16}
};*/

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

            matrixA = new Matrix(4);
            matrixB = new Matrix(4);
            matrixC = new Matrix(4);

            txtMatrixA.Text = matrixA.printMatrix();
            txtMatrixB.Text = matrixB.printMatrix();
            txtMatrixC.Text = matrixC.printMatrix();
        }      

        private void button1_Click(object sender, EventArgs e)
        {

            resultLabel.Text = "\n" + Logic.someMatrixOperation(matrixA, matrixB, matrixC);

        }

    }

    public class Matrix
    {
        public int[,] matrix;

        static Random rand = new Random();

        public Matrix(int[,] matrix_)
        {
            this.matrix = matrix_;
        }

        public Matrix(int n)
        {
            this.matrix = new int[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next() % 10;
                }
            }
        }

        public int getEvenCount()
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public int getOddCount()
        {
            int count = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 != 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int[,] operator -(Matrix matrix, Matrix matrixSecond)
        {

            int[,] resMatrix = matrix.matrix;

            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMatrix.GetLength(1); j++)
                {
                    resMatrix[i, j] = resMatrix[i, j] - matrixSecond.matrix[i, j];
                }
            }

            return resMatrix;
        }

        public static int[,] operator +(Matrix matrix, Matrix matrixSecond)
        {

            int[,] resMatrix = matrix.matrix;

            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMatrix.GetLength(1); j++)
                {
                    resMatrix[i, j] = resMatrix[i, j] + matrixSecond.matrix[i, j];
                }
            }

            return resMatrix;
        }

        public static int[,] operator +(Matrix matrix, int number)
        {
            int[,] resMatrix = matrix.matrix;

            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                resMatrix[i, i] = resMatrix[i, i] + number;
            }

            return resMatrix;
        }

        public int[,] getSumMatrix(int coeff)
        {
            int[,] resMatrix = matrix;

            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMatrix.GetLength(1); j++)
                {
                    resMatrix[i, j] = resMatrix[i, j] + coeff;
                }
            }

            return resMatrix;
        }

        public string printMatrix()
        {
            string res = "";

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res += matrix[i, j] + ", ";
                }

                res += "\n";
            }

            return res;
        }

        public int[,] getTransposeMatrix()
        {
            int[,] resMatrix = matrix;

            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                for (int j = i; j < resMatrix.GetLength(1); j++)
                {
                    int tmp = resMatrix[i, j];
                    resMatrix[i, j] = resMatrix[j, i];
                    resMatrix[j, i] = tmp;
                }
            }

            return resMatrix;
        }

        public static int[,] operator *(Matrix matrix, int coeff)
        {
            int[,] resMatrix = matrix.matrix;

            for (int i = 0; i < resMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMatrix.GetLength(1); j++)
                {
                    resMatrix[i, j] = resMatrix[i, j] * coeff;
                }
            }

            return resMatrix;
        }

        public int[,] textToMatrix(string text)
        {
            var lines = text.Split(new string[] { Environment.NewLine, "\n" }, StringSplitOptions.RemoveEmptyEntries);
            var colsCount = lines[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
            var rowsCount = lines.Length;

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
        public static string someMatrixOperation(Matrix matrixA, Matrix matrixB, Matrix matrixC)
        {
            string msg = "";

            if (matrixB.getEvenCount() > matrixA.getEvenCount() + matrixC.getOddCount())
            {
                matrixB.matrix = matrixB - matrixC;
                matrixB.matrix = matrixB.getTransposeMatrix();

                matrixB.matrix = matrixB * 3;

                matrixB.matrix = matrixB + matrixA;

                msg = matrixB.printMatrix();
            }
            else
            {
                matrixA.matrix = matrixA * 3;
                matrixB.matrix = matrixB.getTransposeMatrix();

                matrixA.matrix = matrixA - matrixB;
                matrixA.matrix = matrixA + 2;

                matrixA.matrix = matrixA - matrixC;

                msg = matrixA.printMatrix();
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

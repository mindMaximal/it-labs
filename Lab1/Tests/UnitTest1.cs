using NUnit.Framework;

namespace Lab1
{
    public class Tests
    {
     
        [Test]
        public void TestOperatorPlusInt()
        {
            int[,] matrixB_ = new int[4, 4] {
                {10, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };
            
            Matrix matrixB = new Matrix(matrixB_);

            int[,] matrixRes = {
                {12, 2, 3, 4},
                {5, 8, 7, 8},
                {9, 10, 13, 12},
                {13, 14, 15, 18}
            };

            var matrixTmp = matrixB + 2;

            CollectionAssert.AreEqual(matrixTmp, matrixRes);
        }

        [Test]
        public void TestOperatorPlusMatrix()
        {
            int[,] matrixA_ = {
                {2, 4, 6, 8},
                {10, 12, 14, 16},
                {18, 20, 22, 24},
                {26, 28, 30, 32},
            };
            int[,] matrixC_ = {
                { 1, 2, 3, 4},
                { 5, 6, 7, 8},
                { 9, 10, 11, 12},
                { 13, 14, 15, 16}
            };

            Matrix matrixA = new Matrix(matrixA_);
            Matrix matrixC = new Matrix(matrixC_);

            int[,] matrixRes = {
                {3, 6, 9, 12},
                {15, 18, 21, 24},
                {27, 30, 33, 36},
                {39, 42, 45, 48},
            };

            var matrixTmp = matrixA + matrixC;

            CollectionAssert.AreEqual(matrixTmp, matrixRes);
        }

        [Test]
        public void TestOperatorMinusMatrix()
        {
            int[,] matrixA_ = new int[4, 4] {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };
            int[,] matrixC_ = new int[4, 4] {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };

            Matrix matrixA = new Matrix(matrixA_);
            Matrix matrixC = new Matrix(matrixC_);

            int[,] matrixRes = {
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
                {0, 0, 0, 0},
            };

            var matrixTmp = matrixA - matrixC;

            CollectionAssert.AreEqual(matrixTmp, matrixRes);
        }

        [Test]
        public void TestTransponseMatrix()
        {
            int[,] matrixA_ = new int[4, 4] {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 11, 12},
                {13, 14, 15, 16}
            };

            int[,] matrixRes = {
                {1, 5, 9, 13},
                {2, 6, 10, 14},
                {3, 7, 11, 15},
                {4, 8, 12, 16},
            };

            Matrix matrixA = new Matrix(matrixA_);

            CollectionAssert.AreEqual(matrixA.getTransposeMatrix(), matrixRes); 
        }
    }
}
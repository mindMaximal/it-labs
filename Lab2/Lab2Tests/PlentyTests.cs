using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Tests
{
    [TestClass()]
    public class PlentyTests
    {
        [TestMethod()]
        public void PlentyTestOperatorPlus()
        {
            int[] firstVector = { 0, 1, 2, 3 };
            int[] secondVector = { 4, 5 };
            Plenty first = new Plenty(firstVector);
            Plenty second = new Plenty(secondVector);

            var tmp = first + second;
            
            int[] resArray = {0, 1, 2, 3, 4, 5};

            Plenty res = new Plenty(resArray);

            Assert.AreEqual(tmp, res);
        }

        [TestMethod()]
        public void PlentyTestOperatorMultiplication()
        {
            int[] firstVector = { 0, 1, 2, 3 };
            int[] secondVector = { 1, 2, 4, 5 };
            Plenty first = new Plenty(firstVector);
            Plenty second = new Plenty(secondVector);

            var tmp = first * second;

            int[] resArray = { 1, 2 };

            Plenty res = new Plenty(resArray);

            Assert.AreEqual(tmp, res);
        }

        [TestMethod()]
        public void PlentyTestOperatorMinus()
        {
            int[] firstVector = { 0, 1, 2, 3 };
            int[] secondVector = { 1, 2, 4, 5 };
            Plenty first = new Plenty(firstVector);
            Plenty second = new Plenty(secondVector);

            var tmp = first - second;

            int[] resArray = { 0, 3, 4, 5};

            Plenty res = new Plenty(resArray);

            Assert.AreEqual(tmp, res);
        }

        [TestMethod()]
        public void PlentyTestOperatorPlusInt()
        {
            int[] firstVector = { 0, 1, 2, 3 };
            Plenty first = new Plenty(firstVector);
            int num = 5;

            var tmp = first + num;

            int[] resArray = { 0, 1, 2, 3, 5 };

            Plenty res = new Plenty(resArray);

            Assert.AreEqual(tmp, res);
        }

        [TestMethod()]
        public void PlentyTestOperatorMinusInt()
        {
            int[] firstVector = { 0, 1, 2, 3 };
            Plenty first = new Plenty(firstVector);
            int num = 3;

            var tmp = first - num;

            int[] resArray = { 0, 1, 2 };

            Plenty res = new Plenty(resArray);

            Assert.AreEqual(tmp, res);
        }

        [TestMethod()]
        public void NormalizeSetTest()
        {
            int[] firstVector = { 0, 1, 1, 2, 3 };
            Plenty first = new Plenty(firstVector);

            int[] secondVector = { 0, 1, 2, 3 };
            Plenty res = new Plenty(secondVector);

            Assert.AreEqual(first, res);

        }

    }
}
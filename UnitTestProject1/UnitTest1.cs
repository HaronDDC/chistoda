using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private Dictionary<string, Dictionary<string, int>> _mockInput;// = new Dictionary<string, Dictionary<string, int>>();

        private string Tr_1 = "Trans_1";
        private string Tr_2 = "Trans_2";
        private string Tr_3 = "Trans_3";

        private string Eq_1 = "Eq_1";
        private string Eq_2 = "Eq_2";
        private string Eq_3 = "Eq_3";

        private int[,] _mockInput_2 = new int[,] { { 15, 10, 9 }, { 9, 15, 10 }, { 10, 12, 8 } };
        private int[,] _mockInput_3 = new int[,] { { 1, 4, 6, 3 }, { 9, 7, 10, 9 }, { 4, 5, 11, 7 }, { 8, 7, 8, 5 } };

        [TestInitialize]
        public void Init()
        {
            _mockInput = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> row = new Dictionary<string, int>();

            row.Add(Eq_1, 15);
            row.Add(Eq_2, 10);
            row.Add(Eq_3, 9);

            _mockInput.Add(Tr_1, row);

            row = new Dictionary<string, int>();
            row.Add(Eq_1, 9);
            row.Add(Eq_2, 15);
            row.Add(Eq_3, 10);
            _mockInput.Add(Tr_2, row);

            row = new Dictionary<string, int>();
            row.Add(Eq_1, 10);
            row.Add(Eq_2, 12);
            row.Add(Eq_3, 8);
            _mockInput.Add(Tr_3, row);
        }


        [TestMethod]
        public void TestMethod1()
        {
            var result = Assign.Compute(_mockInput_2, 3, 3);
            Assert.IsTrue(result[0].Item1 == 0);
            Assert.IsTrue(result[0].Item2 == 1);

            Assert.IsTrue(result[1].Item1 == 1);
            Assert.IsTrue(result[1].Item2 == 0);

            Assert.IsTrue(result[2].Item1 == 2);
            Assert.IsTrue(result[2].Item2 == 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var result = Assign.GetMinimum(_mockInput[Tr_1]);
            Assert.IsTrue(result.Key == Eq_3);
            Assert.IsTrue(result.Value == 9);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var result = Assign.Compute(_mockInput_2, 3, 3);
            Assert.IsTrue(result[0].Item1 == 0);
            Assert.IsTrue(result[0].Item2 == 0);

            Assert.IsTrue(result[1].Item1 == 1);
            Assert.IsTrue(result[1].Item2 == 2);

            Assert.IsTrue(result[2].Item1 == 2);
            Assert.IsTrue(result[2].Item2 == 1);

            Assert.IsTrue(result[2].Item1 == 3);
            Assert.IsTrue(result[2].Item2 == 3);
        }
    }
}

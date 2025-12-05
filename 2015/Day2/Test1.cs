using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.NetworkInformation;

namespace Day2
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input = "2x3x4";
            int result = Calculate(input);
            Assert.AreEqual(58, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string input = "1x1x10";
            int result = Calculate(input);
            Assert.AreEqual(43, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string[] inputs = new string[] { "2x3x4", "1x1x10" };
            int result = Calculate(inputs);
            Assert.AreEqual(101, result);
        }


        [TestMethod]
        public void TestMethod4()
        {
            string[] inputs = File.ReadAllLines("puzzle.txt");
            int result = Calculate(inputs);
            Assert.AreEqual(1606483, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string input = "2x3x4";
            int result = Calculate2(input);
            Assert.AreEqual(34, result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string input = "1x1x10";
            int result = Calculate2(input);
            Assert.AreEqual(14, result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            string[] input = new string[] {"1x1x10","2x3x4"};
            int result = Calculate2(input);
            Assert.AreEqual(48, result);
        }  
        
        [TestMethod]
        public void TestMethod8()
        {
            string[] input = File.ReadAllLines("puzzle.txt");
            int result = Calculate2(input);
            Assert.AreEqual(3842356, result);
        }

        private int Calculate2(string[] inputs)
        {
            int total = 0;
            foreach (string input in inputs)
            {
                total += Calculate2(input);
            }

            return total;
        }

        private int Calculate(string[] inputs)
        {
            int total = 0;
            foreach (string input in inputs)
            {
                total += Calculate(input);
            }

            return total;
        }

        private int Calculate2(string input)
        {
            (int l, int w, int h) dimensions = GetDimensions(input);
            List<int> sides = new List<int> { dimensions.l, dimensions.w, dimensions.h };

            int min1 = (new int[] { dimensions.l, dimensions.w, dimensions.h }).Min();

            sides.Remove(min1);
            int min2 = sides.Min();


            return (min1 + min1 + min2 + min2 + (dimensions.l * dimensions.w * dimensions.h));
        }

        private int Calculate(string input)
        {
            (int l, int w, int h) dimensions = GetDimensions(input);
            int lw = dimensions.l * dimensions.w;
            int wh = dimensions.w * dimensions.h;
            int hl = dimensions.h * dimensions.l;


            int slack = (new int[] { lw, wh, hl }).Min();
            int surfaceArea = 2 * lw + 2 * wh + 2 * hl;

            return slack + surfaceArea;
        }

        private (int l, int w, int h) GetDimensions(string input)
        {
            string[] split = input.Split('x');
            return (int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));
        }

    }
}

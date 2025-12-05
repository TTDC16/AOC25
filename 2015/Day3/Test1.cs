namespace Day3
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input = ">";
            int result = Deliver(input);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string input = "^>v<";
            int result = Deliver(input);
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string input = "^v^v^v^v^v";
            int result = Deliver(input);
            Assert.AreEqual(2, result);
        }


        [TestMethod]
        public void TestMethod4()
        {
            string input = File.ReadAllText("puzzle.txt");
            int result = Deliver(input);
            Assert.AreEqual(2565, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string input = "^v";
            int result = Deliver2(input);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            string input = "^>v<";
            int result = Deliver2(input);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            string input = "^v^v^v^v^v";
            int result = Deliver2(input);
            Assert.AreEqual(11, result);
        }

        [TestMethod]
        public void TestMethod8()
        {
            string input = File.ReadAllText("puzzle.txt");
            int result = Deliver2(input);
            Assert.AreEqual(2639, result);
        }

        private int Deliver2(string moves)
        {
            List<(int x, int y)> visited1 = new List<(int x, int y)>() { (0, 0) };
            List<(int x, int y)> visited2 = new List<(int x, int y)>() { (0, 0) };


            for (int i = 0; i < moves.Length; i++)
            {
                bool p1Turn = i % 2 == 0;

                (int x, int y) position = i % 2 == 0 ? visited1.Last() : visited2.Last();
                char move = moves[i];
                if (move == '<')
                {
                    position.x -= 1;
                }

                if (move == '>')
                {
                    position.x += 1;
                }

                if (move == '^')
                {
                    position.y -= 1;
                }

                if (move == 'v')
                {
                    position.y += 1;
                }

                if (p1Turn)
                    visited1.Add(position);
                else
                    visited2.Add(position);

            }

            return visited1.Concat(visited2).Distinct().Count();



        }

        private int Deliver(string moves)
        {
            List<(int x, int y)> visited = new List<(int x, int y)>();
            (int x, int y) position = (0, 0);
            visited.Add(position);
            foreach (char move in moves)
            {
                if (move == '<')
                {
                    position.x -= 1;
                    visited.Add(position);
                }

                if (move == '>')
                {
                    position.x += 1;
                    visited.Add(position);
                }

                if (move == '^')
                {
                    position.y -= 1;
                    visited.Add(position);
                }

                if (move == 'v')
                {
                    position.y += 1;
                    visited.Add(position);
                }
            }

            return visited.Distinct().Count();


        }
    }
}

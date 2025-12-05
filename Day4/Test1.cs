using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day4
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int run = Run("example.txt");
            Assert.AreEqual(13, run);
        }

        [TestMethod]
        public void TestMethod2()
        {
            
            int run = Run("puzzle.txt");
            Assert.AreEqual(13, run);
        }

        [TestMethod]
        public void TestMethod3()
        {
            bool[][] map = BuildMap("example.txt");
            bool[][] newMap = CloneMap(map);
            int count = 0;
            int result = 0;

            do
            {
                count = Run2(map, out newMap);
                map = CloneMap(newMap);
                result += count;

            } while (count > 0);

            

            Assert.AreEqual(43, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            bool[][] map = BuildMap("puzzle.txt");
            bool[][] newMap = CloneMap(map);
            int count = 0;
            int result = 0;

            do
            {
                count = Run2(map, out newMap);
                map = CloneMap(newMap);
                result += count;

            } while (count > 0);



            Assert.AreEqual(43, result);
        }


        private int Run2(bool[][] map, out bool[][] newMap)
        {
            newMap = CloneMap(map);


            int count = 0;
            int rowCount = map.GetLength(0);
            int colCount = map[0].Length;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    int? neighbourCount = CountNeighbour(map, row, col);
                    if (neighbourCount is < 4)
                    {
                        newMap[row][col] = false;
                        count++;
                    }
                }
            }

            return count;
        }


        private int Run(string fileName)
        {
            bool[][] map = BuildMap(fileName);

            int count = 0;
            int rowCount = map.GetLength(0);
            int colCount = map[0].Length;

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    int? neighbourCount = CountNeighbour(map, row, col);
                    if (neighbourCount is < 4)
                    {
                        count++;
                    }
                }
            }

            return count;
            
        }

        private int? CountNeighbour(bool[][] map, int row, int col)
        {
            if (!map[row][col])
                return null;

            int count = 0;
            int rowCount = map.GetLength(0);
            int colCount = map[0].Length;

            if (row - 1 >= 0 && col - 1 >= 0)
                count += map[row - 1][col - 1] ? 1 : 0;
            if (row - 1 >= 0)
                count += map[row - 1][col] ? 1 : 0;
            if (row - 1 >= 0 && col + 1 < colCount)
                count += map[row - 1][col + 1] ? 1 : 0;

            if (col - 1 >= 0)
                count += map[row][col - 1] ? 1 : 0;
            if (col + 1 < colCount)
                count += map[row][col + 1] ? 1 : 0;

            if (row + 1 < rowCount && col - 1 >= 0)
                count += map[row + 1][col - 1] ? 1 : 0;
            if (row + 1 < rowCount)
                count += map[row + 1][col] ? 1 : 0;
            if (row + 1 < rowCount && col + 1 < colCount)
                count += map[row + 1][col + 1] ? 1 : 0;

            return count;
        }


        private bool[][] BuildMap(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            bool[][] map = new bool[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                map[i] = line.Select(c => c == '@').ToArray();
            }

            return map;

        }

        private bool[][] CloneMap(bool[][] map)
        {
            int rowCount = map.GetLength(0);
            int colCount = map[0].Length;

            bool[][] newMap = new bool[rowCount][];
            for (int row = 0; row < rowCount; row++)
            {
                newMap[row] = new bool[colCount];
            }

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    newMap[row][col] = map[row][col];
                }
            }

            return newMap;
        }
    }
}

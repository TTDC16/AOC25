namespace Day3
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Example1()
        {
            string[] batteryBanks = File.ReadAllLines("puzzle.txt");

            ulong result = 0;


            foreach (string batteryBank in batteryBanks)
            {
                int[] batteries = batteryBank.Select(c => c - '0').ToArray();

                int[] targetBatteries = new int[12];

                int indexOfLast = 0;

                for (int i = 0; i < 12; i++)
                {
                    for (int j = 9; j >= 0; j--)
                    {
                        bool foundB = false;
                        for (int b = indexOfLast; b <= batteries.Length - (12 - i); b++)
                        {
                            if (batteries[b] == j)
                            {
                                targetBatteries[i] = batteries[b];
                                indexOfLast = b + 1;
                                foundB = true;
                                break;
                            }
                        }
                        if(foundB)
                            break;
                    }
                }

                string s = new string(targetBatteries.Select(b => b.ToString()[0]).ToArray());
                result += ulong.Parse(s);

                Console.WriteLine(targetBatteries);
            }

            Assert.AreEqual((ulong)3121910778619, result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            string[] batteryBanks = File.ReadAllLines("puzzle.txt");
            ulong result = 0;

            //foreach (string batteryBank in batteryBanks)
            //{
            //    char[] batteries = batteryBank.ToArray();
            //    char first = GetMaxBattery(batteries, 0, out int indexOfMax);
            //    char second = GetMaxBattery(batteries, indexOfMax + 1, out _);

            //    string joltage = new string(new[] { first, second });
            //    result += ulong.Parse(joltage);

            //}

            Assert.AreEqual((ulong)357, result);
        }


        private char GetMaxBattery(char[] batteries, int offset, List<int> usedIndexes, out int indexOfMax)
        {
            indexOfMax = -1;
            char c = Char.MinValue;

            int length = offset == 0 ? batteries.Length - 12 : batteries.Length;

            for (int i = offset; i < length; i++)
            {
                if (batteries[i] > c)
                {
                    if (usedIndexes.Contains(i))
                        continue;


                    c = batteries[i];
                    indexOfMax = i;
                }
            }

            return c;
        }
    }
}

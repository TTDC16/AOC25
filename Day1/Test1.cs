namespace Day1
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Example()
        {
            string[] lines = File.ReadAllLines("Data\\Puzzle1.txt");
            int index = 50;
            const int max = 100;
            int zeros = 0;

            foreach (string operation in lines)
            {
                bool left = operation[0] == 'L';
                int value = int.Parse(operation.Substring(1));

                if (left)
                {
                    bool indexWas0 = index == 0;
                    bool firstRound = true;

                    index -= value;


                    if (index < 0)
                    {
                        do
                        {
                            if (!indexWas0)
                            {
                                zeros++;
                            }
                            else
                            {
                                if (!firstRound)
                                    zeros++;
                                firstRound = false;

                            }


                        } while ((index += 100) < 0);
                    }

                    if (index == 0)
                        zeros++;

                }
                else
                {
                    index += value;
                    if (index > 99)
                    {
                        do
                        {
                            zeros++;
                        } while ((index -= 100) > 99);
                    }



                }
            }
            // Too Low: 5828
            Assert.AreEqual(5831, zeros);

        }



    }
}

using System.Security.Authentication;
using System.Security.Cryptography;

namespace Day5
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            (string[], string[]) data = GetData();

            string[] ranges = data.Item1;
            string[] availables = data.Item2;


            List<Range> rangeList = new List<Range>();

            foreach (string range in ranges)
            {
                string[] parts = range.Split('-');
                ulong start = ulong.Parse(parts[0]);
                ulong end = ulong.Parse(parts[1]);

                Range newRange = new Range() { Start = start, End = end };
                rangeList.Add(newRange);

            }


            long sum = 0;
            List<ulong> list = new List<ulong>();

            SHA256 sha = SHA256.Create();

            foreach (Range range in rangeList)
            {
                for(ulong i = range.Start; i <= range.End; i++)
                {
                    if(!list.Contains(i))
                        list.Add(i);
                }
            }

            sum = list.Count;

            Assert.AreEqual(14, sum);




          


        }

        private (string[], string[]) GetData()
        {
            string[] lines = File.ReadAllLines("puzzle.txt");

            List<string> ranges = new List<string>();
            List<string> availables = new List<string>();
            bool inRanges = true;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    inRanges = false;
                    continue;
                }

                if (inRanges)
                {
                    ranges.Add(line);
                }
                else
                {
                    availables.Add(line);
                }
            }

            return (ranges.ToArray(), availables.ToArray());

        }
    }

    class Range
    {
        public ulong Start { get; set; }
        public ulong End { get; set; }

        public bool IsInRange(ulong value)
        {
            return value >= Start && value <= End;
        }

        public ulong GetCount()
        {
            return End - Start + 1;
        }
    }


  
}

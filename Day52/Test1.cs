using System.Collections.Concurrent;

namespace Day52
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            (string[], string[]) data = GetData("puzzle.txt");
            string[] rangeStrings = data.Item1;
            
            List<(ulong, ulong)> ranges = new List<(ulong, ulong)>();
            foreach (string rangeString in rangeStrings)
            {
                string[] parts = rangeString.Split('-');
                ulong start = ulong.Parse(parts[0]);
                ulong end = ulong.Parse(parts[1]);
                ranges.Add((start, end));
            }

            ulong coveredCount = TotalCoveredCount(ranges);
        }

        public static ulong TotalCoveredCount(List<(ulong start, ulong end)> ranges)
        {
            if (ranges.Count == 0) return 0;

            // Sort by start
            var sorted = ranges.OrderBy(r => r.start).ToList();
            var merged = new List<(ulong start, ulong end)>();

            foreach (var interval in sorted)
            {
                if (merged.Count == 0 || merged.Last().end < interval.start - 1)
                    merged.Add(interval);
                else
                    merged[merged.Count - 1] = (
                        merged.Last().start,
                        Math.Max(merged.Last().end, interval.end)
                    );
            }

            // Sum up the sizes of merged intervals
            ulong totalCovered = 0;
            foreach (var seg in merged)
                totalCovered += (seg.end - seg.start + 1); // +1 for inclusive ranges

            return totalCovered;
        }



        private (string[], string[]) GetData(string target)
        {
            string[] lines = File.ReadAllLines(target);

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

    static class Helpers
    {
        public static void AddDistinct(this List<ulong> target, List<ulong> source)
        {
            var seen = new HashSet<ulong>(target);
            foreach (var item in source)
            {
                if (seen.Add(item))
                {
                    target.Add(item);
                }
            }
        }
    }
}

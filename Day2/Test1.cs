using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day2
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string input =
                "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

            ulong result = Calculate(input);

            Assert.AreEqual((ulong)1227775554, result);
        }


  


        [TestMethod]
        public void TestMethod2()
        {
            string input =
                "1061119-1154492,3-23,5180469-5306947,21571-38630,1054-2693,141-277,2818561476-2818661701,21177468-21246892,40-114,782642-950030,376322779-376410708,9936250-10074071,761705028-761825622,77648376-77727819,2954-10213,49589608-49781516,9797966713-9797988709,4353854-4515174,3794829-3861584,7709002-7854055,7877419320-7877566799,953065-1022091,104188-122245,25-39,125490-144195,931903328-931946237,341512-578341,262197-334859,39518-96428,653264-676258,304-842,167882-252124,11748-19561";

            ulong result = Calculate(input);

            Assert.AreEqual((ulong)12850231731, result);
        }

        [TestMethod]
        public void TestMethodPart2Exampe()
        {
            string input =
                "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

            ulong result = Calculate2(input);

            Assert.AreEqual((ulong)4174379265, result);
        }


        [TestMethod]
        public void TestMethodPart2Puzzle()
        {
            string input =
                "1061119-1154492,3-23,5180469-5306947,21571-38630,1054-2693,141-277,2818561476-2818661701,21177468-21246892,40-114,782642-950030,376322779-376410708,9936250-10074071,761705028-761825622,77648376-77727819,2954-10213,49589608-49781516,9797966713-9797988709,4353854-4515174,3794829-3861584,7709002-7854055,7877419320-7877566799,953065-1022091,104188-122245,25-39,125490-144195,931903328-931946237,341512-578341,262197-334859,39518-96428,653264-676258,304-842,167882-252124,11748-19561";

            ulong result = Calculate2(input);


            // too high: 24774350364
            Assert.AreEqual((ulong)12850231731, result);
        }


        private static readonly Regex sameDigitsRegex =
            new Regex("^([0-9])\\1*$", RegexOptions.Compiled, TimeSpan.FromSeconds(5));

        private ulong Calculate2(string input)
        {
            ulong result = 0;
            string[] ranges = input.Split(',');

            List<ulong> knownIds = new List<ulong>();

            foreach (string range in ranges)
            {
                string[] split = range.Split('-');
                ulong start = ulong.Parse(split[0]);
                ulong end = ulong.Parse(split[1]);

                for (ulong i = start; i <= end; i++)
                {
                    if(i < 10)
                        continue;
                    string iString = i.ToString();

                    if (sameDigitsRegex.IsMatch(iString))
                    {
                        if (!knownIds.Contains(i))
                        {
                            knownIds.Add(i);
                            result += i;
                        }
                        continue;
                    }

                    string[] patterns = GetPatterns(iString);

                    foreach (string pattern in patterns)
                    {
                        Regex patternRegex = new Regex($"^({pattern})+$", RegexOptions.None, TimeSpan.FromSeconds(5));
                        if (patternRegex.IsMatch(iString))
                        {
                            if (!knownIds.Contains(i))
                            {
                                knownIds.Add(i);
                                result += i;
                            }
                            break;
                        }
                    }



                }
            }

            return result;
        }

        private ulong Calculate(string input)
        {
            ulong result = 0;

            string[] ranges = input.Split(',');
            foreach (string range in ranges)
            {
                string[] split = range.Split('-');
                ulong start = ulong.Parse(split[0]);
                ulong end = ulong.Parse(split[1]);

                for (ulong i = start; i <= end; i++)
                {
                    string iString = i.ToString();

                    string p1 = iString.Substring(0, iString.Length / 2);
                    string p2 = iString.Substring(iString.Length / 2);

                    if (iString.Length % 2 == 0 && p1 == p2)
                    {
                        result += (ulong)i;
                        continue;
                    }





                }
            }

            return result;
        }

        [TestMethod]
        public void MyTestMethod()
        {
            string[] patterns = GetPatterns("12341234");
        }

        private string[] GetPatterns(string input)
        {
            List<string> patterns = new List<string>();

            //for (int i = 0; i <= input.Length / 2; i++)
            {
                string s1 = $"{input[0]}";
                for (int j = 1, c = 1; j < input.Length / 2; j++, c++)
                {
                    var val = input.Substring(1, c);

                    patterns.Add($"{s1}{val}");
                }
            }

            return patterns.ToArray();
        }
    }
}

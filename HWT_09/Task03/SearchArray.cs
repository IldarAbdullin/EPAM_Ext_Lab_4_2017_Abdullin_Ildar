namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SearchArray
    {      
        public static int[] FindPositive(int[] array)
        {
            List<int> positive = new List<int>();
            foreach (var c in array)
            {
                if (c > 0)
                {
                    positive.Add(c);
                }
            }

            return positive.ToArray();
        }

        public static int[] FindPositive(int[] array, Predicate<int> condition)
        {
            List<int> positive = new List<int>();
            foreach (var c in array)
            {
                if (condition(c))
                {
                    positive.Add(c);
                }
            }

            return positive.ToArray();
        }

        public static bool IsPostive(int n)
        {
            return n > 0;
        }

        public static int[] GetPositive(int[] array)
        {
            var lst = from item in array
                      where item > 0
                      select item;

            return lst.ToArray();
        }
    }
}

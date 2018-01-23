namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IsPositiveNumber
    {
        public static bool IsPositiveNum(this string str)
        {
            bool isDigit = str.All(char.IsDigit);
            bool isPositiveNum = false;
            if (isDigit)
            {
                double ch = Convert.ToDouble(str);
                if (((int)ch == ch) && (ch >= 0))
                {
                    isPositiveNum = true;
                }
            }

            return isPositiveNum;
        }
    }
}

namespace Task04
{
    using System;

    public class MyString
    {
        public char[] Value;

        public MyString(char[] str)
        {
            this.Value = str;
        }

        public static MyString operator +(MyString str1, MyString str2)
        {
            char[] str = new char[str1.Length() + str2.Length()];

            for (int i = 0; i < str1.Length(); i++)
            {
                str[i] = str1.Value[i];
            }

            for (int i = 0; i < str2.Length(); i++)
            {
                str[str1.Length() + i] = str2.Value[i];
            }

            var foldedRows = new MyString(str);
            return foldedRows;
        }

        public int MyIndexOf(char[] str)
        {
            int concurrences = 0;
            int j = 0;
            int first = 0;

            if (str == string.Empty.ToCharArray())
            {
                return 0;
            }
            else
            {
                for (int i = 0; i < this.Value.Length; i++)
                {
                    if (this.Value[i] == str[j])
                    {
                        if (j == 0)
                        {
                            first = i;
                        }

                        j++;
                        concurrences++;
                    }
                }

                if (concurrences == str.Length)
                {
                    return first;
                }
                else
                {
                    return -1;
                }
            }
        }

        public MyString MyToUpper()
        {
            for (int i = 0; i < this.Value.Length; i++)
            {
                this.Value[i] = char.ToUpper(this.Value[i]);
            }

            return this;
        }

        public MyString MyToLower()
        {
            for (int i = 0; i < this.Value.Length; i++)
            {
                this.Value[i] = char.ToLower(this.Value[i]);
            }

            return this;
        }

        public int Length()
        {
            return this.Value.Length;
        }

        public MyString MyInsert(int startIndex, MyString newStr)
        {
            char[] str = new char[this.Value.Length + newStr.Length()];
            int i1;
            for (i1 = 0; i1 < startIndex; i1++)
            {
                str[i1] = this.Value[i1];
            }

            int j = 0;
            int i2;
            for (i2 = startIndex; i2 < newStr.Length() + startIndex; i2++)
            {
                str[i2] = newStr.Value[j];
                j++;
            }

            for (int i = i2++; i < this.Value.Length + newStr.Length(); i++)
            {
                ++i1;
                str[i] = this.Value[i1];
            }

            this.Value = str;
            return this;
        }
    }
}

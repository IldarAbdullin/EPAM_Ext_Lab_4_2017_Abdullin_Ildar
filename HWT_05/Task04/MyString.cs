namespace Task04
{
    using System;

    class MyString
    {
        public char[] Value;

        public MyString(char[] str)
        {
             Value = str;
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
                for (int i = 0; i < Value.Length; i++)
                {
                    if (Value[i] == str[j])
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
            for (int i = 0; i < Value.Length; i++)
            {
                Value[i] = char.ToUpper(Value[i]);
            }
            return this;
        }

        public MyString MyToLower()
        {
            for (int i = 0; i < Value.Length; i++)
            {
                Value[i] = char.ToLower(Value[i]);
            }
            return this;
        }

        public int Length()
        {
            return Value.Length;
        }

        public static MyString operator + (MyString str1, MyString str2)
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

        public MyString MyInsert(int startIndex, MyString newStr)
        {
            char[] str = new char[Value.Length + newStr.Length()];
            int i1;
            for (i1 = 0; i1<startIndex; i1++)
            {
                str[i1] = Value[i1];
            }

            int j = 0;
            int i2;
            for (i2 = startIndex; i2 < newStr.Length()+ startIndex; i2++)
            {
                str[i2] = newStr.Value[j];
                j++;
            }

            for (int i = i2++; i < Value.Length + newStr.Length()  ; i++)
            {
                ++i1;
                str[i] = Value[i1];
            }

            Value = str;
            return this;
        }
    }
}

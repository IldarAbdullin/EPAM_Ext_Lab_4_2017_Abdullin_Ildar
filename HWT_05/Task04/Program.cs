/*
 Написать свой собственный класс MyString, описывающий строку как
массив символов. Перегрузить для этого класса типовые операции.
 */
namespace Task04
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            MyString str1 = new MyString("МАМа мыла раму".ToCharArray());
            MyString str2 = new MyString("мыла".ToCharArray());
            Console.WriteLine("Test {0}.MyIndexOf({1}) = {2}", str1.Value, str2.Value, str1.MyIndexOf(str2.Value));
            Console.WriteLine("Test operation + ({0},{1}) = {2}", str1.Value.ToString(), str2.Value.ToString(), (str1 + str2).Value.ToString());
            Console.WriteLine("Test {0}.MyInsert({1}) = {2}", str1.Value, str2.Value, str1.MyInsert(9, str2).Value);
            Console.WriteLine("Test {0}.MyToUpper = {2}", str2.Value, str2.MyToUpper());
            Console.WriteLine("Test {0}.MyToLower = {2}", str1.Value, str1.MyToLower());
            Console.ReadKey();
        }
    }
}

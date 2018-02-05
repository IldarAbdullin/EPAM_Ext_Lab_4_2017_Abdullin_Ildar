namespace HWT_07
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>();
            Console.WriteLine("Enter the number of people");
            int.TryParse(Console.ReadLine(), out int n);
            CreatAndFill(ref list, n);
            PrintList(list);
            Delete(ref list);
            Console.WriteLine();
            PrintList(list);
            Console.ReadKey();
        }

        public static void CreatAndFill(ref List<int> list, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }
        }

        public static void Delete(ref List<int> list, int divider = 2)//todo pn используй более простую формулу задачи Иосифа
        {
            int count = 1; ////считчик людей //todo pn так назови его говорящим именем и не надо будет комментарий оставлять.
            int j = 0;  ////индекс в списке

            while (list.Count != 1)
            {
                if ((count == divider) && (list.Count > 1))
                {
                    list.RemoveAt(j);
                    if (j == list.Count)
                    {
                        j = 0;
                    }

                    count = 1;
                }

                if (j == list.Count - 1)
                {
                    if (count == divider)
                    {
                        list.RemoveAt(j);
                        count = 1;
                    }
                    else
                    {
                        count++;
                    }

                    j = 0;
                }
                else
                {
                    j++;
                    count++;
                }              
            }
        }

        public static void PrintList(List<int> list)
        {
            foreach (var i in list)
            {
                Console.Write($" {i} ");
            }
        }
    }
}

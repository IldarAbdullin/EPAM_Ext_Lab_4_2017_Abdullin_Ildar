namespace Task03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyDynamicArray<T> : IEnumerable
    {
        private const int DefaultCapacity = 8;
        private const int ExpansionCapacityDefualt = 2;
        private const int DefaultLength = 0;

        private T[] array;

        public MyDynamicArray(IEnumerable<T> collection)
        {
            int size = 0;
            foreach (var c in collection)
            {
                size++;
            }

            this.Capacity = size;
            this.Length = DefaultLength;
            this.array = new T[size];

            foreach (var c in collection)
            {
                this.Add(c);
            }
        }

        public MyDynamicArray()
        {
            this.array = new T[DefaultCapacity];
            this.Capacity = DefaultCapacity;
            this.Length = DefaultLength;
        }

        public MyDynamicArray(int capacity)
        {
            this.array = new T[capacity];
            this.Capacity = capacity;
            this.Length = this.array.Length;
        }

        public int Capacity { get; private set; }

        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index >= this.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.array[index];
            }

            set
            {
                if (index >= this.Length)
                {
                    ////ArgumentOutOfRangeException e = new ArgumentOutOfRangeException();
                    ////Console.WriteLine(e.Message);
                    throw new ArgumentOutOfRangeException();
                }

                this.array[index] = value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.array.GetEnumerator();
        }
        
        public void ExpansionCapacity(int expansionCapacity = ExpansionCapacityDefualt)
        {
            T[] newArray = new T[this.Capacity * expansionCapacity];
            for (int i = 0; i < this.Length; i++)
            {
                newArray[i] = this.array[i];
            }

            this.Capacity = newArray.Length;
            this.Length = this.array.Length;
            this.array = newArray;
        }

         public void Add(T element)
        {
            int index = this.Length;
            if (index == DefaultLength)
            {
                this.array[index] = element;
                this.Length++;
            }
            else
            {
                if (index < this.Capacity)
                {                   
                    this.array[index] = element;
                    this.Length++;
                }
                else
                {
                    this.ExpansionCapacity();
                    this.Length++;
                    this.array[index] = element;
                }
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            int size = 0;

            foreach (var c in collection)
            {
                size++;
            }

            if (size >= this.Capacity)
            {
                this.ExpansionCapacity((size / this.Capacity) + 1);
            }

            foreach (var c in collection)
            {
                this.Add(c);
            }
        }

        public bool Remove(T element)
        {
            T[] newArray = new T[this.Capacity];
            int j = 0;
            bool flag = false;
            for (int i = 0; i < this.Length; i++)
            {
                if (!this.array[i].Equals(element))
                {
                    newArray[j] = this.array[i];
                    j++;
                    flag = true;
                }                
            }

            this.array = newArray;
            return flag;
        }

        public void Insert(T element, int index)
        {
            if (this.Length + 1 > this.Capacity)
            {
                this.ExpansionCapacity();
            }

            T[] newArray = new T[this.Capacity];
            int j = 0;
            for (int i = 0; i < index; i++)
            {
                newArray[j] = this.array[i];
                j++;
            }

            newArray[index] = element;

            for (int i = index; i < this.Length; i++)
            {
                j++;
                newArray[j] = this.array[i];
            }

            this.array = newArray;
        }
    }
}

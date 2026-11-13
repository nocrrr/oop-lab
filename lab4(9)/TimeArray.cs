using System;

namespace LaboratoryWork9
{
    public class TimeArray
    {
        private Time[] _arr;
        private static int _collectionCount = 0;
        private static readonly Random Rnd = new Random();

        public static int CollectionCount => _collectionCount;
        public int Length => _arr.Length;

        public TimeArray()
        {
            _arr = new Time[0];
            _collectionCount++;
        }

        public TimeArray(int size)
        {
            if (size < 0)
                throw new ArgumentException("Размер массива не может быть отрицательным.");

            _arr = new Time[size];
            for (int i = 0; i < size; i++)
            {
                _arr[i] = new Time(Rnd.Next(0, 24), Rnd.Next(0, 60));
            }
            _collectionCount++;
        }

        public TimeArray(Time[] initialElements)
        {
            if (initialElements == null)
                throw new ArgumentNullException(nameof(initialElements));

            _arr = new Time[initialElements.Length];
            for (int i = 0; i < initialElements.Length; i++)
            {
                _arr[i] = new Time(initialElements[i]);
            }
            _collectionCount++;
        }

        public Time this[int index]
        {
            get
            {
                if (index < 0 || index >= _arr.Length)
                    throw new ArgumentException($"Индекс {index} выходит за пределы массива.");
                return _arr[index];
            }
            set
            {
                if (index < 0 || index >= _arr.Length)
                    throw new ArgumentException($"Индекс {index} выходит за пределы массива.");
                _arr[index] = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public Time[] GetElements()
        {
            Time[] copy = new Time[_arr.Length];
            Array.Copy(_arr, copy, _arr.Length);
            return copy;
        }
    }
}

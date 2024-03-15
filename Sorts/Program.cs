using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace GenerateSequence
{
    class Sort
    {
        public void QuickSort()
        {
            QuickSort(0, len - 1);
        }

        private void QuickSort(int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(left, right);
                QuickSort(left, partitionIndex - 1);
                QuickSort(partitionIndex + 1, right);
            }
        }

        private int Partition(int left, int right)
        {
            // Выбор медианного элемента в качестве опорного
            int medianIndex = (left + right) / 2;
            T medianValue = data[medianIndex];

            // Помещаем медиану в конец для упрощения разделения
            Swap(medianIndex, right);

            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (data[j].CompareTo(medianValue) <= 0)
                {
                    i++;
                    Swap(i, j);
                }
            }

            // Перемещаем медиану обратно в правильное положение
            Swap(i + 1, right);
            return i + 1;
        }

        private void Swap(int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }




        public void InsertionSort()
        {
            for (int i = 1; i < len; i++)
            {
                T key = data[i];
                int j = i - 1;

                while (j >= 0 && data[j].CompareTo(key) > 0)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                data[j + 1] = key;
            }
        }



        public void InsertionSortWithSignalKey()
        {
            for (int i = 1; i < len; i++)
            {
                T key = data[i];
                int j = i - 1;

                // Находим позицию для вставки элемента с использованием сигнального ключа
                while (j >= 0 && data[j].CompareTo(key) > 0)
                {
                    data[j + 1] = data[j];
                    j--;
                }

                // Вставляем элемент на нужную позицию
                data[j + 1] = key;
            }
        }


        public void CountingSort(int minValue, int maxValue)
        {
            // Создаем массив для подсчёта количества вхождений каждого элемента
            int[] counts = new int[maxValue - minValue + 1];

            // Считаем количество вхождений каждого элемента
            for (int i = 0; i < len; i++)
            {
                counts[Convert.ToInt32(data[i]) - minValue]++;
            }

            // Перезаписываем данные в соответствии с порядком сортировки
            int index = 0;
            for (int i = minValue; i <= maxValue; i++)
            {
                for (int j = 0; j < counts[i - minValue]; j++)
                {
                    data[index++] = (T)(object)i;
                }
            }
        }
    }
}
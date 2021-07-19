using System;

namespace Rang.AVG_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            // { 2, 3, 1, 3, 4, 5 }  <-- (mainArray) массив с входными данными 

            // { 1, 2,  3,   3,  4, 5 }  <-- (array2) Отсортированный массив
            // { 1, 2,  3,   4,  5, 6 }  <-- (arrayWithSortedRanks)
            // { 1, 2, 3.5, 3.5, 5, 6 }  <-- (tempArray) 
            // { 2, 3,5, 1, 3.5, 5, 6 }  <-- (resultArray) Ожидаемый результат


            double[] mainArray = new double[] { 2, 3, 1, 3, 4, 5 };
            double arrayLength = mainArray.Length;
            double[] array2 = ArrayCopy(mainArray); //Создаем копию массива с исходными данными(будем работать с ним)
            ArraySort(array2);
            double[] arrayWithSortedRanks = new double[mainArray.Length];
            double[] tempArray = new double[mainArray.Length];
            double[] resultArray = new double[mainArray.Length];

            // Заполняем массив с рангами в порядке возрастания
            for (int i = 0; i < arrayLength; i++)
            {
                arrayWithSortedRanks[i] = i + 1;
            }

            // Находим повторяющиеся пары значений и присваиваем среднее значение ранга
            for (int i = 0; i < mainArray.Length; i++)
            {
                tempArray[i] = arrayWithSortedRanks[i];
                for (int j = i + 1; j < mainArray.Length; j++)
                {
                    if (array2[i] == array2[j])
                    {
                        double avgRang = (arrayWithSortedRanks[i] + arrayWithSortedRanks[j]) / 2;
                        tempArray[i] = avgRang;
                        tempArray[j] = avgRang;
                        i++;
                        break;
                    }
                }
            }

            //Восстанавливаем последовательность. Чтобы индекс ранга соответствовал индексу числа
            for (int i = 0; i < mainArray.Length; i++)
            {
                for (int j = 0; j < mainArray.Length; j++)
                {
                    if (mainArray[i] == array2[j])
                    {
                        resultArray[i] = tempArray[j];
                    }
                }
            }

            // Попытка решить задачу в общем виде
            //double[] arrayWithRanks = new double[mainArray.Length];
            //for (int i = 0; i < arrayLength-1; i++)
            //{
            //    double count = 1; // Кол-во рангов
            //    double sumOfRangs = i+1; // Сумма рангов
            //    double avgRank = 0; // Результат вычисления среднего ранга

            //    for (int j = i+1; j < arrayLength; j++)
            //    {
            //        if (array2[i] == array2[j])
            //        {
            //            sumOfRangs += arrayWithSortedRanks[j];
            //            count++;
            //            avgRank = sumOfRangs / count;
            //            arrayWithRanks[i] = avgRank;
            //            arrayWithRanks[j] = avgRank;
            //            break;
            //        }
            //        else
            //        {
            //            arrayWithRanks[i] = sumOfRangs;
            //            sumOfRangs++;
            //            break;
            //        }
            //    }
            //}

            Console.WriteLine("mainArray:");
            foreach (var item in mainArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\narray2:");
            foreach (var item in array2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\narrayWithSortedRanks:");
            foreach (var item in arrayWithSortedRanks)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\ntempArray:");
            foreach (var item in tempArray)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("\nresultArray:");
            foreach (var item in resultArray)
            {
                Console.Write(item + " ");
            }

        }
        /// <summary>
        /// Метод копирования массива
        /// </summary>
        /// <param name="defArray"></param>
        /// <returns></returns>
        public static double[] ArrayCopy(double[] defArray)
        {
            double[] copyOfDefArray = new double[defArray.Length];
            for (int i = 0; i < defArray.Length; i++)
            {
                copyOfDefArray[i] = defArray[i];
            }
            return copyOfDefArray;
        }

        /// <summary>
        /// Метод сортировки массива
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static void ArraySort(double[] array)
        {
            double temp;
            bool isSorted;

            do
            {
                isSorted = true;
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < array[i - 1])
                    {
                        temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                        isSorted = false;
                    }
                }
            } while (isSorted == false);
        }
    }
    // 0. СДЕЛАТЬ ПОТОМ Проверка на 0
    // 1. Отсортировать массив по возрастанию 
    // 2. Проверить, если соседние элементы повторяются. Если повторяются - алгоритм вычисления среднего ранга. Если нет - продолжить.
    // 3. Присвоить каждому элементу ранг(порядковый номер)
    // 4. Восстановить порядок элементов, как в первоначальном массиве, т.е ранг числа должен соответствовать позиции в  первонач. массиве.
}


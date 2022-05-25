using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortirovki
{
    //сортируем массив чисел 

    //тут есть:
    //быстрая сортировка
    //сортировка пузырьком
    //гномья сортировка
    //сортировка вставками
    //сортировка шелла -
    //сортировка слиянием
    //шейкерная(перемешивание или двунаправленная) сортировка
    //сортировка расческой 
    //сортировка выбором

    class Program
    {
        //быстрая сортировка Сложность O(n log n)
        public static int[] QSort(int[] array, int firstIndex = 0, int lastIndex = -1)
        {
            
            if (lastIndex < 0)
                lastIndex = array.Length - 1;
            if (firstIndex >= lastIndex)
                return array;
            int middleIndex = (lastIndex - firstIndex) / 2 + firstIndex;
            int currentIndex = firstIndex;
            Swap(ref array[firstIndex], ref array[middleIndex]);
            for (int i = firstIndex + 1; i <= lastIndex; ++i)
            {
                if (array[i] <= array[firstIndex])
                {
                    Swap(ref array[++currentIndex], ref array[i]);
                }
            }
            Swap(ref array[firstIndex], ref array[currentIndex]);
            QSort(array, firstIndex, currentIndex - 1);
            QSort(array, currentIndex + 1, lastIndex);
            //выводим массив после сортировки
            return array;
        }



        //сортировка пузырьком O(n^2)
        //десь нужно последовательно сравнивать значения соседних элементов и менять числа местами, 
        //если предыдущее оказывается больше последующего. 
        //Таким образом элементы с большими значениями оказываются в конце списка, а с меньшими остаются в начале.
        public static void Bubble_Sort(int[] array)
        {
            //Выводим массив до сортировки
            PrintArray(array);

            //Основной цикл (количество повторений равно количеству элементов массива)
            for (int i = 0; i < array.Length; i++)
            {
                //Вложенный цикл (количество повторений, равно количеству элементов массива минус 1 и минус количество выполненных повторений основного цикла)
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    //Если элемент массива с индексом j больше следующего за ним элемента
                    if (array[j] > array[j + 1])
                    {
                        //Меняем местами элемент массива с индексом j и следующий за ним
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
            //выводим массив после сортировки
            PrintArray(array);
        }


        //гномья сортировка O(n^2)
        // По сути, в алгоритме сравниваются рядом стоящие элементы , если они стоят в нужном порядке, 
       // тогда мы переходим на следующий элемент массива, если нет, ты мы их переставляем и переходим на предыдущий.
        //Нету предыдущего элемента — идём вперед, нету следующего — значит мы закончили.
       //Изначально мы находимся на втором элементе массива.
        static void GnomeSort(int[] inArray)
        {
            PrintArray(inArray);
            int i = 1;
            int j = 2;
            while (i < inArray.Length)
            {
                if (inArray[i - 1] < inArray[i])
                {
                    i = j;
                    j += 1;
                }
                else
                {
                    Swap(ref inArray[i - 1], ref inArray[i]);
                    i -= 1;
                    if (i == 0)
                    {
                        i = j;
                        j += 1;
                    }
                }
            }
            PrintArray(inArray);
        }

        //сортировка вставками O(n^2)
        /*Внешний цикл начинает работу со второго элемента массива. 
         * Запоминаем значение второго элемента массива. 
         * Во внутреннем цикле сравниваем каждый предыдущий элемент массива с текущим и,
         * при необходимости, меняем их местами до тех пор, пока не дойдем до начала цикла 
         * или пока не встретится элемент менее текущего. В результате массив отсортируется по возрастанию.
         */
        static void InsertionSort(int[] inArray)
        {
            PrintArray(inArray);
            int x;
            int j;
            for (int i = 1; i < inArray.Length; i++)
            {
                x = inArray[i];
                j = i;
                while (j > 0 && inArray[j - 1] > x)
                {
                    Swap(ref inArray[j], ref inArray[j - 1]);
                    j -= 1;
                }
                inArray[j] = x;
            }
            PrintArray(inArray);
        }


        //сортировка шелла
        /*Идея сортировки методом Шелла состоит в том, 
         * чтобы сортировать элементы отстоящие друг от друга на некотором расстоянии step. 
         * Затем сортировка повторяется при меньших значениях step, 
         * и в конце процесс сортировки Шелла завершается при step = 1 (а именно обычной сортировкой вставками).*/
        static int[] ShellSort(int[] a)
        {
            int n = a.Length;
            for (int step = n / 2; step > 0; step /= 2)
            {
                for (int i = step; i < n; i++)
                {
                    for (int j = i - step; j >= 0 && a[j] > a[j + step]; j -= step)
                    {
                        int x = a[j];
                        a[j] = a[j + step];
                        a[j + step] = x;
                    }
                }
            }
            return a;
        }



        //сортировка слиянием O(NlogN)
        //Сначала делим список на кусочки (по 1 элементу), 
        //затем сравниваем каждый элемент с соседним, сортируем и объединяем. 
        //В итоге, все элементы отсортированы и объединены вместе.
        static int[] Merge_Sort(int[] massive)
        {
            if (massive.Length == 1)
                return massive;
            int mid_point = massive.Length / 2;
            return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
        }
        static int[] Merge(int[] mass1, int[] mass2)
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];
            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                    if (mass1[a] > mass2[b])
                        merged[i] = mass2[b++];
                    else //if int go for
                        merged[i] = mass1[a++];
                else if (b < mass2.Length)
                    merged[i] = mass2[b++];
                else
                    merged[i] = mass1[a++];
            }
            return merged;
        }

        //шейкерная(перемешивание или двунаправленная) сортировка
       // Лучший случай для этой сортировки - отсортированный массив(О(n)), худший - отсортированный в обратном порядке(O(n²)).
        static void ShakerSort(int[] myint)
        {
            int left = 0,
                right = myint.Length - 1,
                count = 0;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    count++;
                    if (myint[i] > myint[i + 1])
                        Swap( ref myint[i], ref myint[i + 1]);
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    count++;
                    if (myint[i - 1] > myint[i])
                        Swap(ref myint[i - 1], ref myint[i]);
                }
                left++;
            }
            Console.WriteLine("\nКоличество сравнений = {0}", count.ToString());
        }

        //сортировка расческой Худшее время	O(n2) Лучшее время O(n logn)
        /*Основная идея «расчёски» в том,
         * чтобы первоначально брать достаточно большое расстояние между сравниваемыми элементами 
         * и по мере упорядочивания массива сужать это расстояние вплоть до минимального. 
         * Таким образом, мы как бы причёсываем массив, постепенно разглаживая на всё более аккуратные пряди. 
         * Первоначальный разрыв между сравниваемыми элементами лучше брать с учётом специальной величины,
         * называемой фактором уменьшения, оптимальное значение которой равно примерно 1,247. 
         * Сначала расстояние между элементами максимально, то есть равно размеру массива минус один. 
         * Затем, пройдя массив с этим шагом, необходимо поделить шаг на фактор уменьшения и пройти по списку вновь.
         * Так продолжается до тех пор, пока разность индексов не достигнет единицы.
         * В этом случае сравниваются соседние элементы как и в сортировке пузырьком, но такая итерация одна.
         */

        public static int[] combSort(int[] input)
        {
            double gap = input.Length;
            bool swaps = true;
            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < input.Length)
                {
                    int igap = i + (int)gap;
                    if (input[i] > input[igap])
                    {
                        int swap = input[i];
                        input[i] = input[igap];
                        input[igap] = swap;
                        swaps = true;
                    }
                    i++;
                }
            }
            return input;
        }


        //сортировка выбором O(n^2)
        /* На первом шаге в массиве находится элемент с минимальным значением,
         * затем он меняется местами с элементом, находящемся на нулевой позиции массива
         * (если минимальный элемент и так находится на нулевой позиции, обмен, соответственно, не производится), 
         * и затем выбывает из процесса сортировки.В следующей итерации среди оставшихся чисел находится второй по минимальности элемент, 
         * и происходит обмен местами этого элемента с элементом на первой позиции массива и тоже выбывает.Затем ищется третий по минимальности элемент,
         * меняется позициями с третьим элементом в массиве и выбывает из сортировки, и так далее.*/
        static int[] ViborSort(int[] mas)
        {

            for (int i = 0; i < mas.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[j] < mas[min])
                    {
                        min = j;
                    }
                }
                //обмен элементов
                int temp = mas[min];
                mas[min] = mas[i];
                mas[i] = temp;
            }
            return mas;
        }


        static void Main(string[] args)
        {
            //Некий массив целых чисел, который нужно отсортировать 
            int[] someArray = new int[] { 1, 2, 4, 3, 8, 5, 7, 6, 9, 0 };
            Stopwatch stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            Console.WriteLine("Пузырьковая сортировка");
            //Сортировка пузырьком 
            Bubble_Sort(someArray);
            stopwatch4.Stop();
            Console.WriteLine("Время сортировки:" + stopwatch4.ElapsedMilliseconds);


            //Быстрая сортировка
            someArray = new int[]{ 1, 2, 4, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Быстрая сортировка");
            //Выводим массив до сортировки
            PrintArray(someArray);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] myArray = QSort(someArray);
            PrintArray(myArray);
            stopwatch.Stop();
            Console.WriteLine("Время сортировки:" + stopwatch.ElapsedMilliseconds);


            //Гномья сортировка сортировка
            someArray = new int[] { 1, 2, 4, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Гномья сортировка");
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            GnomeSort(someArray);
            stopwatch1.Stop();
            Console.WriteLine("Время сортировки:" + stopwatch1.ElapsedMilliseconds);



            //Cортировка вставками
            someArray = new int[] { 1, 2, 4, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Сортировка вставками");
            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            InsertionSort(someArray);
            stopwatch3.Stop();
            Console.WriteLine("Время сортировки:" + stopwatch3.ElapsedMilliseconds);


            //Cортировка шейкерная
            someArray = new int[] { 1, 2, 4, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Шейкерная сортировка");
            //Выводим массив до сортировки
            PrintArray(someArray);
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            ShakerSort(someArray);
            stopwatch2.Stop();
            PrintArray(someArray);
            Console.WriteLine("Время сортировки:" + stopwatch2.ElapsedMilliseconds);


            //сортировка выбором
            someArray = new int[] { 1, 2, 4, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Сортировка выбором");
            //Выводим массив до сортировки
            PrintArray(someArray);
            Stopwatch stopwatch7 = new Stopwatch();
            stopwatch7.Start();
            int[] myArr = ViborSort(someArray);
            stopwatch7.Stop();
            PrintArray(myArr);
            Console.WriteLine("Время сортировки:" + stopwatch7.ElapsedMilliseconds);


            //сортировка рассческой
            someArray = new int[] { 1, 2, 4, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Сортировка расческой");
            //Выводим массив до сортировки
            PrintArray(someArray);
            Stopwatch stopwatch11 = new Stopwatch();
            stopwatch11.Start();
            int[] rez = combSort(someArray);
            stopwatch11.Stop();
            PrintArray(rez);
            Console.WriteLine("Время сортировки:" + stopwatch11.ElapsedMilliseconds);

            //сортировка слиянием 
            someArray = new int[] { 1, 2, 4, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Сортировка слиянием");
            //Выводим массив до сортировки
            PrintArray(someArray);
            Stopwatch stopwatch10 = new Stopwatch();
            stopwatch10.Start();
            int[] arr = Merge_Sort(someArray);
            stopwatch10.Stop();
            PrintArray(arr);
            Console.WriteLine("Время сортировки:" + stopwatch10.ElapsedMilliseconds);



            //сортировка шелла
            someArray = new int[] { 10, 2, 8, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Сортировка шелла");
            PrintArray(someArray);
            Stopwatch stopwatch100 = new Stopwatch();
            stopwatch100.Start();
            int[] array = ShellSort(someArray);
            stopwatch100.Stop();
            PrintArray(array);
            Console.WriteLine("Время сортировки:" + stopwatch100.ElapsedMilliseconds);


            Console.ReadKey();
        }

        //Вспомогательный метод, выводящий на консоль элементы массива
        public static void PrintArray(int[] anArray)
        {
            //Перебор всех элементов массива
            for (int i = 0; i < anArray.Length; i++)
            {
                //Вывод значения текущего элемента и пробел после него
                Console.Write(anArray[i] + " ");
            }

            //Перевод строки
            Console.WriteLine("\n");
        }

        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}

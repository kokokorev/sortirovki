using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> data = new List<List<int>>();
            //Матрица смежности ориентированного графа
                                            // a  b  c  d  e  f  g  h
            data.Add(new List<int>(new int[] { 0, 1, 1, 0, 0, 0, 0, 0 }));//a
            data.Add(new List<int>(new int[] { 0, 0, 0, 1, 1, 0, 0, 0 }));//b
            data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 1, 1, 0 }));//c
            data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }));//d
            data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 1 }));//e
            data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }));//f
            data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }));//g
            data.Add(new List<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }));//h

            List<int> obhod = new List<int>();
            Console.WriteLine("Обход в глубину");
            InDeep(data, data[0], obhod);
            PrintList(obhod);
            obhod.Clear();
            Console.WriteLine("Обход в ширину");
            InSize(data, data[0], obhod);
            PrintList(obhod);
        }
        /// <summary>
        /// Обход в глубину 
        /// </summary>
        /// <param name="data">матрица смежности</param>
        /// <param name="elem">Вершина по которой нужно пройти</param>
        /// <param name="obhod">вершины которые мы обошли</param>
        static void InDeep(List<List<int>> data, List<int> elem, List<int> obhod)
        {
            //добавляем в пройденные вершины
            obhod.Add(data.IndexOf(elem));
            //проходим по соседним элементам данной вершины 
            for (int i = 0; i < elem.Count; i++)
            {
                if (elem[i] == 1)
                {
                    if (!obhod.Contains(data.IndexOf(data[i])))
                    {
                        Console.WriteLine("Входим в {0}", i);
                        //Рекурсивно вызывает что бы пройти вглубь (до конца)
                        InDeep(data, data[i], obhod);
                        Console.WriteLine("Выходим из {0}", i);
                    }
                }
            }
        }
        /// <summary>
        /// Проход в ширину
        /// </summary>
        /// <param name="data">матрица смежности</param>
        /// <param name="elem"></param>
        /// <param name="obhod"></param>
        static void InSize(List<List<int>> data, List<int> elem, List<int> obhod)
        {
            // создаем очередь
            Queue<List<int>> queue = new Queue<List<int>>();
            obhod.Add(data.IndexOf(elem));
            queue.Enqueue(elem);
            // добовляем в нее смежные елементы, проходим по ним и добовляем смежные со смнежными и тд.
            while (queue.Count > 0)
            {
                List<int> temp = queue.Dequeue();
                Console.WriteLine("Входим в {0}", data.IndexOf(temp));
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i] == 1)
                    {
                        if (!obhod.Contains(i))
                        {
                            obhod.Add(i);
                            queue.Enqueue(data[i]);
                        }
                    }
                }
                Console.WriteLine("Выходим из {0}", data.IndexOf(temp));
            }
        }

        /// <summary>
        /// Печать списка
        /// </summary>
        /// <param name="list">Список для печати</param>
        static void PrintList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

    }

}
/*
--Графы—
Ориентированный граф - граф, рёбрам которого присвоено направление.
Граф, ни одному ребру которого не присвоено направление, называется неориентированным графом.
Графы можно представить разными способами: графическим изображением; прямым перечислением вершин и ребер; матрицей смежности и т.д.
Обход графа — это переход от одной его вершины к другой в поисках
свойств связей этих вершин.
Связи (линии, соединяющие вершины) называются ребрами графа.
Вершины графа также именуются узлами.
Поиск в глубину (стек) заключается в том, что мы двигаемся от начальной вершины в определенном направлении
до тех пор, пока не достигнем конца пути или пункта назначения.
Если мы достигли конца пути, но он не является пунктом назначения,
то мы возвращаемся назад и идем по другому маршруту.
Поиск в ширину. Вместо того, чтобы двигаться по определенному пути до конца,
он предполагает движение вперед по одному соседу за раз.
Мы помещаем в очередь сначала ближайшую к нам вершину, затем ее непосещенных соседей,
и продолжаем этот процесс, пока очередь не опустеет или пока мы не найдем искомую вершину. */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree
{
    class Program
    {
        static void Main(string[] args)
        {
            //бинарное дерево
            BinaryTree binaryTree = new BinaryTree(8);
            binaryTree.add(3);
            binaryTree.add(1);
            binaryTree.add(6);
            binaryTree.add(7);
            binaryTree.add(4);
            binaryTree.add(10);
            binaryTree.add(14);
            binaryTree.add(13);
            binaryTree.Remove(8);

            binaryTree.DisplayTree();
            Console.WriteLine();
            Console.WriteLine(binaryTree.Find(binaryTree.start, 8));
            Console.WriteLine(binaryTree.Find(binaryTree.start, 3));
            Console.WriteLine(binaryTree.Find(binaryTree.start, 1));
            Console.WriteLine(binaryTree.Find(binaryTree.start, 6));
            Console.WriteLine(binaryTree.Find(binaryTree.start, 7));
            Console.WriteLine(binaryTree.Find(binaryTree.start, 4));
            Console.WriteLine(binaryTree.Find(binaryTree.start, 10));
            Console.WriteLine(binaryTree.Find(binaryTree.start, 14));
            Console.WriteLine(binaryTree.Find(binaryTree.start, 13));
            Console.WriteLine(binaryTree.Find(binaryTree.start, 20));
        }
    }
}

/*--Дерево—
Бинарное дерево поиска — это бинарное дерево, обладающее дополнительными свойствами:
значение левого потомка меньше значения родителя,
а значение правого потомка больше значения родителя для каждого узла дерева.
То есть, данные в бинарном дереве поиска хранятся в отсортированном виде.
При каждой операции вставки нового или удаления существующего узла отсортированный порядок дерева сохраняется.
При поиске элемента сравнивается искомое значение с корнем.
Если искомое больше корня, то поиск продолжается в правом потомке корня,
если меньше, то в левом, если равно, то значение найдено и поиск прекращается. */
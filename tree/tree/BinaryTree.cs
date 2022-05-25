using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree
{
    public class BinaryTree
    {
        public Node start { get; set; }
        public BinaryTree(int number)
        {
            start = new Node(number);
        }
        //добавление
        public void add(int number)
        {
            add(start, number);
        }
        /// <summary>
        /// Добавление
        /// Берем ноду если больше значений внутри нее то мы идем вправо если там пустая ячейка создаем ноду,
        /// если там занято рекурсивно запускаем добавление
        /// с меньше аналогично
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="number"></param>
        private void add(Node node, int number)
        {
            if (number > node.data)
            {
                if (node.bigger == null)
                {
                    node.bigger = new Node(number);
                }
                else
                {
                    add(node.bigger, number);
                }
            }
            else
            {
                if (node.less == null)
                {
                    node.less = new Node(number);
                }
                else
                {
                    add(node.less, number);
                }
            }
        }

        public void Remove(int key)
        {
            RemoveHelper(start, key);
        }
        /// <summary>
        /// Удаление ноды из дерева
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private Node RemoveHelper(Node root, int key)
        {

            if (root == null)
                return root;
            //если ключ меньше корневого узла, идем влево рекурсивно
            if (key < root.data)
                root.less = RemoveHelper(root.less, key);
            // если ключ больше, чем корневой узел, идем вправо рекурсивно
            else if (key > root.data)
            {
                root.bigger = RemoveHelper(root.bigger, key);
            }
            //иначе мы нашли ключ
            else
            {
                //случай 1: удаляемый узел не имеет дочерних элементов
                if (root.less == null && root.bigger == null)
                {
                    //просто удаляем ноду
                    root = null;
                }
                //случай 2: удаляемый узел имеет два дочерних элемента
                else if (root.less != null && root.bigger != null)
                {
                    var maxNode = FindMin(root.bigger);
                    //скопируйте значение
                    root.data = maxNode.data;
                    root.bigger = RemoveHelper(root.bigger, maxNode.data);
                }
                //узел, который нужно удалить, имеет один дочерней элемент
                else
                {
                    var child = root.less != null ? root.less : root.bigger;
                    root = child;
                }

            }
            return root;

        }
        /// <summary>
        /// Поиск минимального относительно принятой ноды
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        private Node FindMin(Node node)
        {
            while (node.less != null)
            {
                node = node.less;
            }
            return node;
        }
        /// <summary>
        /// рекурсивный вывод дерева
        /// идем макс на лево и потом чисто на право
        /// </summary>
        /// <param name="root"></param>
        private void DisplayTree(Node root)
        {
            if (root == null) return;

            DisplayTree(root.less);
            System.Console.Write(root.data + " ");
            DisplayTree(root.bigger);
        }

        public void DisplayTree()
        {
            DisplayTree(start);
        }
        /// <summary>
        /// Нахождение 
        /// Обход в глубину пока не встретим этот элемент
        /// </summary>
        /// <param name="Node">нода</param>
        /// <param name="num">значение ноды</param>
        /// <returns></returns>
        public Boolean Find(Node node, int num)
        {
            if (node == null) return false;
            if (node.data == num)
            {
                return true;
            }
            else if (num < node.data)
            {
                return Find(node.less, num);
            }
            else if (num > node.data)
            {
                return Find(node.bigger, num);
            }
            return false;
        }
    }
}

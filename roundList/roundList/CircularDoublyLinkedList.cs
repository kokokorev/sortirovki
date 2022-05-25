using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace roundList
{
    public class CircularDoublyLinkedList<T> : IEnumerable<T>  // кольцевой двусвязный список
    {
        /// <summary>
        /// Кольцевой двусвязный список представляет замкнутый список, 
        /// в котором указатель на элемент может перемещаться как вперед, так и назад по кругу.
        /// Каждый узел такого списка опять же будет представлять элемент, 
        /// который хранит указатели на следующий и предыдущий узлы
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class DoublyNode<T>
        {
            public DoublyNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public DoublyNode<T> Previous { get; set; }
            public DoublyNode<T> Next { get; set; }
        }

        DoublyNode<T> head; // головной/первый элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
            {
                head = node;
                head.Next = node;
                head.Previous = node;
            }
            else
            {
                node.Previous = head.Previous;
                node.Next = head;
                head.Previous.Next = node;
                head.Previous = node;
            }
            count++;
        }
        public void AddCenter(T data)
        {
            if (this.Count <= 1) //проверка что в списке больше 1 одного элемента
            {
                this.Add(data);
            }
            else
            {

                //Находим центр списка
                int cent = this.count / 2;
                //берем элемент который будет левее
                DoublyNode<T> prevNode = head;
                //Берем элемент который будет правее
                DoublyNode<T> nextNode = head.Next;
                //создаем новый узел
                DoublyNode<T> newNode = new DoublyNode<T>(data);
                //находим место куда нужно вставить узел
                for (int i = 1; i < cent; i++)
                {
                    //Шагаем по узлам
                    prevNode = prevNode.Next;
                    nextNode = nextNode.Next;
                }
                //Говорим левому узлу что следующая от неё новый узел
                prevNode.Next = newNode;
                //Говорим что следующий от нового узла это правый узел
                newNode.Next = nextNode;
                //Говорим правому что предыдущий это новый узел
                nextNode.Previous = newNode;
                //Говорим что предыдущий от гового узла левый
                newNode.Previous = prevNode;
                //Так как мы добавили новый узел то увеличиваем количесвто элементов в списке на 1
                count++;
            }
        }
        // удаление элемента
        public bool Remove(T data)
        {
            DoublyNode<T> current = head;

            DoublyNode<T> removedItem = null;
            if (count == 0) return false;

            // поиск удаляемого узла
            do
            {
                if (current.Data.Equals(data))
                {
                    removedItem = current;
                    break;
                }
                current = current.Next;
            }
            while (current != head);

            if (removedItem != null)
            {
                // если удаляется единственный элемент списка
                if (count == 1)
                    head = null;
                else
                {
                    // если удаляется первый элемент
                    if (removedItem == head)
                    {
                        head = head.Next;
                    }
                    removedItem.Previous.Next = removedItem.Next;
                    removedItem.Next.Previous = removedItem.Previous;
                }
                count--;
                return true;
            }
            return false;
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            while (current != head);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

        public static void test()
        {
            CircularDoublyLinkedList<int> cdll = new CircularDoublyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                foreach (var x in cdll)
                {
                    Console.Write(x);
                }
                Console.WriteLine();
                Console.WriteLine(i);
                cdll.AddCenter(i);
            }
            foreach (var x in cdll)
            {
                Console.Write(x);
            }
        }

        
    }
}
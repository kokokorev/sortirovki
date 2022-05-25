using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyList
{
    class Program
    {
        static void Main(string[] args)
        {
            //вызываем метод  test для односвязного списка 
            LinkedList<int>.test();

            //вызываем метод test для двусвязного списка
            DoublyLinkedList<String>.test();
        }
    }
}

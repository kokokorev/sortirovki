using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            Table tb = new Table();
            tb.add(5);
            tb.add(6);
            tb.add(1);
            tb.delete(6);
            tb.printTable();
            Console.WriteLine();
            //Метод цепочек
            HashWithChaining h = new HashWithChaining();
            h.add(7);
            h.add(8);
            h.delete(8);
            h.add(7);
            h.printTable();
            Console.ReadLine();
        }
    }
}

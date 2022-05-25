using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree
{

    //вершина бинарного дерева
    public class Node
    {
        public int data { get; set; }
        public Node less { get; set; }
        public Node bigger { get; set; }
        public Node(int number)
        {
            data = number;
        }
    }
}

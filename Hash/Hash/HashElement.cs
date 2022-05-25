using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
   public class HashElement
    {
        private int key;
        private int value;
        private bool deleted;
        //конструктор
        public HashElement(int key, int value)
        {
            this.key = key;
            this.value = value;
            deleted = false;
        }
        //вычисляем хеш по значению
        public int hash(int value)
        {
            return value % 10;
        }
        //сетер на удаление
        public void setDeleted()
        {
            deleted = true;
        }
        //гетер на удаление
        public bool isDeleted()
        {
            return deleted;
        }

        public int getKey()
        {
            return key;
        }

        public int getValue()
        {
            return value;
        }
    }
}

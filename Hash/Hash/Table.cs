using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    //метод линейного пробирования по варианту
    public class Table
    {
        /*Линейное пробирование. Простейший метод открытой адресации называется линейным опробованием (linear probing): 
       * при возникновении коллизии (когда хеширование дает адрес в таблице, который уже занят элементом с ключом,
       * не совпадающим с ключом поиска) мы просто проверяем следующую позицию в таблице. Обычно такую проверку 
       * (определяющую, содержит ли данная позиция таблицы элемент с ключом, равным ключу поиска) называют пробой (probe).
       * При линейном опробовании определяется один из трех возможных исходов пробы: если позиция таблицы содержит элемент, 
       * ключ которого совпадает с искомым, то поиск завершился успешно; в противном случае (если позиция таблицы содержит 
       * элемент, ключ которого не совпадает с искомым) мы просто проверяем позицию таблицы с большим индексом, продолжая 
       * этот процесс (с возвратом к началу таблицы при достижении ее конца) до тех пор, пока не будет найден искомый ключ 
       * или пустая позиция таблицы. Если элемент, содержащий искомый ключ, должен быть вставлен после неудачного поиска,
       * он помещается в пустое место таблицы, где был завершен поиск. */
       
        public static int SIZE = 100001;
        private HashElement[] table = new HashElement[SIZE];
        //вычисление хеша
        public int hash(int value)
        {
            return value % 10;
        }

        //Добавление
        public bool add(int value)
        {
            // следующее поле для добавления если первое занято
            int probe;
            int code = hash(value);
            // Добавляем только в пустую ячейку
            if ((table[code] == null) || table[code].isDeleted())
            {
                table[code] = new HashElement(code, value);
                probe = -1;
            }
            else
            {
                if (code == (table.Length - 1))
                    probe = 0;
                else
                    probe = code + 1;
            }

            // добавление в пробу(след ячейку) 
            // если ячейка пустая идем дальше пока не найдем пустую
            while ((probe != -1) && (probe != code))
            {

                if ((table[probe] == null) || table[probe].isDeleted())
                {

                    table[probe] = new HashElement(code, value);
                    probe = -1;
                }

                else
                {
                    if (probe == (table.Length - 1))
                        probe = 0;
                    else
                        probe++;
                }
            }
            if (probe != -1)
                return false;
            else
                return true;
        }

        // Ищем по хешу и идем дальше что бы найти нужное значение
        public int find(int value)
        {
            int probe;
            int code = hash(value);
            if (table[code] == null)
                return -1;

            else if (table[code].getValue().Equals(value))
                return table[code].getValue();

            else
            {

                if (code == (table.Length - 1))
                    probe = 0;
                else
                    probe = code + 1;
            }

            // если не нашли по хешу идем дальше пока не найдем
            while ((probe != -1) && (probe != code))
            {
                if (table[probe] == null)
                    return -1;

                else if (table[probe].getValue().Equals(value))
                {
                    return table[probe].getValue();
                }
                else
                {
                    if (probe == (table.Length - 1))
                        probe = 0;
                    else
                        probe++;
                }
            }
            return -1;
        }
        // ищем по хешу и идем дальше пока не найдем наше значение
        public bool delete(int value)
        {

            int probe;
            int code = hash(value);
            if (table[code] == null)
            {
                return false;
            }
            else if (table[code].getValue().Equals(value))
            {
                table[code].setDeleted();
                probe = -1;
                return true;
            }
            else
            {
                if (code == (table.Length - 1))
                {
                    probe = 0;
                }
                else
                {
                    probe = code + 1;
                }
            }

            // если не нашли по хешу идем дальше пока не найдем

            while ((probe != -1) && (probe != code))
            {

                if (table[probe] == null)
                {
                    return false;
                }
                else if (table[probe].getValue().Equals(value))
                {
                    table[probe].setDeleted();
                    probe = -1;
                    return true;
                }
                else
                {
                    if (probe == (table.Length - 1))
                    {
                        probe = 0;
                    }
                    else
                    {
                        probe++;
                    }
                }
            }
            return false;
        }

        public void printTable()
        {
            for (int i = 0; i < SIZE; i++)
            {
                if (table[i] != null)
                {
                    if (!table[i].isDeleted())
                    {
                        Console.WriteLine(table[i].getValue());
                    }
                }
            }
        }
    }
}


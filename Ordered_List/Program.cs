using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ordered_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<string> linked_list = new LinkedList<string>();

            //добавление
            linked_list.Add("aa"); linked_list.Add("aa"); linked_list.Add("aba");

            //удаление
            linked_list.Remove("au"); /*linked_list.Remove("aa"); linked_list.Remove("aba");*/

            //удаление по индексу
            //linked_list.RemoveAt(22);

            //есть ли в списке
            //Console.WriteLine(linked_list.Contains("aaaa"));

            //индекс элемента
            //Console.WriteLine(linked_list.IndexOf("abea"));

            //подсписок 
            //IList<string> sub_linked_list = new LinkedList<string>();
            //sub_linked_list = linked_list.SubList(3,1);
            //foreach (string item in sub_linked_list)
            //    Console.WriteLine(item);

            foreach (string item in linked_list)
                Console.WriteLine(item);

            IList<int> arraylist = new ArrayList<int>();
            arraylist.Add(22); arraylist.Add(0); arraylist.Add(-1); arraylist.Add(-1);

            //удаление
            //arraylist.Remove(2); arraylist.Remove(22); arraylist.Remove(-1);arraylist.Remove(2);

            //удаление по индексу
            //arraylist.RemoveAt(22);

            //есть ли в списке
            //Console.WriteLine(arraylist.Contains(22));

            //индекс элемента
            //Console.WriteLine(arraylist.IndexOf(3));

            //подсписок 
            //IList<int> sub_array_list = new ArrayList<int>();
            //sub_array_list = arraylist.SubList(2,1);
            //foreach (int item in sub_array_list)
            //    Console.WriteLine(item);

            //----------ДЕЛЕГАТЫ-----------
            ListUtils<int> utils=new ListUtils<int>();
            //Существует ли в списке эелемент с заданным условием
            //Console.WriteLine(utils.Exists(arraylist, FindValue));

            //Ищет элемент, если находит, то возвращает его
            //Console.WriteLine(utils.Find(arraylist, FindValue));

            //Ищет индекс элемента
            //Console.WriteLine(utils.FindIndex(arraylist, FindValue));

            //Найти индекс последнего такого элемента
            //Console.WriteLine(utils.FindLastIndex(arraylist, FindValue));

            //Все элементы, равные каким - то значениям
            //IList<int> l = utils.FindAll(arraylist, FindValue, ArrayListConstructor_int);
            //if (l != null)
            //    foreach (int i in l) Console.WriteLine(i);

            //конвертация
            //IList<string> str_list = utils.ConvertAll<int, string>(arraylist, convert_value,ArrayListConstructor_string);
            //foreach (string i in str_list)
            //    Console.WriteLine(i);

            //сортировка в обратном порядке
            //IList<int> test = new ArrayList<int>(); test.Add(3); test.Add(-3); test.Add(90);
            //utils.Sort(test, Compare);
            //foreach (int i in test)
            //    Console.WriteLine(i);

            //foreach
            //utils.ForEach(arraylist, AddValue);

            //----------UNMUTABLE----------
            //IList<int> array = new ArrayList<int>();
            //array.Add(22); array.Add(0); array.Add(-1); array.Add(-1);
            //IList< int> unmutablelist = new UnmutableList<int>(array,array.Count);
            ////unmutablelist = array;
            //unmutablelist.Add(9);
            //Console.WriteLine(unmutablelist.Contains(2)); 
            //Console.WriteLine();
            //foreach (int i in arraylist)
            //    Console.WriteLine(i);

            Console.ReadLine();

        }
        public static bool FindValue(int value)
        {
            if (value ==-1) return true;
            return false;
        }

        public static string convert_value(int value)
        {
            return Convert.ToString(value + "CNV");
        }

        public static int AddValue(int p )
        {
            p += 1000; return p;
        }

        public static int Compare(int v1,int v2)
        {
            if (v1 == v2) return 0;
            if(v1 < v2) return -1;
            return 1;
        }

        public static ArrayList<string> ArrayListConstructor_string()
        {

            return new ArrayList<string>();
        }

        public static ArrayList<int> ArrayListConstructor_int()
        {
            return new ArrayList<int>();
        }

        public static LinkedList<int> LinkedListConstructor_int()
        {
            return new LinkedList<int>();
        }
    }
}

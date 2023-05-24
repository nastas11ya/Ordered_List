using NPOI.OpenXmlFormats;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordered_List
{
    public class ListUtils<T> where T : IComparable<T>
    {
        public ListUtils()
        { }

        //создание списка
        public delegate IList<T> ListConstructorDelegate<T>() where T : IComparable<T>;

        //public ListConstructorDelegate<T> ArrayListConstructor()
        //{
        //    return delegate ()
        //    { return new ArrayList<T>(); };
        //}

        //public ListConstructorDelegate<T> LinkedSetConstructor()
        //{
        //    return delegate ()
        //    { return new LinkedList<T>(); };
        //}

        public readonly ListConstructorDelegate<T> ArrayListConstructor = () =>
        {
            return new ArrayList<T>();
        };

        public readonly ListConstructorDelegate<T> LinkedListConstructor = () =>
        {
            return new LinkedList<T>();
        };
        //делегаты

        //проверка значения value на условие
        public delegate bool CheckDelegate<T>(T value);

        public delegate int ReturnDelegate<T>(T value);

        //конвертироание элемента типа TI в элемент типа TO
        //in - по ссылке но без доступа к изменению
        public delegate TO ConvertDelegate<in TI, out TO>(TI value);

        //применение к value действия
        public delegate T ActionDelegate<T>(T value);

        //сравнение величин
        public delegate int CompareDelegate<T>(T value, T value1);

        //Определяет, содержит ли List<T> элементы, удовлетворяющие условиям
        //указанного делегата
        public bool Exists<T>(IList<T> list, CheckDelegate<T> checkDelegate) where T : IComparable<T>
        {
            int count = list.Count;
            while(count > 0)
            {
                if (checkDelegate(list[count]))
                    return true;
                else count--;
            }
            return false;
        }

        public T Find<T>(IList<T> list, CheckDelegate<T> checkDelegate) where T : IComparable<T>
        {
            try
            {
                int count = list.Count;
                while (count > 0)
                {
                    if (checkDelegate(list[count]))
                        return list[count];
                    else count--;
                }
                throw new NotFoundElement();
            }
            catch (NotFoundElement e)
            {
                Console.WriteLine(e.Message);
                return default(T);
            }
        }

        public int FindIndex<T>(IList<T> list, CheckDelegate<T> checkDelegate) where T : IComparable<T>
        {
            try
            {
                int count = list.Count;
                int k = -1;
                while (count > 0)
                {
                    if (checkDelegate(list[count]))
                        //return count;
                        k = count;
                    count--;
                }
                if(k==-1) throw new NotFoundElement();
                return k;
            }
            catch (NotFoundElement e)
            {
                Console.WriteLine(e.Message);
                return -1; 
            }
        }

        public int FindLastIndex<T>(IList<T> list, CheckDelegate<T> checkDelegate) where T : IComparable<T>
        {
            try
            {
                int count = list.Count;
                while (count > 0)
                {
                    if (checkDelegate(list[count]))
                        return count;
                    else count--;
                }
                throw new NotFoundElement();
            }
            catch (NotFoundElement e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        public IList<T> FindAll<T>(IList<T> list, CheckDelegate<T> checkDelegate,ListConstructorDelegate<T> listConstructorDelegate) where T : IComparable<T>
        {
            IList<T> new_list = listConstructorDelegate();
            try
            {
                int count = list.Count;
                while (count > 0)
                {
                    if (checkDelegate(list[count]))
                        new_list.Add(list[count]);
                    count--;
                }
                if (new_list.IsEmpty) throw new NotFoundElement();
                return new_list;
            }
            catch (NotFoundElement e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public IList<T> ConvertAll<TO, T>(IList<TO> list, ConvertDelegate<TO, T> convertDelegate, ListConstructorDelegate<T> listConstructorDelegate) where TO: IComparable<TO> where T: IComparable<T>
        {
            IList<T> new_list = listConstructorDelegate();
            int count = list.Count;
            while (count > 0)
            {
                new_list.Add(convertDelegate(list[count]));
                count--;
            }
            return new_list;
        }

        public void ForEach(IList<T> list, ActionDelegate<T> actionDelegate)
        {
            int count = list.Count;
            while (count > 0)
            {
                list[count]=actionDelegate(list[count]);
               count--;
            }
            foreach(var item in list) Console.WriteLine(item.ToString());
        }


        public void Sort(IList<T> list, CompareDelegate<T> compareDelegate)
        {
            for (int i = 1; i <= list.Count; i++)
            {
                for (int j = i + 1; j <= list.Count; j++)
                {
                    if (compareDelegate(list[i], list[j]) < 0)
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }
}


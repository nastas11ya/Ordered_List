using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;

namespace Ordered_List
{
    public class ArrayList<T> : IList<T>, IEnumerable where T : IComparable<T>
    {
        int N = 5;
        T[] list=new T[5];

        public int Count { get; set; }
        public bool IsEmpty { get { return Count == 0; } }

        public T this[int index]
        {
            get
            {
                try
                {
                    if (index <= Count && index >= 1)
                    {
                        return list[index-1];
                    }
                    else throw new IndexListException();
                }
                catch (IndexListException e)
                {
                    Console.WriteLine(e.Message);
                    return default(T);
                }
            }
            set
            {
                try
                {
                    if (index <= Count && index >= 1)
                    {
                        list[index-1] = value;
                    }
                    else throw new IndexListException();
                }
                catch (IndexListException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public int CompareTo(T data, T other)
        {
            if (data.CompareTo(other) < 0)
                return -1;
            else
            {
                if (data.CompareTo(other) > 0)
                    return 1;
                else
                    return 0;
            }
        }

        public void Add(T value)
        {
            if(Count==N)
            {
                T[] oldlist = new T[N];
                for(int i=0;i<N;i++)
                    oldlist[i] = list[i];
                list = new T[N * 2];
                for (int i = 0; i < N; i++)
                    list[i] = oldlist[i];
                N *= 2;
            }
            if (Count == 0)
            {
                list[0] = value;
                Count++;
            }
            else
            {
                int k = 0;
                while (k <= Count-1 && CompareTo(list[k], value) == -1 ) k++;
                if (k == Count) list[k] = value;
                else
                {
                    for (int j = Count; j >= k + 1; j--)
                    {
                        list[j] = list[j - 1];
                    }
                    list[k] = value;
                }
                Count++;
            }
        }

        public void Remove(T value)
        {
            try
            {
                if (IsEmpty) throw new ListIsEmpty();
                if (!Contains(value)) throw new NotFoundElement();
                while (Contains(value))
                {
                    int k = 0;
                    while (k <= Count - 1 && CompareTo(list[k], value) == -1) k++;
                    if (k == Count) Count--;
                    else
                    {
                        for(int j=k;j<Count-1;j++)
                        {
                            list[j] = list[j + 1];
                        }
                        Count--;
                    }
                }
               
            }
            catch (NotFoundElement e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ListIsEmpty e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool Contains(T value)
        {
            try
            {
                if (IsEmpty) throw new ListIsEmpty();
                for (int i = 0; i < Count; i++)
                    if (CompareTo(list[i], value) == 0) return true;
                return false;
            }
            catch (ListIsEmpty e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void Clear()
        {
            list = new T[5]; N = 5;
            Count = 0;
        }

        public int IndexOf(T value)
        {
            int index = -1;
            if (Contains(value))
            {
                for (int i = 0; i < Count; i++)
                    if (CompareTo(list[i], value) == 0)
                        index = i;
            }
            try
            {
                if (IsEmpty) throw new ListIsEmpty();
                if (index == -1)
                    throw new NotFoundElement();
            }
            catch (NotFoundElement e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ListIsEmpty e)
            {
                Console.WriteLine(e.Message);
            }

            return index;
        }

        public void RemoveAt(int index)
        {
            try
            {
                if (IsEmpty) throw new ListIsEmpty();
                if (index >= 1 && index <= Count)
                {
                    int k = index - 1;
                    if (k == Count-1) Count--;
                    else
                    {
                        for (int j = k; j < Count - 1; j++)
                        {
                            list[j] = list[j + 1];
                        }
                        Count--;
                    }

                }
                else throw new IndexListException();
            }
            catch (IndexListException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ListIsEmpty e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IList<T> SubList(int fromIndex, int toIndex)
        {
            ArrayList<T> sublist = new ArrayList<T>();
            try
            {
                if (this.IsEmpty) throw new ListIsEmpty();
                if (fromIndex < 1 || toIndex < 1 || fromIndex > Count || toIndex > Count)
                    throw new IndexListException();

                if (fromIndex > toIndex)
                    throw new MessedUpIndexes();
            }
            catch (IndexListException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (MessedUpIndexes e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Исправление ошибки...");
                int c = fromIndex;
                fromIndex = toIndex;
                toIndex = c;
            }
            catch (ListIsEmpty e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fromIndex <= toIndex && toIndex <= Count && fromIndex>=1)
                {
                    sublist.list = new T[N];
                    for(int i= fromIndex-1;i< toIndex;i++)
                        sublist.Add(list[i]);
                }
            }
            return sublist;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return list[i];
        }
    }
}

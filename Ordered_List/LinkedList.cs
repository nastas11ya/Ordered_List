using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordered_List
{
    public class LinkedList<T> : IList<T>, IEnumerable where T : IComparable<T>
    {
        Node<T> Head;

        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                try
                {
                    if (index <= Count && index >= 1)
                    {
                        Node<T> cur_node = Head;
                        if (cur_node != null)
                        {
                            for (int i = 1; i < index; i++)
                                cur_node = cur_node.next;
                        }
                        return cur_node.data;
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
                        Node<T> cur_node = Head;
                        if (cur_node != null)
                        {
                            for (int i = 1; i < index; i++)
                                cur_node = cur_node.next;
                            cur_node.data = value;
                        }
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
            Node<T> node = new Node<T>(value);
            node.next = null;

            if (Head == null)
            {
                Head = node;
                
            }
            else
            {
                Node<T> cur_node = Head;
                //int i = 0;
                if (CompareTo(cur_node.data, value) == 1 || CompareTo(cur_node.data, value) == 0)
                {
                    node.next = Head;
                    Head = node;
                }
                else
                {
                    while (cur_node.next != null && CompareTo(cur_node.next.data, value) == -1)
                    {
                        cur_node = cur_node.next;
                    }
                    //Node<T> tmp = cur_node;
                    node.next = cur_node.next;
                    cur_node.next = node;
                }
            }
            Count++;
        }

        public void Remove(T value)
        {
            try
            {
                if(!Contains(value)) throw new NotFoundElement();
                while (Contains(value))
                {
                    Node<T> cur_node = Head;
                    if (cur_node != null)
                    {
                        if (cur_node.data.CompareTo(value) == 0)
                        {
                            Node<T> pNode = Head;
                            Head = Head.next;
                            //pNode.next = null;
                            pNode = null;
                        }
                        else
                        {
                            if (cur_node.next != null)
                            {
                                Node<T> prev = cur_node;
                                cur_node = cur_node.next;
                                while (cur_node.next != null)
                                {
                                    if (CompareTo(cur_node.data, value) == 0)
                                    {
                                        prev.next = cur_node.next;
                                        cur_node = null;
                                        Count--;
                                        return;
                                    }
                                    else
                                    {
                                        cur_node = cur_node.next;
                                        prev = prev.next;
                                    }
                                }
                                if (cur_node.next == null)
                                {
                                    if (CompareTo(cur_node.data, value) == 0)
                                    {
                                        prev.next = cur_node.next;
                                        cur_node = null;
                                        Count--;
                                        return;
                                    }
                                }
                            }
                        }
                        Count--;
                    }
                    if (IsEmpty) throw new ListIsEmpty();
                }
                //else throw new NotFoundElement();
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

        public bool IsEmpty { get { return Count == 0; } }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public bool Contains(T value)
        {
            try
            {
                if (IsEmpty) throw new ListIsEmpty();
                Node<T> cur_node = Head;
                while (cur_node != null)
                {
                    if (CompareTo(cur_node.data, value) == 0)
                        return true;
                    cur_node = cur_node.next;
                }
                return false;
            }
            catch (ListIsEmpty e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public int IndexOf(T value)
        {
            int index = -1;
            if (Contains(value))
            {
                index = 0;
                Node<T> cur_node = Head;
                bool found = false;
                while (cur_node != null && !found)
                {
                    if (CompareTo(cur_node.data, value) == 0)
                        found = true;
                    cur_node = cur_node.next;
                    index += 1;
                }
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
                if(IsEmpty) throw new ListIsEmpty();
                if (index >= 1 && index <= Count)
                {
                    Node<T> cur_node = Head;
                    if (cur_node != null)
                    {
                        if (index == 1)
                        {
                            Node<T> pNode = Head;
                            Head = Head.next;
                            //pNode.next = null;
                            pNode = null;
                            Count--;
                            return;
                        }
                        else
                        {
                            if (cur_node.next != null)
                            {
                                Node<T> prev = cur_node;
                                cur_node = cur_node.next;
                                int i = 2;
                                while (cur_node.next != null && i != index)
                                {
                                    cur_node = cur_node.next;
                                    prev = prev.next;
                                    i++;
                                }
                                if (i == index)
                                {
                                    prev.next = cur_node.next;
                                    cur_node = null;
                                    Count--;
                                    return;
                                }
                            }
                        }
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
            LinkedList<T> list = new LinkedList<T>();
            try
            {
                if(this.IsEmpty) throw new ListIsEmpty();
                if (fromIndex <= 0 || toIndex <= 0 || fromIndex > Count || toIndex > Count)
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
                if (fromIndex <= toIndex && toIndex <= Count)
                {
                    Node<T> cur_node = Head;
                    //Node<T> first = Head; Node<T> second = Head;
                    if (cur_node != null)
                    {
                        for (int i = 1; i <= toIndex; i++)
                        {
                            if (i >= fromIndex && i <= toIndex)
                                list.Add(cur_node.data);
                            cur_node = cur_node.next;
                        }
                    }
                }
            }
            return list;
        }

        public IEnumerator GetEnumerator()
        {
            var cur = Head;
            while (cur != null)
            {
                yield return cur.data;
                cur = cur.next;
            }
        }

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordered_List
{
    public class UnmutableList<T> : IList<T> where T : IComparable<T>
    {
        protected readonly IList<T> _component;

        public bool IsEmpty { get { return Count == 0; }  }

        public T this[int index]
        {
            get { return _component[index]; }
            set
            {
                try
                {
                    throw new TheListCannotBeModified();
                }
                catch (TheListCannotBeModified e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public UnmutableList(IList<T> component, int count)
        {
            _component = component;
            Count = count;
        }

        public void Add(T value)
        {
            try
            {
                throw new TheListCannotBeModified();
            }
            catch (TheListCannotBeModified e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Remove(T value)
        {
            try
            {
                throw new TheListCannotBeModified();
            }
            catch (TheListCannotBeModified e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Clear()
        {
            try
            {
                throw new TheListCannotBeModified();
            }
            catch (TheListCannotBeModified e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool Contains(T value)
        {
           return this._component.Contains(value);
        }

        public int Count { get; set; }
        

        public int CompareTo(T data, T other)
        { return this._component.CompareTo(data,other); }

        public int IndexOf(T value)
        { return this._component.IndexOf(value); }

        public void RemoveAt(int index)
        {
            try
            {
                throw new TheListCannotBeModified();
            }
            catch (TheListCannotBeModified e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public IList<T> SubList(int fromIndex, int toIndex)
        { return this._component.SubList(fromIndex, toIndex); }

        public IEnumerator GetEnumerator()
        { return this._component.GetEnumerator(); }
    }
}

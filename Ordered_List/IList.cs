using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ordered_List
{
    public interface IList<T> : IEnumerable where T : IComparable<T>
    {
        int Count { get; set; }
        T this[int index] { get; set; }

        int CompareTo(T data, T other);
        
        void Add(T value);
        void Remove(T value);

        //int getCount { get;}
        bool IsEmpty { get; }

        void Clear();
        bool Contains(T value);

        int IndexOf(T value);
        void RemoveAt(int index);
        IList<T> SubList(int fromIndex, int toIndex);
        IEnumerator GetEnumerator();
    }
}

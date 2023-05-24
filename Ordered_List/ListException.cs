using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordered_List
{
    public class ListException : Exception
    {
        public ListException(string message) : base(message)
        {
            //Console.WriteLine(message);
            //Console.ReadLine();
        }
    }

    public class IndexListException : ListException
    {
        private const string mes = "Индекс вне границ списка.";
        public IndexListException() : base(mes) { }
    }

    public class MessedUpIndexes : ListException
    {
        private const string mes = "Индексы попутаны местами.";
        public MessedUpIndexes() : base(mes) { }
    }

    public class NotFoundElement: ListException
    {
        private const string mes = "Не найден данный элемент.";
        public NotFoundElement() : base(mes) { }
    }

    public class TheListCannotBeModified : ListException
    {
        private const string mes = "Список не может быть изменен.";
        public TheListCannotBeModified() : base(mes) { }
    }

    public class ListIsEmpty : ListException
    {
        private const string mes = "Список пуст.";
        public ListIsEmpty() : base(mes) { }
    }
}

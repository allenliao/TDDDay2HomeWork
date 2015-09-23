using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Cart { 
        public void AddBook(Book book){
            _order.AddBook(book);
        }
        private Order _order;
        public Order getOrder(){

            return _order;
        }
        public decimal CalPrice()
        {
            decimal price = 0 ;

            return price;
        }
    }



    public class Order{
        private List<Book> _bookList;

        public void AddBook(Book book){
            _bookList.Add(book);
        }
    }

    public class Book{
        public string bookName;
        public decimal price=100;
    }
}

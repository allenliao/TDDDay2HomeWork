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
            var cart = new Cart();
            cart.AddBook(new Book() { bookName = "哈利波特第1集" });
            cart.AddBook(new Book() { bookName = "哈利波特第2集" });
            cart.AddBook(new Book() { bookName = "哈利波特第3集" });
            cart.AddBook(new Book() { bookName = "哈利波特第3集" });
            //act
            var actual = cart.CalPrice();
            Console.WriteLine(actual);
            Console.ReadLine();
        }
    }

    public class Cart { 
        public void AddBook(Book book){
            _order.Add(book);
        }
        private List<Book> _order=new List<Book>();

        public decimal CalPrice()
        {
            decimal totalPrice = 0;
            //先把同書名的GROUP起來然後SUM出價格
            var resulList = from p in _order
                            group p by new { p.bookName, p.price } into g
                            select new { bookName = g.Key.bookName, QTY = g.Count(), price = g.Key.price };

            
            var QTYnotZeroItemCount=0;
            int[] QtyCount = new int[resulList.Count()];

            for (var idy = 0; idy < resulList.Count(); idy++)
            {
                var item = resulList.ElementAt(idy);
                QtyCount[idy] = item.QTY;
            }
            while (!(QTYnotZeroItemCount == resulList.Count()))
            {
                decimal subTotalPrice = 0;
                int unitBookQTY = 0;
                for (var idx = 0; idx < resulList.Count(); idx++)
                {
                    var item = resulList.ElementAt(idx);
                    
                    if (QtyCount[idx] > 0)
                    {
                        unitBookQTY++;
                        subTotalPrice = subTotalPrice + item.price;
                        
                        QtyCount[idx]--;
                        if (QtyCount[idx]==0)
                        {
                            QTYnotZeroItemCount++;
                        }

                        Console.WriteLine(item.bookName + " QTY:" + QtyCount[idx] + " price:" + item.price);
                    }
                    
                    
                }
                Console.WriteLine(" getDiscount:" + (decimal)getDiscount(unitBookQTY));
                totalPrice = totalPrice + (subTotalPrice * (decimal)getDiscount(unitBookQTY));
            }

            return totalPrice;
        }

        private Double getDiscount(int QTY)
        {
            /*
            2. 如果你從這個系列買了兩本不同的書，則會有5%的折扣
            3. 如果你買了三本不同的書，則會有10%的折扣
            4. 如果是四本不同的書，則會有20%的折扣
            5. 如果你一次買了整套一到五集，恭喜你將享有25%的折扣
             * */
            switch (QTY)
            {
                case 1:
                    return 1;
                    break;
                case 2:
                    return 0.95;
                    break;
                case 3:
                    return 0.9;
                    break;
                case 4:
                    return 0.8;
                    break;
                default:
                    return 0.75;
                    break;
            }
        }
    }




    public class Book{
        public string bookName;
        public decimal price=100;
    }
}

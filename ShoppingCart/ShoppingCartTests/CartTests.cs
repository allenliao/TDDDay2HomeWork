using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ShoppingCart.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void 第1集買了_1_本_其他都沒買_價格應為_100元()
        {
            //arrange
            var cart = new Cart();
            cart.AddBook(new Book() { bookName = "哈利波特第1集" });
            var expected = 100;
            //act
            var actual = cart.CalPrice();
            //assert
            Assert.AreEqual(expected,actual);
        }


        [TestMethod()]
        public void 第1集買了_1_本_第2集買了_1_本_價格應為_190元()
        {
            //arrange
            var cart = new Cart();
            cart.AddBook(new Book() { bookName = "哈利波特第1集" });
            cart.AddBook(new Book() { bookName = "哈利波特第2集" });
            var expected = 190;
            //act
            var actual = cart.CalPrice();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 第1集買了_1_本_第2集買了_1_本_第3集買了_1_本_價格應為_320元()
        {
            //arrange
            var cart = new Cart();
            cart.AddBook(new Book() { bookName = "哈利波特第1集" });
            cart.AddBook(new Book() { bookName = "哈利波特第2集" });
            cart.AddBook(new Book() { bookName = "哈利波特第3集" });
            var expected = 320;
            //act
            var actual = cart.CalPrice();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 買了整套_價格應為_375元()
        {
            //arrange
            var cart = new Cart();
            cart.AddBook(new Book() { bookName = "哈利波特第1集" });
            cart.AddBook(new Book() { bookName = "哈利波特第2集" });
            cart.AddBook(new Book() { bookName = "哈利波特第3集" });
            cart.AddBook(new Book() { bookName = "哈利波特第4集" });
            cart.AddBook(new Book() { bookName = "哈利波特第5集" });
            var expected = 375;
            //act
            var actual = cart.CalPrice();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 一二集各買了1本_第三集買了2本_價格應為_370元()
        {
            //arrange
            var cart = new Cart();
            cart.AddBook(new Book() { bookName = "哈利波特第1集" });
            cart.AddBook(new Book() { bookName = "哈利波特第2集" });
            cart.AddBook(new Book() { bookName = "哈利波特第3集" });
            cart.AddBook(new Book() { bookName = "哈利波特第3集" });
            var expected = 370;
            //act
            var actual = cart.CalPrice();
            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void 第一集買了1本_第二三集各買了2本_價格應為_460元()
        {
            //arrange
            var cart = new Cart();
            cart.AddBook(new Book() { bookName = "哈利波特第1集" });
            cart.AddBook(new Book() { bookName = "哈利波特第2集" });
            cart.AddBook(new Book() { bookName = "哈利波特第2集" });
            cart.AddBook(new Book() { bookName = "哈利波特第3集" });
            cart.AddBook(new Book() { bookName = "哈利波特第3集" });
            var expected = 460;
            //act
            var actual = cart.CalPrice();
            //assert
            Assert.AreEqual(expected, actual);
        }


    }
}

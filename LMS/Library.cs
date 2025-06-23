using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    internal class Library
    {
        private List<Book> books = new List<Book>();


        public void AddBooks(Book book)
        {
            books.Add(book);
        }

        public void ListBooks()
        {
            foreach (var book in books)
            {
                Console.WriteLine($"[{book.BookId}] {book.Title} by {book.Author} - {book.Status}");
            }
        }

        public List<Book> SearchBooks(string keyword)
        {
            return books.FindAll(book => book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        public void BorrowBook(int bookId)
        {
            var book = books.FirstOrDefault(book => book.BookId == bookId);
            if (book != null && book.Status != BookStatus.Borrowed)
            {
                Console.WriteLine("Book has been borrowed" + " " + book.Title);
                book.Status = BookStatus.Borrowed;
            }
            else
            {
                Console.WriteLine(book?.Title + " "+ "is not available");
            }

        }

        public void ReturnBook(int bookId)
        {
            var book =books.FirstOrDefault(book => book.BookId == bookId);
            if(book != null && book.Status != BookStatus.Available)
            {
                Console.WriteLine("Book has been returned" + " " + book.Title);
                book.Status = BookStatus.Available;
            }
            else
            {
                Console.WriteLine(book?.Title + " " + "is not borrowed yet to return");
            }
        }
    }
}

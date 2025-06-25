using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LMS
{
    internal class Library
    {
        private List<Book> books = new List<Book>();


        public void AddBooks(Book book)
        {
            var data = File.ReadAllText("C:\\Users\\prave\\OneDrive\\Desktop\\Projects\\Project1\\LMS\\LMS\\LMS\\BookList.json");
            var addingBookFromFileToBooksList = JsonSerializer.Deserialize<List<Book>>(data);
            books.AddRange(addingBookFromFileToBooksList); ////adding a list of book from files to list above
            books.Add(book); //adding a new book
            var jsonData = JsonSerializer.Serialize(books); //everything is on books old list, new book



            File.WriteAllText("C:\\Users\\prave\\OneDrive\\Desktop\\Projects\\Project1\\LMS\\LMS\\LMS\\BookList.json", jsonData);
            //writes all in one json
            books.Clear();



            //Console.WriteLine(jsonData);
            //List<Book> books = JsonSerializer.Deserialize<List<Book>>(jsonString);
            //books.Add(data);
            //File.WriteAllText("C:\\Users\\prave\\OneDrive\\Desktop\\Projects\\Project1\\LMS\\LMS\\LMS\\BookList.json", books);
        }

        public void ListBooks()
        {
            books.Clear();
            var data = File.ReadAllText("C:\\Users\\prave\\OneDrive\\Desktop\\Projects\\Project1\\LMS\\LMS\\LMS\\BookList.json");
            var addingBookFromFileToBooksList = JsonSerializer.Deserialize<List<Book>>(data);
            books.AddRange(addingBookFromFileToBooksList);

            foreach (var book in books)
            {
                Console.WriteLine($"[{book.BookId}] {book.Title} by {book.Author} - {book.Status}");
            }
            books.Clear();
        }

        public List<Book> SearchBooks(string keyword)
        {
            books.Clear();
            var data = File.ReadAllText("C:\\Users\\prave\\OneDrive\\Desktop\\Projects\\Project1\\LMS\\LMS\\LMS\\BookList.json");
            var booksToAddonList = JsonSerializer.Deserialize<List<Book>>(data);
            books.AddRange(booksToAddonList);
            var bookSearched = books.FindAll(book => book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || book.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            books.Clear();
            books.AddRange(bookSearched);
            return books;
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
                Console.WriteLine(book?.Title + " " + "is not available");
            }

        }

        public void ReturnBook(int bookId)
        {
            var book = books.FirstOrDefault(book => book.BookId == bookId);
            if (book != null && book.Status != BookStatus.Available)
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

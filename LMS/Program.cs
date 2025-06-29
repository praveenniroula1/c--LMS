﻿using System;
using System.Security.Cryptography.X509Certificates;
using System.Configuration;
namespace LMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();
            bool exit = false;


            while (!exit) {

                Console.Write("Username:");
                var username = Console.ReadLine();
                Console.Write("Password:");
                var password = Console.ReadLine();

                string usernameConfig = ConfigurationManager.AppSettings["UserId"];
                string passwordConfig = ConfigurationManager.AppSettings["Password"];

                if (usernameConfig == username && passwordConfig == password)
                {
                    while (!exit)
                    {
                        Console.WriteLine("1. Add Book");
                        Console.WriteLine("2. List Books");
                        Console.WriteLine("3. Search Books");
                        Console.WriteLine("4. Borrow Book");
                        Console.WriteLine("5. Return Book");
                        Console.WriteLine("6. Exit");
                        Console.Write("Choose an option:");


                        var inputResult = Console.ReadLine();
                        Console.WriteLine();

                        switch (inputResult)
                        {
                            case "1":
                                Book book = new Book();
                                Console.Write("Enter Book Title:");
                                var bookTitle = Console.ReadLine();
                                Console.Write("Enter Book AuthorName:");
                                var bookAuthor = Console.ReadLine();
                                int bookUniqueId = int.Parse(DateTime.Now.ToString("HHmmssfff"));
                                book.BookId =bookUniqueId;
                                book.Title = bookTitle;
                                book.Author = bookAuthor;
                                book.Status = BookStatus.Available;

                                lib.AddBooks(book);

                                Console.WriteLine("Book successfully added");
                                Console.WriteLine("=======================");


                                break;

                            case "2":
                                lib.ListBooks();
                                Console.WriteLine("=======================");

                                break;

                            case "3":
                                Console.Write("Enter the keyword you are looking for:");
                                var keywords = Console.ReadLine();

                                var bookSearch = lib.SearchBooks(keywords);
                                if (bookSearch.Count != 0)
                                {
                                    foreach(var bok in bookSearch)
                                    {
                                        Console.WriteLine($"[{bok.BookId}] {bok.Title} by {bok.Author} - {bok.Status}");

                                    }
                                    Console.WriteLine("=======================");

                                }
                                else
                                {
                                    Console.WriteLine("fuck off");
                                    Console.WriteLine("=======================");

                                }


                                break;

                            case "4":
                                Console.Write("Which Book please tell id?");
                                var id = int.Parse(Console.ReadLine());
                                lib.BorrowBook(id);
                                Console.WriteLine("=======================");


                                break;

                            case "5":
                                Console.Write("Which Book Return please tell id?");
                                var ids = int.Parse(Console.ReadLine());
                                lib.ReturnBook(ids);
                                Console.WriteLine("=======================");

                                break;

                            case "6":
                                exit = true;
                                break;

                            default:
                                Console.WriteLine("Invalid Input");
                                Console.WriteLine("=======================");


                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Id or Password didnt match");
                }
            }


        }
    }
}

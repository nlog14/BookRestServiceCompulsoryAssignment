using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibraryCompulsoryAssignment;

namespace BookRestServiceCompulsoryAssignment.Managers
{
    public class BookManager
    {
        public List<Book> ListOfBooks = new List<Book>()
        {
            new Book("Twilight", "Stephenie Meyer", 501, "9780316015844"),
            new Book("To Kill a Mockingbird", "Harper Lee", 324, "9780446310789"),
            new Book("Jinx", "Meg Cabot", 262, "9780060837648"),
            new Book("Dune", "Frank Herbert", 688, "9780593099322")
        };

        public IEnumerable<Book> GetAllBooks(string isbn13 = "", string title ="", string author = "" )
        {
            isbn13 ??= string.Empty;
            title ??= string.Empty;
            author ??= string.Empty;
            List<Book> AllBooks = new List<Book>(ListOfBooks);
            var Results = AllBooks
                .Where(book => book.ISBN13.Contains(isbn13, StringComparison.OrdinalIgnoreCase))
                .Where(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .Where(book => book.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
            return Results;
        }


        public Book GetBookByISBN13(string isbn13)
        {
            Book ISBN13BookResult = ListOfBooks.Find(book => book.ISBN13.Equals(isbn13));
            return ISBN13BookResult;
        }

        public Book AddNewBook(Book book)
        {
            ListOfBooks.Add(book);
            return book;
        }

        public Book UpdateBook(string isbn13, Book update )
        {
            Book book = ListOfBooks.Find(book => book.ISBN13.Equals(isbn13));
            book.Title = update.Title;
            book.Author = update.Author;
            book.NumberOfPages = update.NumberOfPages;
            book.ISBN13 = update.ISBN13;
            return book;

        }

        public Book DeleteBook(string isbn13)
        {
          var book = ListOfBooks.Find(book => book.ISBN13.Equals(isbn13));
          ListOfBooks.Remove(book);
          return book;
        }




    }
}

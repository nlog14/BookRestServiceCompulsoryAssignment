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

        public IEnumerable<Book> GetAllBooks( string substring )
        {
            List<Book> Books = new List<Book>(ListOfBooks);
            if (substring != null)
            {
                Books = ListOfBooks.FindAll(book =>
                    book.ISBN13.Contains(substring, StringComparison.OrdinalIgnoreCase));
            }
            return Books;
        }


        public Book GetBookByISBN13(string isbn13)
        {
            Book ISBN13BookResult = ListOfBooks.Find(book => book.ISBN13.Equals(isbn13));
            return ISBN13BookResult;
        }

        public Book AddNewBook(Book newBook)
        {
            ListOfBooks.Add(newBook);
            return newBook;
        }

        public Book UpdateBook(string isbn13, Book update )
        {
            Book book = ListOfBooks.Find(book => book.ISBN13.Equals(isbn13));
            if (book.Equals(null)) return null;
            book.Title = update.Title;
            book.Author = update.Author;
            book.NumberOfPages = update.NumberOfPages;
            book.ISBN13 = update.ISBN13;
            return book;

        }

        public Book DeleteBook(string isbn13)
        {
          var book = ListOfBooks.Find(book => book.ISBN13.Equals(isbn13));
          if (book.Equals(null)) return null;
          ListOfBooks.Remove(book);
          return book;
        }

    }
}

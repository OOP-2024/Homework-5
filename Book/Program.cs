using System;

namespace book
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Throne of Glass", "Sarah J. Maas", 2012, 5000);
            Book book2 = new Book("Harry Potter", "J. K. Rowling");

            Console.WriteLine(book1);
            Console.WriteLine(book2);

            Console.WriteLine(Book.ComparePublicationDate(book1, book2));
        }
	}
}

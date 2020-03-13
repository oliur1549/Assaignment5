using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyWebProject.Framework
{
    public class BookService : IBookService
    {
        IList<Book> _DemoBookData;

        public BookService(string v)
        {
            _DemoBookData = new List<Book>();

            for (var i=0; i<100; i++)
            {
                _DemoBookData.Add(new Book
                {
                    id=i,
                    BookName= "Asp.NET Core" +i,
                    Author= "Microsoft Corporation",
                    Edition =i+ "Edition",
                    PublicationDate= DateTime.Now
                    
                });
            }
        }


        public (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex, int pageSize, string searchText, string v)
        {
            var filteredBooks = _DemoBookData.Where<Book>(x => x.BookName.Contains(searchText) || x.Author.Contains(searchText));

            var filteredBooksCount = filteredBooks.Count();
            var totalBooks = _DemoBookData.Count();

            var filteredBookList = filteredBooks.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return (filteredBookList, filteredBooksCount, totalBooks);
        }
    }
}

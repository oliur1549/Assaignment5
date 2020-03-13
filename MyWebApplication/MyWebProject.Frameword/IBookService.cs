using MyWebProject.Framework;
using System.Collections.Generic;

namespace MyWebProject.Framework
{
    public interface IBookService
    {
                                                             
        (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex, int pageSize, string searchText, string v);
    }
}
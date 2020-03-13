using Microsoft.Extensions.Configuration;
using MyWebProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Areas.Admin.Models
{
    public class BookModel : AdminBaseModel
    {
        private readonly IBookService _bookService;
        public BookModel(IConfiguration configuration)
        {
            _bookService = new BookService(configuration.GetConnectionString("DefaultConnection"));
        }

        internal object GetBooks(DataTablesAjaxRequestModel tableModel)
        {
            var data = _bookService.GetBooks(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "BookName", "Author", "Edition", "PublicationDate" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                
                                record.BookName,
                                record.Author,
                                record.Edition,
                                record.PublicationDate.ToString()
                                
                        }
                    ).ToArray()

            };
        }
    }
}

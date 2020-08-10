using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCCoreApp.Repository;
using Microsoft.AspNetCore.Mvc;


namespace FirstMVCCoreApp.Controllers
{
    public class BookController : Controller

    {
         private readonly BookRepository _bookRepository = null;
        public BookController()
        {
            _bookRepository = new BookRepository();
         }
       public ViewResult GetallBooks()
        {
        var data = _bookRepository.GetAllBooks();
        return View(data);
        }
        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBookByiD(id);
            return View(data);
        }
        public ViewResult Searchbook(String bookname, string author)
        {
            var data = _bookRepository.SearchBook(bookname, author);
            return View(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCCoreApp.Models;
using FirstMVCCoreApp.Repository;
using Microsoft.AspNetCore.Mvc;


namespace FirstMVCCoreApp.Controllers
{
    public class BookController : Controller

    {
       private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
         }
       public async Task<ViewResult> GetallBooks()
        {
        var data = await _bookRepository.GetAllBooks();
        return View(data);
        }

        [Route("Book-details/{id}",Name = "Bookdetailsroute")]
        public  async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookByiD(id);
            return View(data);
        }
        public ViewResult Searchbook(String bookname, string author)
        {
            var data = _bookRepository.SearchBook(bookname, author);
            return View(data);
        }

        public ViewResult AddBook(bool IsSuccess= false, int bookid=0)
        {
            ViewBag.IsSuccess = IsSuccess;
            ViewBag.Bookid = bookid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookmodel)
        {
            int id= await _bookRepository.AddNewBook(bookmodel);
            if(id>0)
            {
                return RedirectToAction(nameof(AddBook),new { IsSuccess=true, bookid = id });
            }    
            return View();
        }
    }
}

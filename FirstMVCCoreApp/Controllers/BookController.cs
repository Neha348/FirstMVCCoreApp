using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCCoreApp.Models;
using FirstMVCCoreApp.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstMVCCoreApp.Controllers
{
    public class BookController : Controller

    {
       private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
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

        public async Task<ViewResult> AddBook(bool IsSuccess= false, int bookid=0)
        {
            //ViewBag.Language = new SelectList(new List<string>(){
            //    "English","Hindi","Dutch"
            //}, selectedValue: "English");
            //var model = new BookModel()
            //{
            //    LanguageId = 1
            //};
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "id","Name");
            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.id.ToString()
            //}).ToList();
            //ViewBag.Language = new SelectList(GetLanguage(), "id", "Text");

            //How to use Group for the SelectListitem
            //var group1 = new SelectListGroup() { Name = "Group 1" };
            //var group2 = new SelectListGroup() { Name = "Group 2" , Disabled=true};
            //var group3 = new SelectListGroup() { Name = "Group 3" };

            //ViewBag.language = new List<SelectListItem>()
            //{
            //   new SelectListItem(){Text="Hindi", Value="1", Group=group1},
            //   new SelectListItem(){Text="English", Value="2", Group=group1},
            //   new SelectListItem(){Text="French", Value="3", Group=group2},
            //   new SelectListItem(){Text="Urdu", Value="4", Group=group2},
            //   new SelectListItem(){Text="Dutch", Value="5", Group=group3},
            //   new SelectListItem(){Text="Tamil", Value="6", Group=group3},

            //};
            ViewBag.IsSuccess = IsSuccess;
            ViewBag.Bookid = bookid;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookmodel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookmodel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { IsSuccess = true, bookid = id });
                }
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "id", "Name");


            //ViewBag.Language = new SelectList(new List<string>(){
            //    "English","Hindi","Dutch"
            //},selectedValue:"English");
            // another way of having the list item by function
            //dropdown by selectlist
            // ViewBag.Language = new SelectList(GetLanguage(), "id", "Text");
            //dropdown by selectlistitem

            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.id.ToString()
            //}).ToList();

            //How to use the group for the selectlistitem
            //var group1 = new SelectListGroup() { Name = "Group 1" };
            //var group2 = new SelectListGroup() { Name = "Group 2" };
            //var group3 = new SelectListGroup() { Name = "Group 3" };

            //ViewBag.language = new List<SelectListItem>()
            //{
            //   new SelectListItem(){Text="Hindi", Value="1", Group=group1},
            //   new SelectListItem(){Text="English", Value="2", Group=group1},
            //   new SelectListItem(){Text="French", Value="3", Group=group2},
            //   new SelectListItem(){Text="Urdu", Value="4", Group=group2},
            //   new SelectListItem(){Text="Dutch", Value="5", Group=group3},
            //   new SelectListItem(){Text="Tamil", Value="6", Group=group3},

            //};

            ModelState.AddModelError("", "This is my custome error Message");
            //ViewBag.IsSuccess = false;
            //ViewBag.Bookid = 0;
            return View();
        }
        //private List<LanguageModel> GetLanguage()
        //{
        //    return new List<LanguageModel>()
        //    {
        //        new LanguageModel(){ id=1, Text="English"},
        //        new LanguageModel(){id=2, Text="Hindi"},
        //        new LanguageModel(){id=3,Text="Dutch"}

        //    };
        //}

    }
}

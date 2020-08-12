using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCCoreApp.Models;
using Microsoft.AspNetCore.Routing;
using FirstMVCCoreApp.Controllers;
using System.Security.Cryptography.X509Certificates;
using FirstMVCCoreApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCCoreApp.Repository
{
    public class BookRepository
    {
        private readonly Bookstorecontext _context = null;
        public BookRepository(Bookstorecontext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook( BookModel model)
        {
            var newbook = new Books()
            {
                Title = model.Title,
                CreatedOn = DateTime.UtcNow,
                AuthorName = model.AuthorName,
                Description = model.Description,
                Totalpages = model.Totalpages,
                UpdatedOn=DateTime.UtcNow
            };
           await _context.book.AddAsync(newbook);
          await _context.SaveChangesAsync();
            return newbook.id;
        }
    public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.book.ToListAsync();
            if(allbooks?.Any()== true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        AuthorName = book.AuthorName,
                        Title = book.Title,
                        Catagory = book.Catagory,
                        Totalpages = book.Totalpages,
                        Description = book.Description,
                        id=book.id,
                        Language=book.Language
                    });
                }
            }
             return books;
        }
        public async Task<BookModel> GetBookByiD(int id)
        {
            var Book = await _context.book.FindAsync(id);
              if(Book!=null)
               {
                var bookdetails = new BookModel()
                {
                    AuthorName = Book.AuthorName,
                    Title = Book.Title,
                    Description = Book.Description,
                    Catagory = Book.Catagory,
                    Language = Book.Language,
                    Totalpages=Book.Totalpages,
                    id=Book.id
                };
                return bookdetails;
            }
          return null;
        
        }
        public List<BookModel> SearchBook(string title, string Author)
        {
            return Datasource().Where(x => x.Title.Contains(title) || x.AuthorName.Contains(Author)).ToList();
        }

        private List<BookModel> Datasource()
        {
            return new List<BookModel>()
            {
                new BookModel{ id=1, Title="MVC", AuthorName="Nitish", Description="This Book will cover all the details about MVC 3.1. THis book is designed specially for freshers and having pro - knowledge. Its latest version to all the functionalities included will be explained with examples.",Catagory="Programming",Language="English",Totalpages=200},
                new BookModel{ id=2, Title="DotNetCore", AuthorName="Nitish",Description="This is the Book on learning of Dotnetcore",Catagory="Framework",Language="English",Totalpages=1078},
                new BookModel{ id=3, Title="Angular", AuthorName="Samatha",Description="This is the New Book on basic Concepts of Angular",Catagory="Programming",Language="English",Totalpages=1033},
                new BookModel{ id=4, Title="C#", AuthorName="Neha",Description="This is the Book for learning More on C#",Catagory="Programming",Language="English",Totalpages=1078},
                new BookModel{ id=5, Title="PHP", AuthorName="Webgentle",Description="This is the Book for learning on PHP",Catagory="Programming",Language="English",Totalpages=988}
            };
        }
    }
}

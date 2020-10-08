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
                LanguageId = model.LanguageId,
                Title = model.Title,
                CreatedOn = Convert.ToDateTime(model.CreatedOn),
                AuthorName = model.AuthorName,
                Description = model.Description,
                Totalpages = model.Totalpages.HasValue ? model.Totalpages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageURL = model.CoverImageURL,
                BookPdfUrl=model.BookPdfUrl
            };

            newbook.bookGallery = new List<Bookgallery>();
            foreach( var file in model.Gallery)
            {
                newbook.bookGallery.Add(new Bookgallery()
                {
                    Name = file.Name, 
                    URL=file.URL, 
                });

            }
           await _context.book.AddAsync(newbook);
          await _context.SaveChangesAsync();
            return newbook.id;
        }
    public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.book.Select(book => new BookModel()
            {
                AuthorName = book.AuthorName,
                Title = book.Title,
                Catagory = book.Catagory,
                Totalpages = book.Totalpages,
                Description = book.Description,
                id = book.id,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                CoverImageURL = book.CoverImageURL,
                BookPdfUrl = book.BookPdfUrl

            }).ToListAsync();
               
                     
        }
        public async Task<BookModel> GetBookByiD(int id)
        {
            var Book = await _context.book.Where(x => x.id == id).Select(book => new BookModel()
            {
                AuthorName = book.AuthorName,
                Title = book.Title,
                Description = book.Description,
                Catagory = book.Catagory,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                Totalpages = book.Totalpages,
                id = book.id,
                CoverImageURL = book.CoverImageURL,
                Gallery = book.bookGallery.Select(g => new GalleryModel()
                {
                    Name = g.Name,
                    URL = g.URL,
                    Id = g.Id
                }).ToList(),
                BookPdfUrl = book.BookPdfUrl
            }).FirstOrDefaultAsync();
                
            //  if(Book!=null)
            //   {
            //    var bookdetails = new BookModel()
            //    {
            //        AuthorName = Book.AuthorName,
            //        Title = Book.Title,
            //        Description = Book.Description,
            //        Catagory = Book.Catagory,
            //        LanguageId = Book.LanguageId,
            //        Language = Book.Language.Name,
            //        Totalpages=Book.Totalpages,
            //        id=Book.id
            //    };
            //    return bookdetails;
            //}
          return Book;
        
        }
        public List<BookModel> SearchBook(string title, string Author)
        {
            return null;
          //  return Datasource().Where(x => x.Title.Contains(title) || x.AuthorName.Contains(Author)).ToList();
        }

        public async Task<List<BookModel>> GetTopBooksAsync( int count)
        {
            return await _context.book.Select(book => new BookModel()
            {
                AuthorName = book.AuthorName,
                Title = book.Title,
                Catagory = book.Catagory,
                Totalpages = book.Totalpages,
                Description = book.Description,
                id = book.id,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                CoverImageURL = book.CoverImageURL,
                BookPdfUrl = book.BookPdfUrl

            }).Take(count).ToListAsync();


        }

        //private List<BookModel> Datasource()
        //{
        //    return new List<BookModel>()
        //    {
        //        new BookModel{ id=1, Title="MVC", AuthorName="Nitish", Description="This Book will cover all the details about MVC 3.1. THis book is designed specially for freshers and having pro - knowledge. Its latest version to all the functionalities included will be explained with examples.",Catagory="Programming",Language="English",Totalpages=200},
        //        new BookModel{ id=2, Title="DotNetCore", AuthorName="Nitish",Description="This is the Book on learning of Dotnetcore",Catagory="Framework",Language="English",Totalpages=1078},
        //        new BookModel{ id=3, Title="Angular", AuthorName="Samatha",Description="This is the New Book on basic Concepts of Angular",Catagory="Programming",Language="English",Totalpages=1033},
        //        new BookModel{ id=4, Title="C#", AuthorName="Neha",Description="This is the Book for learning More on C#",Catagory="Programming",Language="English",Totalpages=1078},
        //        new BookModel{ id=5, Title="PHP", AuthorName="Webgentle",Description="This is the Book for learning on PHP",Catagory="Programming",Language="English",Totalpages=988}
        //    };
        //}
    }
}

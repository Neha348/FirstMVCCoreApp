using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCCoreApp.Models;
using Microsoft.AspNetCore.Routing;
using FirstMVCCoreApp.Controllers;
using System.Security.Cryptography.X509Certificates;

namespace FirstMVCCoreApp.Repository
{
    public class BookRepository
    {

    public List <BookModel> GetAllBooks()
        {
            return Datasource();
        }
        public BookModel GetBookByiD(int id)
        {
            return Datasource().Where(x => x.id == id).FirstOrDefault();
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

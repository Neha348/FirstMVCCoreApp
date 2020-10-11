using FirstMVCCoreApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookByiD(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        List<BookModel> SearchBook(string title, string Author);

        string Getappname();
    }
}
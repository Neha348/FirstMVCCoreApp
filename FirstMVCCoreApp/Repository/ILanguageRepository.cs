using FirstMVCCoreApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}
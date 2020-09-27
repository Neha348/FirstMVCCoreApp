using FirstMVCCoreApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCCoreApp.Repository
{
    public class LanguageRepository
    {

        private readonly Bookstorecontext _context = null;
        public LanguageRepository(Bookstorecontext context)
        {
            _context = context;
        }
        
        public async Task<List<LanguageModel>> GetLanguages()
        {
          return await _context.Language.Select(x => new LanguageModel()
            {
                id = x.id,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync(); 
        
        }
          
    }
        
}

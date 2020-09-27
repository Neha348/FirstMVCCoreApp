using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Data
{
    public class Books
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }
        public int LanguageId { get; set; }
       // public List<string> MultiLanguage { get; set; }
        public int Totalpages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public Language Language { get; set; }
    }
}

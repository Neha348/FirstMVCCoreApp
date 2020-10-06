using FirstMVCCoreApp.Enum;
using FirstMVCCoreApp.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Models
{
    public class BookModel
    {
        [DataType(DataType.Date)]
        [Display(Name ="Choose the Date")]
        public string CreatedOn { get; set;  }
        public int id { get; set; }

        //[StringLength(100,MinimumLength =5)]
        //[Required(ErrorMessage ="Please Enter the Title of Your book")]
        //[MyCustomeValidationAttribute("Azure")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Please Enter the Author Name")]
        public string AuthorName { get; set; }

        [StringLength(500, MinimumLength = 50)]
        public string Description { get; set; }
        public string Catagory { get; set; }

        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage ="Please Select the Language of your Book")]
    //    public string MultiLanguage { get; set; }

        public LanguageEnum LanguageEnum { get; set; }

        [Required(ErrorMessage = "Please Enter the Total Pages")]
        [Display(Name ="Total pages of Book")]
        public int? Totalpages { get; set; }

        [Display(Name = "Choose the Cover Photo of your Book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageURL { get; set; }

        [Display(Name = "Choose the Gallery images for your Book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }

        [Display(Name = "Upload your Book in Pdf File format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
}

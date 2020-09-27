using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Helper
{
    public class MyCustomeValidationAttribute : ValidationAttribute

    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value!=null)
            {
                string bookname = value.ToString();
                if(bookname.Contains("MVC"))
                {
                   return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage?? "Bookname does not contain the desired value");
            //if the error message is provided in the Bookmodel 
            //then that will be come if it is not specified , it will pick from here. 
        }
    }
}

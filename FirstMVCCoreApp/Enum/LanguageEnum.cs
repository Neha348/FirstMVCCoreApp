using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Enum
{
    public enum LanguageEnum
    {
        [Display(Name ="English Language")]
        English = 1,
        [Display(Name = "Hindi Language")]
        Hindi =2 ,
        [Display(Name = "Dutch Language")]
        Dutch = 3,
        [Display(Name = "French Language")]
        French= 4,
        [Display(Name = "Chinese Language")]
        Chinese = 5,
        [Display(Name = "Tamil Language")]
        Tamil = 6
    }
}

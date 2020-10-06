using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCCoreApp.Helper
{
    public class CustomEmailTagHelper: TagHelper
    {
        public string myemail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            //output.Attributes.SetAttribute("href", "Mailto:nearora0@in.ibm.com");
            output.Attributes.SetAttribute("href", $"Mailto:{myemail}");
            output.Attributes.Add("id", "my-email-id");
            output.Content.SetContent("my-email");
        }
    }
}

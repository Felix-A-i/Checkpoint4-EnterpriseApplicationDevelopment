using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint.TagHelpers
{
    public class BotaoTagHelper : TagHelper
    {
        public string Texto { get; set; }
        public string Class { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.SetAttribute("type", "submit");
            output.Attributes.SetAttribute("value", string.IsNullOrEmpty(Texto) ? "Cadastrar" : Texto);
            output.Attributes.SetAttribute("class", string.IsNullOrEmpty(Class) ? "btn btn-success" : Class);
        }
    }
}

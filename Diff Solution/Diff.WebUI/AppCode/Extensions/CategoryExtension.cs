using Diff.WebUI.Models.Entities;
using Microsoft.AspNetCore.Html;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diff.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
        public static HtmlString GetCategoriesRaw()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>");

            for (int i = 0; i < 10; i++)
            {
                sb.Append($"<li>{i}</li>");
            }
            sb.Append("</ul>");

            return new HtmlString(sb.ToString());
        }


        //burada bir extension daha olmalidir(AppendCategory)



        public static IEnumerable<Category> GetChildren(this Category category)
        {
            if (category.ParentId != null)
            {
                yield return category;
            }

            foreach (var item in category.Children.SelectMany(c => c.GetChildren()))
            {
                yield return item;
            }
        }
    }
}




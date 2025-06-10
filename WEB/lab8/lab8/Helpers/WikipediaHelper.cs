
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab8.Helpers
{
    

    public static class HtmlHelpers
    {
        public static IHtmlContent WikipediaLinks(this IHtmlHelper htmlHelper, List<string> links)
        {
            if (links == null || links.Count == 0)
                return HtmlString.Empty;

            var html = "<h3>Wikipedia links:</h3><ul>";
            foreach (var link in links)
            {
                var title = System.Net.WebUtility.HtmlEncode(System.IO.Path.GetFileName(link).Replace("_", " "));
                html += $"<li><a href=\"{link}\" target=\"_blank\">{title}</a></li>";
            }
            html += "</ul>";

            return new HtmlString(html);
        }
    }

}

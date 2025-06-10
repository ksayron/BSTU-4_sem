using lab6_MSSQL_LIB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System.Net.Http;
namespace lab8.Models;


    public class WikipediaReferencesFilter : ActionFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Controller is Controller controller &&
                controller.ViewData.Model is Celebrity celeb &&
                !string.IsNullOrWhiteSpace(celeb.FullName))
            {
                var links = new List<string>();
                using (var http = new HttpClient())
                {

                    var url = $"https://en.wikipedia.org/w/api.php?action=query&list=search&srsearch={celeb.FullName}&format=json";

                    var response = await http.GetStringAsync(url);
                    var json = JObject.Parse(response);

                    var searchResults = json["query"]?["search"];
                    if (searchResults != null)
                    {
                        foreach (var result in searchResults)
                        {
                            string title = result["title"]?.ToString();
                            if (!string.IsNullOrEmpty(title))
                            {
                                string pageUrl = $"https://en.wikipedia.org/wiki/{title.Replace(" ", "_")}";
                                links.Add(pageUrl);
                            }
                        }
                    }
                }

                controller.ViewData["WikipediaLinks"] = links;
            }

            await next();
        }
    }   


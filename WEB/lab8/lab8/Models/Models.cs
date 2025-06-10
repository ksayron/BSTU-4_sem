using lab6_MSSQL_LIB;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace lab8.Models
{
    public class Country
    {
        [JsonPropertyName("countryLabel")]
        public string CountryLabel { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
    public class NewCelebrityViewModel
    {
        public int Id {  get; set; }
        public string FullName { get; set; }

        [Required]
        public string Nationality { get; set; }
        public string ReqPhotoPath { get; set; }

        public List<SelectListItem> Countries { get; set; }
        [Required]
        public IFormFile UploadedFile { get; set; }
        public Celebrity NewCelebrity { get; set; }
        public string Message { get; set; }
    }
    public class CelebrityWithFile
    {
        public Celebrity celebrity;
        public IFormFile File;
    }

}

using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab3_LIB
{
    public class JSONCelebrityRepository : ICelebrityRepository
    {
        private Celebrity[] celebrities;
        public readonly string DIR_Path;
        public readonly string JSON_Path;
        public static string JSONFileName = "Сelebrities.json";

        string ICelebrityRepository.JSON_Path => throw new NotImplementedException();


        public JSONCelebrityRepository(string basePath)
        {
            DIR_Path = Path.Combine(Directory.GetCurrentDirectory(), basePath);
            JSON_Path = Path.Combine(DIR_Path, JSONFileName);

            if (!Directory.Exists(DIR_Path))
            {
                Console.WriteLine(DIR_Path);
                Directory.CreateDirectory(DIR_Path);
            }
            if (!File.Exists(JSON_Path))
            {
                File.WriteAllText(JSON_Path, "[]");
            }
            Console.WriteLine(DIR_Path);
            var jsonContent = File.ReadAllText(JSON_Path);
            celebrities = JsonSerializer.Deserialize<Celebrity[]>(jsonContent) ?? Array.Empty<Celebrity>();
        }

        public static JSONCelebrityRepository Create(string dir) => new JSONCelebrityRepository(dir);


        public Celebrity[] GetAll()
        {
            return celebrities;
        }

        public Celebrity? GetByID(int id)
        {
            return celebrities.FirstOrDefault(p=>p.Id==id);
        }



        public Celebrity[] GetBySurname(string Surname)
        {
            return celebrities.Where(p => p.Surname == Surname).ToArray();
        }

        public string GetPhotoPathByID(int id)
        {
            var celeb = celebrities.FirstOrDefault(p => p.Id == id);
            if (celeb != null)
            {
                return celeb.PhotoPath;
            }
            else
            {
                return "Not Found";  
            }
        }

        public void Dispose(){}
    }
}

using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using lab4_LIB;
using System.Xml.Linq;

namespace lab4_LIB
{
    public class JSONCelebrityRepository : ICelebrityRepository
    {
        private List<Celebrity> celebrities;
        public readonly string DIR_Path;
        public readonly string JSON_Path;
        public static string JSONFileName = "Сelebrities.json";
        int ChangeCount;

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
            celebrities = JsonSerializer.Deserialize<List<Celebrity>>(jsonContent) ?? new List<Celebrity>();
            ChangeCount = 0;
        }

        public static JSONCelebrityRepository Create(string dir) => new JSONCelebrityRepository(dir);


        public Celebrity[] GetAll()
        {
            return celebrities.ToArray();
        }

        public Celebrity? GetByID(int id)
        {
            return celebrities.FirstOrDefault(p => p.Id == id);
        }



        public Celebrity[] GetBySurname(string Surname)
        {
            return celebrities.Where(p => p.Surname == Surname).ToArray();
        }

        public string? GetPhotoPathByID(int id)
        {
            var celeb = celebrities.FirstOrDefault(p => p.Id == id);
            if (celeb != null)
            {
                return celeb.PhotoPath;
            }
            else
            {
                return null;
            }
        }

        public void Dispose() { }

        public int? AddCelebrity(Celebrity celebrity)
        {
            int pos = celebrities.FindIndex(p => p.Id == celebrity.Id);
            if (pos != -1)
            {
                celebrity.Id = celebrities.Count + 1;
            }
            celebrities.Add(celebrity);
            ChangeCount++;
            return celebrity.Id;
        }

        public bool DeleteCelebrity(int id)
        {
            var celeb = GetByID(id);
            if (celeb != null)
            {
                ChangeCount++;
                return celebrities.Remove(celeb);
            }
            else return false;

        }

        public int? UpdateCelebByID(int id, Celebrity celebrity)
        {
            int pos = celebrities.FindIndex(p => p.Id == id);
            if (pos!= -1){
                celebrities[pos].Surname = celebrity.Surname;
                celebrities[pos].Firstname = celebrity.Firstname;
                celebrities[pos].PhotoPath = celebrity.PhotoPath;
                ChangeCount++;
                return celebrities[pos].Id;
            }
            return null;
        }

        public int SaveChanges()
        {
            string json = JsonSerializer.Serialize(celebrities, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JSON_Path, json);
            var ret = ChangeCount;
            ChangeCount = 0;
            return ret;
        }
    }
}

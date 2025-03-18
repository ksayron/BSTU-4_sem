using lab3_LIB;

namespace lab3_TEST
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            JSONCelebrityRepository.JSONFileName = "Сelebrities.json";  // имя файла
            using (ICelebrityRepository repository = JSONCelebrityRepository.Create("Сelebrities"))  // директория (в текущем директории приложения)
            {
                foreach (Celebrity celebrity in repository.GetAll())
                {
                    Console.WriteLine($"Id = {celebrity.Id}, Firstname = {celebrity.Firstname}, " +
                                      $"Surname = {celebrity.Surname}, PhotoPath = {celebrity.PhotoPath} ");
                }

                Celebrity? celebrity1 = repository.GetByID(1);
                if (celebrity1 != null)
                {
                    Console.WriteLine($"Id = {celebrity1.Id}, Firstname = {celebrity1.Firstname}, " +
                                      $"Surname = {celebrity1.Surname}, PhotoPath = {celebrity1.PhotoPath}");
                }

                Celebrity? celebrity3 = repository.GetByID(3);
                if (celebrity3 != null)
                {
                    Console.WriteLine($"Id = {celebrity3.Id}, Firstname = {celebrity3.Firstname}, " +
                                      $"Surname = {celebrity3.Surname}, PhotoPath = {celebrity3.PhotoPath}");
                }

                Celebrity? celebrity7 = repository.GetByID(7);
                if (celebrity7 != null)
                {
                    Console.WriteLine($"Id = {celebrity7.Id}, Firstname = {celebrity7.Firstname}, " +
                                      $"Surname = {celebrity7.Surname}, PhotoPath = {celebrity7.PhotoPath}");
                }

                Celebrity? celebrity222 = repository.GetByID(222);
                if (celebrity222 != null)
                {
                    Console.WriteLine($"Id = {celebrity222.Id}, Firstname = {celebrity222.Firstname}, " +
                                      $"Surname = {celebrity222.Surname}, PhotoPath = {celebrity222.PhotoPath}");
                }
                else Console.WriteLine("Not Found 222");

                foreach (Celebrity celebrity in repository.GetBySurname("Chomsky"))
                {
                    Console.WriteLine($"Id = {celebrity.Id}, Firstname = {celebrity.Firstname}, " +
                                      $"Surname = {celebrity.Surname}, PhotoPath = {celebrity.PhotoPath} ");
                }

                foreach (Celebrity celebrity in repository.GetBySurname("Knuth"))
                {
                    Console.WriteLine($"Id = {celebrity.Id}, Firstname = {celebrity.Firstname}, " +
                                      $"Surname = {celebrity.Surname}, PhotoPath = {celebrity.PhotoPath} ");
                }

                foreach (Celebrity celebrity in repository.GetBySurname("XXXX"))
                {
                    Console.WriteLine($"Id = {celebrity.Id}, Firstname = {celebrity.Firstname}, " +
                                      $"Surname = {celebrity.Surname}, PhotoPath = {celebrity.PhotoPath} ");
                }

                Console.WriteLine($"PhotoPathById = {repository.GetPhotoPathByID(4)}");
                Console.WriteLine($"PhotoPathById = {repository.GetPhotoPathByID(6)}");
                Console.WriteLine($"PhotoPathById = {repository.GetPhotoPathByID(222)}");
            }
        }
    }
}

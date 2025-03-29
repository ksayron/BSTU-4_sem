using lab4_LIB;

JSONCelebrityRepository.JSONFileName = "Celebrities.json";
using (ICelebrityRepository repository = JSONCelebrityRepository.Create("Celebrities"))
{
    void print(string label)
    {
        Console.WriteLine("----" + label + " ----------------");
        foreach (Celebrity celebrity in repository.GetAll())
        {
            Console.WriteLine($"Id = {celebrity.Id}, Firstname = {celebrity.Firstname}, " +
                $"Surname = {celebrity.Surname}, PhotoPath = {celebrity.PhotoPath} ");
        }
    }

    print("start");

    int? testdel1 = repository.AddCelebrity(new Celebrity(0, "TestDel1", "TestDel1", "Photo/TestDel1.jpg"));
    int? testdel2 = repository.AddCelebrity(new Celebrity(0, "TestDel2", "TestDel2", "Photo/TestDel2.jpg"));
    int? testupd1 = repository.AddCelebrity(new Celebrity(0, "TestUpd1", "TestUpd1", "Photo/TestUpd1.jpg"));
    int? testupd2 = repository.AddCelebrity(new Celebrity(0, "TestUpd2", "TestUpd2", "Photo/TestUpd2.jpg"));
    repository.SaveChanges();
    print("add 4");

    if (testdel1 != null)
        if (repository.DeleteCelebrity((int)testdel1)) Console.WriteLine($" delete {testdel1} "); else Console.WriteLine($" delete {testdel1} error");

    if (testdel2 != null)
        if (repository.DeleteCelebrity((int)testdel2)) Console.WriteLine($" delete {testdel2} "); else Console.WriteLine($" delete {testdel2} error");

    if (repository.DeleteCelebrity(1000)) Console.WriteLine($" delete {1000} "); else Console.WriteLine($" delete {1000} error");
    repository.SaveChanges();
    print("del 2");

    if (testupd1 != null)
    {
        int? result = repository.UpdateCelebByID((int)testupd1, new Celebrity((int)testupd1, "Updated1", "Updated1", "Photo/Updated1.jpg"));
        if (result != null) Console.WriteLine($"update {testupd1}");
        else Console.WriteLine($"update {testupd1} error");
    }

    if (testupd2 != null)
    {
        int? result = repository.UpdateCelebByID((int)testupd2, new Celebrity((int)testupd2, "Updated2", "Updated2", "Photo/Updated2.jpg"));
        if (result != null) Console.WriteLine($"update {testupd2}");
        else Console.WriteLine($"update {testupd2} error");
    }

    int? result1000 = repository.UpdateCelebByID(1000, new Celebrity(0, "Updated1000", "Updated1000", "Photo/Updated1000.jpg"));
    if (result1000 != null) Console.WriteLine($" update {1000}");
    else Console.WriteLine($" update {1000} error");

    repository.SaveChanges();
    print("upd 2");
}
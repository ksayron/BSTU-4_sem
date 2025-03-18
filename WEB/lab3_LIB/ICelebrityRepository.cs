using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_LIB
{
    public interface ICelebrityRepository : IDisposable
    {
        string JSON_Path { get; }
        Celebrity[] GetAll();
        Celebrity? GetByID(int id);
        Celebrity[] GetBySurname(string Surname);
        string GetPhotoPathByID(int id);
    }
}

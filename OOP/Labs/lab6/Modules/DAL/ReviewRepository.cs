using Lab4_5.Modules.classes;
using Lab4_5.Modules.db;
using Lab4_5.Modules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_5.Modules.DAL
{
    public class ReviewRepository
    {
        LibraryContext context;
        public ReviewRepository()
        {
            context = new LibraryContext();
        }
        public ReviewRepository(string ConnString)
        {
            context = new LibraryContext(ConnString);
        }
        public ReviewRepository(LibraryContext context)
        {
            this.context = context;
        }
    }
}

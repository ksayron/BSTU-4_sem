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
    public class OrderRepository : IOrder
    {
        LibraryContext context;
        public OrderRepository()
        {
            context = new LibraryContext();
        }
        public OrderRepository(string ConnString)
        {
            context = new LibraryContext(ConnString);
        }
        public OrderRepository(LibraryContext context)
        {
            this.context = context;
        }
    }
}

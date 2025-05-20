using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.Interfaces
{
    interface IOrder<T> : IDisposable
    {
        List<T> GetAllOrders();
        List<T> GetOrdersByBookId(int bookid);
        List<T> GetOrdersByUserId(int userid);
        T? GetOrderById(int id);
        bool AddOrder(T order);
        bool DeleteOrderById(int id);
        bool UpdateOrderById(int id,T new_order);
    }
}

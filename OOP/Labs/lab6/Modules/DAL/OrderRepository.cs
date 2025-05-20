using KNP_Library.Modules.classes;
using KNP_Library.Modules.db;
using KNP_Library.Modules.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNP_Library.Modules.DAL
{
    public class OrderRepository : IOrder<Order>
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

        public bool AddOrder(Order order)
        {
            this.context.Orders.Add(order);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.ShowDialog();
                return false;
            }
            return true;
        }

        public bool DeleteOrderById(int id)
        {
            var order = GetOrderById(id);
            if (order is null)
            {
                var error = new Message("Error", "No id found");
                error.Show();
                return false;
            }
            this.context.Orders.Remove(order);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public void Dispose()
        {

        }

        public List<Order> GetAllOrders()
        {
            return this.context.Orders.Include(b => b.User).Include(b => b.Book).ToList();
        }

        public Order? GetOrderById(int id)
        {
            return this.context.Orders.Include(b => b.Book).Include(b => b.User).FirstOrDefault(u => u.OrderId == id);
        }

        public List<Order> GetOrdersByBookId(int bookid)
        {
            return this.context.Orders.Include(b => b.User).Include(b => b.Book).Where(r => r.BookId == bookid).ToList();
        }

        public List<Order> GetOrdersByUserId(int userid)
        {
            return this.context.Orders.Include(b => b.User).Include(b => b.Book).Where(r => r.UserId == userid).ToList();
        }

        public bool UpdateOrderById(int id, Order new_order)
        {
            var updated_order = GetOrderById(id);
            if (updated_order is null)
            {
                return false;
            }
            updated_order.UserId = new_order.UserId;
            updated_order.BookId = new_order.BookId;
            updated_order.DueAt = new_order.DueAt;
            updated_order.ClosedAt = new_order.ClosedAt;
            this.context.Orders.Update(updated_order);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }
    }
}

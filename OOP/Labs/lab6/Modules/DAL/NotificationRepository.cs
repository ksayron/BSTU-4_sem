using KNP_Library.Modules.classes;
using KNP_Library.Modules.db;
using KNP_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4_5.Modules.classes;
using Microsoft.EntityFrameworkCore;

namespace KNP_Library.Modules.DAL
{
    public class NotificationRepository
    {
        LibraryContext context;
        public NotificationRepository()
        {
            context = new LibraryContext();
        }
        public NotificationRepository(string ConnString)
        {
            context = new LibraryContext(ConnString);
        }
        public NotificationRepository(LibraryContext context)
        {
            this.context = context;
        }
        public bool AddNotification(Notification notification)
        {
            this.context.Notifications.Add(notification);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                return false;
            }
            return true;
        }

        public bool DeleteNotificationById(int id)
        {
            var notification = GetNotificationById(id);
            if (notification is null)
            {
                var error = new Message("Error", "No id found");
                error.Show();
                return false;
            }
            this.context.Notifications.Remove(notification);
            try { this.context.SaveChanges(); }
            catch (Exception ex)
            {
                var error = new Message("Error", ex.Message);
                error.Show();
                return false;
            }
            return true;
        }

        public List<Notification> GetAllNotifications()
        {
            return this.context.Notifications.ToList();
        }
        public List<Notification> GetAllActiveNotifications()
        {
            return this.context.Notifications.Where(n=> n.ExpireAt > DateTime.Now).ToList();
        }

        public Notification? GetNotificationById(int id)
        {
            return this.context.Notifications.FirstOrDefault(u => u.Id == id);
        }

        public bool UpdateNotification(int id, Notification notification)
        {
            var updated_notif = GetNotificationById(id);
            if (updated_notif is null)
            {
                return false;
            }
            updated_notif.Message = notification.Message;
            updated_notif.ExpireAt = notification.ExpireAt;
            this.context.Notifications.Update(updated_notif);
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
    }
}

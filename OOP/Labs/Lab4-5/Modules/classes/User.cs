using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4_5.Modules.classes
{
    public class User
    {
        
        [Key]
        public int Id { get; set; }//primary key 
        [Required]
        public int CardId { get; set; }//номер читательского билета
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Username { get; set; }
        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Wrong email format")]
        public string Email { get; set; }
        [Range(1, 10)]
        public int ProfilePicId { get; set; } = 1;
        [Required]
        public int RoleId { get; set; }//foreign key
        public Role UserRole { get; set; }
        public DateTime CreatedAt { get; private set; }
        public List<Order> Orders { get; set; }//all orders
        [NotMapped]
        public List<Order> ActiveBooks => Orders?.Where(o => o.IsActive).ToList() ?? [];
        [NotMapped]
        public List<Order> HistoryLog => Orders?.Where(o => !o.IsActive).ToList() ?? [];
        public List<Review> Reviews { get; set; }// all user reviews

        public User()
        {
            Username = string.Empty;
            PasswordHash = string.Empty;
            Email = string.Empty;
            RoleId = 1;
            UserRole = new Role();
            CreatedAt = DateTime.Now;
            Orders = [];
            Reviews = [];
        }
        public User(int carrd_id,string username, string password, string email, int roleid)
        {
            CardId = carrd_id;
            Username = username;
            PasswordHash = password;
            Email = email;
            RoleId = roleid;
            UserRole = new Role();
            CreatedAt = DateTime.Now;
            Orders = [];
            Reviews = [];
        }

    }
}

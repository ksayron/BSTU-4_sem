using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KNP_Library.Modules.classes
{
    public class User : INotifyPropertyChanged
    {
        private int _id;
        private int _cardId;
        private string _username;
        private string _passwordHash;
        private string _email;
        private string _profilePicImage;
        private int _roleId;
        private Role _userRole;
        private DateTime _createdAt;
        private List<Order> _orders = new();
        private List<Review> _reviews = new();

        [Key]
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        [Required]
        public int CardId
        {
            get => _cardId;
            set
            {
                if (_cardId != value)
                {
                    _cardId = value;
                    OnPropertyChanged(nameof(CardId));
                }
            }
        }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        [Required]
        public string PasswordHash
        {
            get => _passwordHash;
            set
            {
                if (_passwordHash != value)
                {
                    _passwordHash = value;
                    OnPropertyChanged(nameof(PasswordHash));
                }
            }
        }

        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Wrong email format")]
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        [StringLength(1000)]
        public string ProfilePicImage
        {
            get => _profilePicImage;
            set
            {
                if (_profilePicImage != value)
                {
                    _profilePicImage = value;
                    OnPropertyChanged(nameof(ProfilePicImage));
                }
            }
        }

        [Required]
        public int RoleId
        {
            get => _roleId;
            set
            {
                if (_roleId != value)
                {
                    _roleId = value;
                    OnPropertyChanged(nameof(RoleId));
                }
            }
        }

        public Role UserRole
        {
            get => _userRole;
            set
            {
                if (_userRole != value)
                {
                    _userRole = value;
                    OnPropertyChanged(nameof(UserRole));
                }
            }
        }

        public DateTime CreatedAt
        {
            get => _createdAt;
            private set
            {
                if (_createdAt != value)
                {
                    _createdAt = value;
                    OnPropertyChanged(nameof(CreatedAt));
                }
            }
        }

        public List<Order> Orders
        {
            get => _orders;
            set
            {
                if (_orders != value)
                {
                    _orders = value;
                    OnPropertyChanged(nameof(Orders));
                    OnPropertyChanged(nameof(ActiveBooks));
                    OnPropertyChanged(nameof(HistoryLog));
                }
            }
        }

        [NotMapped]
        public List<Order> ActiveBooks => Orders?.Where(o => o.IsActive).ToList() ?? [];

        [NotMapped]
        public List<Order> HistoryLog => Orders?.Where(o => !o.IsActive).ToList() ?? [];

        public List<Review> Reviews
        {
            get => _reviews;
            set
            {
                if (_reviews != value)
                {
                    _reviews = value;
                    OnPropertyChanged(nameof(Reviews));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public User()
        {
            Username = "User";
            PasswordHash = "Test";
            Email = "Test@Test.test";
            ProfilePicImage = "";
            RoleId = 1;
            CreatedAt = DateTime.Now;

        }
        public User(int carrd_id,string username, string password, string email, int roleid)
        {
            CardId = carrd_id;
            Username = username;
            PasswordHash = password;
            Email = email;
            RoleId = roleid;
            ProfilePicImage = "";
            CreatedAt = DateTime.Now;

        }

        
       
    }
}

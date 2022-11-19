using AttributeExample.Models;

namespace AttributeExample.Services
{
    public class UserService
    {
        public User GetUserByName(string username)
        {
            List<User> users = new()
            {
                new(){Id = 1, Username = "mert", Brand = "Peugeout"},
                new(){Id = 2, Username = "elif", Brand = "Mercedes"},
            };

            return users.First(u => u.Username == username);
        }
    }
}

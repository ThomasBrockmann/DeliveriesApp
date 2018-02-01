using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveriesApp.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public static async Task<bool> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return false;
            User user = (await AzureHelper.MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
            if (user.Password == password)
                return true;

            return false;
        }

        public static async Task<bool> Register(string email, string password, string confirmpassword)
        {
            if (password == confirmpassword)
            {
                var user = new User()
                {
                    Email = email,
                    Password = password
                };
                try
                {
                    await AzureHelper.Insert<User>(user);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }

}

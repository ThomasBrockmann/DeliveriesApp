using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveriesApp.Model
{
    public class DeliveryPerson
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static async Task<string> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return string.Empty;
            DeliveryPerson deliveryPerson = (await AzureHelper.MobileService.GetTable<DeliveryPerson>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
            if (deliveryPerson.Password == password)
                return deliveryPerson.Id;

            return string.Empty;
        }

        public static async Task<bool> Register(string email, string password, string confirmpassword)
        {
            if (password == confirmpassword)
            {
                var deliveryPerson = new DeliveryPerson()
                {
                    Email = email,
                    Password = password
                };
                try
                {
                    await AzureHelper.Insert<DeliveryPerson>(deliveryPerson);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public static async Task<DeliveryPerson> GetDeliveryPerson(string id)
        {

            DeliveryPerson person = new DeliveryPerson();
            person = (await AzureHelper.MobileService.GetTable<DeliveryPerson>().Where(p => p.Id == id).ToListAsync()).FirstOrDefault();

            return person;
        }

    }
}

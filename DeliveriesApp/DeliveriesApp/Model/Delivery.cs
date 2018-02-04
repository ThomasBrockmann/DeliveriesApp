using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriesApp.Model
{
    public class Delivery
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }
        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }
        /// <summary>
        /// 0 = waitung delivery person
        /// 1 = beeing delivered
        /// 2 = delivered
        /// </summary>
        /// <returns></returns>       
        public int Status { get; set; }

        public string DeliveryPersonId { get; set; }

        public static async Task<bool> MarkAsPickedUp(Delivery delivery, string deliveryPersonId)
        {
            try
            {
                delivery.Status = 1;
                delivery.DeliveryPersonId = deliveryPersonId;
                await AzureHelper.MobileService.GetTable<Delivery>().UpdateAsync(delivery);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static async Task<bool> MarkAsPickedUp(string deliveryId, string deliveryPersonId)
        {
            try
            {
                Delivery delivery = (await AzureHelper.MobileService.GetTable<Delivery>().Where(d => d.Id == deliveryId).ToListAsync()).FirstOrDefault();
                delivery.Status = 1;
                delivery.DeliveryPersonId = deliveryPersonId;
                await AzureHelper.MobileService.GetTable<Delivery>().UpdateAsync(delivery);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> MarkAsDelivered(Delivery delivery)
        {
            try
            {
                delivery.Status = 2;
                await AzureHelper.MobileService.GetTable<Delivery>().UpdateAsync(delivery);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static async Task<bool> MarkAsDelivered(string deliveryId)
        {
            try
            {
                Delivery delivery = (await AzureHelper.MobileService.GetTable<Delivery>().Where(d => d.Id == deliveryId).ToListAsync()).FirstOrDefault();
                delivery.Status = 2;
                await AzureHelper.MobileService.GetTable<Delivery>().UpdateAsync(delivery);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static async Task<List<Delivery>> GetDeliveries()
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.MobileService.GetTable<Delivery>().Where(d => d.Status != 2).ToListAsync();

            return deliveries;
        }
        public static async Task<List<Delivery>> GetWaiting()
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.MobileService.GetTable<Delivery>().Where(d => d.Status == 0).ToListAsync();

            return deliveries;
        }
        public static async Task<List<Delivery>> GetDelivered()
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.MobileService.GetTable<Delivery>().Where(d => d.Status == 2).ToListAsync();

            return deliveries;
        }
        public static async Task<List<Delivery>> GetDelivered(string personID)
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.MobileService.GetTable<Delivery>().Where(d => d.Status == 2 && d.DeliveryPersonId == personID).ToListAsync();

            return deliveries;
        }
        public static async Task<List<Delivery>> GetBeeingDelivered(string id)
        {
            List<Delivery> deliveries = new List<Delivery>();
            deliveries = await AzureHelper.MobileService.GetTable<Delivery>().Where(d => d.Status == 1 && d.DeliveryPersonId == id).ToListAsync();

            return deliveries;
        }

        public static async Task<bool> InsertDelivery(Delivery delivery)
        {
            return await AzureHelper.Insert<Delivery>(delivery);
        }

        public override string ToString()
        {
            return $"{Name} - {Status}";
        }

    }
}

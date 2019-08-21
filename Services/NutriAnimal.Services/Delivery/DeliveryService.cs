using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NutriAnimal.Data;
using NutriAnimal.Data.Models;
using NutriAnimal.Web.ViewModels.Delivery;

namespace NutriAnimal.Services.Delivery
{
    public class DeliveryService : IDeliveryService
    {
        private readonly ApplicationDbContext context;

        public DeliveryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CompleteOrder(CreateDeliveryInputModel inputModel)
        {
            var orders = this.context.Orders
                .Where(order => order.IssuerId == inputModel.IssuedById && order.Status.Name == "Active")
                .ToList();
            double allWeight = 0;
            

            var delivery = new NutriAnimal.Data.Models.Delivery
            {
                Address = inputModel.Address,
                IssuedById = inputModel.IssuedById,
                Recipient = inputModel.Recipient,
                Status=this.context.Statuses.First(status => status.Name == "Pending"),
            };
            foreach (var item in orders)
            {
                item.Status = this.context.Statuses.SingleOrDefault(status => status.Name == "Completed");
                var product = this.context.Products.FirstOrDefault(x => x.Id == item.ProductId);
               
                allWeight += product.Weight * item.Quantity;
                delivery.Orders.Add(item);
                this.context.Orders.Update(item);
            }

            

            
            var deliveryCompany = this.context.DeliveryCompanies.FirstOrDefault(company => company.Name == inputModel.DeliveryCompany);
            var deliveryType = this.context.DeliveryTypes.FirstOrDefault(type => type.Name == inputModel.DeliveryType);
            delivery.DeliveryCompany = deliveryCompany;
            delivery.DeliveryType = deliveryType;
         
            if (allWeight<1)
            {
                delivery.Price = deliveryCompany.Price;
            }
            else if (allWeight<5)
            {
                delivery.Price = deliveryCompany.Price * 1.5M;
            }
            else
            {
                var heavyDelivery = (decimal)(allWeight * 0.75);
                delivery.Price = (deliveryCompany.Price * 1.5M) + heavyDelivery;
            }

            if (deliveryType.Name == "To Address")
            {
                delivery.Price += delivery.Price * 0.15M;
            }
            else
            {
                delivery.Price += delivery.Price * 0.08M;
            }

            if (deliveryType.Name == "To Office")
            {
                delivery.Address = "Company Office";
            }
            this.context.Deliveries.Add(delivery);
           
            var result = await this.context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Finish(string id)
        {
            var deliveryToFinish = await this.context.Deliveries.FirstOrDefaultAsync(delivery => delivery.Id == id);
            if (deliveryToFinish == null)
            {
                throw new ArgumentNullException(nameof(deliveryToFinish));
            }
            var status = this.context.Statuses.FirstOrDefault(statusDb => statusDb.Name == "Completed");
            deliveryToFinish.Status = status;
            this.context.Deliveries.Update(deliveryToFinish);
            var result = await this.context.SaveChangesAsync();
            return result > 0;
        }

        public List<DeliveryViewModel> GetAllDeliveries()
        {
          return  this.context.Deliveries.Select(deliver => new DeliveryViewModel {
              Id=deliver.Id,
              Status=deliver.Status.Name,
              Recipient=deliver.Recipient,
              IssuedById=deliver.IssuedById,
          }).ToList();
            
        }

        public Data.Models.Delivery GetDeliveryById(string id)
        {
            var result = this.context.Deliveries.SingleOrDefault(deliveryDb => deliveryDb.Id == id);
            return result;
        }

        public List<DeliveryOrderTypeViewModel> GetDeliveryTypes()
        {
            return this.context.DeliveryTypes.Select(deliveryType => new DeliveryOrderTypeViewModel
            {
                Name = deliveryType.Name,
            }).ToList();
        }

        public async Task<bool> ShipDelivery(string id)
        {
            var deliveryToShip = await this.context.Deliveries.FirstOrDefaultAsync(delivery => delivery.Id == id);
            if (deliveryToShip == null)
            {
                throw new ArgumentNullException(nameof(deliveryToShip));
            }

            var status = this.context.Statuses.FirstOrDefault(statusDb => statusDb.Name == "Shipped");
            deliveryToShip.Status = status;
            this.context.Deliveries.Update(deliveryToShip);
            var result = await this.context.SaveChangesAsync();
            return result > 0;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NutriAnimal.Data.Models
{
    public class Delivery
    {
        public string Id { get; set; }

        public decimal Price { get; set; }

        public string RecipientId { get; set; }

        public ApplicationUser Recipient { get; set; }

        public string DeliveryCompanyId { get; set; }

        public DeliveryCompany DeliveryCompany { get; set; }

        public string DeliveryTypeId { get; set; }

        public DeliveryType DeliveryType { get; set; }

        public string OrderId { get; set; }

        public Order Order { get; set; }
    }
}

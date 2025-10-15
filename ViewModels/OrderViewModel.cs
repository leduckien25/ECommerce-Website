﻿using WebApplicationMvc.Models;

namespace WebApplicationMvc.ViewModels
{
    public class OrderViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string? Note { get; set; }
        public string PaymentMethod { get; set; } 
    }
}

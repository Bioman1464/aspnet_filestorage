using System;

namespace OOPASU.Api.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
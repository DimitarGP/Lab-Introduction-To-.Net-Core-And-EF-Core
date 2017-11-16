using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopHierarchy
{
    public class Salesman
    {
        //public Salesman()
        //{
        //    this.Customers = new List<Customer>();
        //}
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.DataContext
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public Product()
        {
            CreatedDate = DateTime.Now;
        }
    }
}

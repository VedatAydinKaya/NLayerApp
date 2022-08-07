using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class ProductFeature
    {
        //public ProductFeature(string color)
        //{
        //    Color=color ?? throw new ArgumentNullException(nameof(Color)); 
        //}

        public int Id { get; set; }
        public string? Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public int ProductId { get; set; } // ForeignKey 1-1 one to one

        public Product? Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.DTO.Product
{
    public class ProductDto
    {
       public  int Id { get; set; }
        public int CategoryId { get; set; }
       public string Category { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public string name { get; set; }
        public string specification { get; set; }
        public double price { get; set; }
    }
}

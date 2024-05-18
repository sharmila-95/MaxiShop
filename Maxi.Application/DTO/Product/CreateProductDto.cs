using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.DTO.Product
{
    public class CreateProductDto
    {
        public int CategoryId { get; set; }

        public int BrandId { get; set; }
        public string name { get; set; }
        public string specification { get; set; }
        public double price { get; set; }
    }
}

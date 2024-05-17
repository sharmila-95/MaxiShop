using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.DTO.Brand
{
    public class BrandDto
    {
        public int Id { get; set; }
       
        public string name { get; set; }
      
        public DateTime EstablishYear { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.DTO.Brand
{
    public class CreateBrandDto
    {
        [Required]
        public string name { get; set; }
        [Required]
        public DateTime EstablishYear { get; set; }
    }
}

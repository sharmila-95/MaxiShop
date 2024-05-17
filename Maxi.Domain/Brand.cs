using Maxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Domain
{
    public class Brand:BaseModel
    {
        [Required]
        public string name {  get; set; }
        [Required]
        public DateTime EstablishYear { get; set; }
    }
}

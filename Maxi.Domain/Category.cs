﻿using Maxi.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Domain
{
    public class Category:BaseModel
    {
          
            [Required]
            public string Name { get; set; }
        
    }
}

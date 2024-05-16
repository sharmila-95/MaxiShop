﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Domain.Common
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}

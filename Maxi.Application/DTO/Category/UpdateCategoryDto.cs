﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.DTO.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}

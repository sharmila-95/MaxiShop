using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.DTO.Brand
{
    public class CreateBrandDto
    {
       
        public string name { get; set; }
       
        public DateTime EstablishYear { get; set; }
    }
    public class CreateBrandDtoValidator:AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator()
        {
            RuleFor(x=>x.name).NotNull().NotEmpty();
            RuleFor(x=>x.EstablishYear).NotNull().NotEmpty();
        }
    }
}

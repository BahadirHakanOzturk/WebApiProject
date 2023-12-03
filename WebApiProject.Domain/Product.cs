using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Domain.Common;

namespace WebApiProject.Domain;

public class Product : BaseEntity
{
    [Required, MaxLength(64)]
    public string Name { get; set; } = default!;
    public double Price { get; set; }
}

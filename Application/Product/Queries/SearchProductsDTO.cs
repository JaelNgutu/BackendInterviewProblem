using Application.Product.Enums;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Product.Queries;

public sealed record SearchProductsDTO
{
    public string? Name { get; set; }

    public string? Category { get; set; }
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; }

    public SortOrder SortOrder { get; set; }
   
}

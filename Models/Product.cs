using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace learn_asp_net.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
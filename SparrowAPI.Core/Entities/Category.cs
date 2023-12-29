using Ardalis.Specification;
using SparrowAPI.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Core.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}

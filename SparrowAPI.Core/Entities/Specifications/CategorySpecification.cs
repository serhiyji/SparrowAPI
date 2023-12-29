﻿using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SparrowAPI.Core.Entities.Specifications
{
    public class CategorySpecification
    {
        public class GetByName : Specification<Category>
        {
            public GetByName(string name)
            {
                Query.Where(x => x.Name == name);
            }
        }
    }
}
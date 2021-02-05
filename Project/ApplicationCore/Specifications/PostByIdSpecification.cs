using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Specifications
{
    public class PostByIdSpecification : Specification<Post>
    {
        public PostByIdSpecification(int id)
        {
            Query.Where(o => o.Id == id);
        }
    }
}

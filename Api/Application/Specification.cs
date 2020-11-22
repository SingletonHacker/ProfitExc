using System;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Application
{
    public class Specification : ISpecification<Core.Entities.Gemeente>
    {
        public Expression<Func<Core.Entities.Gemeente, object>> OrderBy { get; set; }
    }
}

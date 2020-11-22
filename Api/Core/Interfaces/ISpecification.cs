using System;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface ISpecification<T>
    {
        public Expression<Func<T, object>> OrderBy { get; }
    }
}

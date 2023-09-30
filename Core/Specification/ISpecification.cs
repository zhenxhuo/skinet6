using System.Linq.Expressions;
using System.Collections.Generic;

namespace Core.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria {get;}
        List<Expression<Func<T, object>>> Include {get;}
    

    }
}
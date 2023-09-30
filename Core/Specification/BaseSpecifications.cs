using System.Linq.Expressions;

namespace Core.Specification
{
    public class BaseSpecifications<T> : ISpecification<T>
    {
        public BaseSpecifications()
        {
        }

        public BaseSpecifications( Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }


        public Expression<Func<T, bool>> Criteria {get; }

        public List<Expression<Func<T, object>>> Include {get;} = 
                new List<Expression<Func<T, object>>>();

        protected void AddInclude (Expression<Func<T,object>> includeExpression)
        {
                Include.Add(includeExpression);
        }

    }
}
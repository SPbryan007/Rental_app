using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    interface IFilter<T>
    {
        public IEnumerable<T> FilterBy(IEnumerable<T> items, ISpecification<T> spec);
    }
    class Filter<T> : IFilter<T>
    {
        public virtual IEnumerable<T> FilterBy(IEnumerable<T> items, ISpecification<T> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                    yield return i;
            }
        }
    }
}

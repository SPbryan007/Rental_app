using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
   
    abstract class RentalPriceSpecification : ISpecification<Rental>
    {
        private double _price;
        protected RentalPriceSpecification(double price)
        {
            this._price = price;
        }
        public double Price { get => _price; set => _price = value; }

        public abstract bool IsSatisfied(Rental obj);
    }

    class RentalPriceHigherThan: RentalPriceSpecification
    {
        public RentalPriceHigherThan(double criteria) : base(criteria) { }
        public override bool IsSatisfied(Rental obj)
        {
            return obj.calculate() >= base.Price;
        }
    }

    class RentalPriceLowerThan : RentalPriceSpecification
    {
        public RentalPriceLowerThan(double criteria) : base(criteria){}
        public override bool IsSatisfied(Rental obj)
        {
            return obj.calculate() <= base.Price;
        }
    }

    class RentalPriceEqualsTo : RentalPriceSpecification
    {
        public RentalPriceEqualsTo(double criteria) : base(criteria) { }
        public override bool IsSatisfied(Rental obj)
        {
            return obj.calculate() == base.Price;
        }
    }

    abstract class RentalTimeSpecification : ISpecification<Rental>
    {
        private readonly DateTime _criteria;
        protected RentalTimeSpecification(DateTime criteria)
        {
            this._criteria = criteria;
        }

        public DateTime Criteria => _criteria;
        public abstract bool IsSatisfied(Rental obj);
    }
    
    class RentalTimeOlderThan : RentalTimeSpecification
    {
        public RentalTimeOlderThan(DateTime criteria) : base(criteria) { }
        public override bool IsSatisfied(Rental obj)
        {
            return obj.Rentaltime.Start_date > base.Criteria;
        }
    }

    class RentalTimeNewerThan : RentalTimeSpecification
    {
        public RentalTimeNewerThan(DateTime criteria) : base(criteria) { }
        public override bool IsSatisfied(Rental obj)
        {
            return obj.Rentaltime.Start_date < base.Criteria;
        }
    }

    class RentalTimeEqualsTo : RentalTimeSpecification
    {
        public RentalTimeEqualsTo(DateTime criteria) : base(criteria) { }
        public override bool IsSatisfied(Rental obj)
        {
            return DateTime.Equals(obj.Rentaltime.Start_date, base.Criteria);
        }
    }

    class AndSpecification<T> : ISpecification<T>
    {
        private ISpecification<T> _first, _second;
        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            _first = first ?? throw new ArgumentNullException(paramName: nameof(first));
            _second = second ?? throw new ArgumentNullException(paramName: nameof(second));
        }
        public bool IsSatisfied(T obj)
        {
            return _first.IsSatisfied(obj) && _second.IsSatisfied(obj);
        }
    }
}

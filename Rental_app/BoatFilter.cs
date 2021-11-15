using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
  
    abstract class BoatLengthSpecification : ISpecification<Boat>
    {
        private readonly double _criteria;
        public BoatLengthSpecification(double criteria){ _criteria = criteria; }
        public double Criteria => _criteria;
        public abstract bool IsSatisfied(Boat obj);
    }

    class BoatLenghtHigherThan : BoatLengthSpecification
    {
        public BoatLenghtHigherThan(double criteria) : base(criteria){}
        public override bool IsSatisfied(Boat obj)
        {
            return obj.Length > base.Criteria;
        }
    }

    class BoatLenghtLowerThan : BoatLengthSpecification
    {
        public BoatLenghtLowerThan(double criteria) : base(criteria) { }
        public override bool IsSatisfied(Boat obj)
        {
            return obj.Length < base.Criteria;
        }
    }

    class BoatLenghtEqualsTo: BoatLengthSpecification
    {
        public BoatLenghtEqualsTo(double criteria) : base(criteria) { }
        public override bool IsSatisfied(Boat obj)
        {
            return obj.Length == base.Criteria;
        }
    }
    

    class BoatColorSpecification : ISpecification<Boat>
    {
        private readonly Color _criteria;
        public BoatColorSpecification(Color criteria){ _criteria = criteria; }
        public Color Criteria => _criteria;
        public bool IsSatisfied(Boat obj)
        {
            return obj.Color == _criteria;
        }
    }

   


}

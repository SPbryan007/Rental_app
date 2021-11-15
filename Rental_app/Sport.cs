using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    class Sport : Boat
    {
        private double _power;
        public Sport(string plate, Color color, double length, string year, double power)
            : base(plate, color, length, year)
        {
            this._power = power;
        }

        public double Power { get => _power; set => _power = value; }

        public override double module()
        {
            return this.base_module() + this._power;
        }
    }
}

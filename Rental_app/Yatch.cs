using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    class Yatch : Boat
    {
        private int _cabins;
        private double _power;
        public Yatch(string plate, Color color, double length, string year, int cabins, double power)
            : base(plate, color, length, year)
        {
            this._cabins = cabins;
            this._power = power;
        }

        public int Cabins { get => _cabins; set => _cabins = value; }
        public double Power { get => _power; set => _power = value; }

        public override double module()
        {
            return this.base_module() + this._power + this._cabins;
        }
    }
}

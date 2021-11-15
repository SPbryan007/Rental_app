using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    class Sailboat : Boat
    {
        private int _masts;
        public Sailboat(string plate, Color color, double length, string year, int masts)
            : base(plate, color, length, year)
        {
            this._masts = masts;
        }
        public int Masts { get => _masts; set => _masts = value; }

        public override double module()
        {
            return this.base_module() + this._masts;
        }
    }
}

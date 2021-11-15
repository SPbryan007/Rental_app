using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    class Rental
    {
        private Rentaltime _rentaltime;
        private double _base_price;
        private Boat _boat;
        private Customer _customer;

        public Rental(double base_price, Boat boat, Customer customer,DateTime start_date, DateTime end_date)
        {
            this._rentaltime = new Rentaltime(start_date, end_date);
            this._boat = boat;
            this._customer = customer;
            this._base_price = base_price;
        }

        public double Base_price { get => _base_price; set => _base_price = value; }
        internal Rentaltime Rentaltime { get => _rentaltime; set => _rentaltime = value; }
        internal Boat Boat { get => _boat; set => _boat = value; }
        internal Customer Customer { get => _customer; set => _customer = value; }

        public double calculate()
        {
            return this._rentaltime.getTotalDays() * this._boat.module() * this._base_price;
        }
    }
}

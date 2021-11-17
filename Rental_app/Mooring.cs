using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    class Mooring
    {
        private List<Rental> _rentals;
        private string _position;
        private double _rental_price;
        public Mooring(string position, double rental_price)
        {
            _rentals = new List<Rental>();
            this._position = position;
            this._rental_price= rental_price;
        }
        public string Position { get => _position; set => _position = value; }
        public double Rental_price { get => _rental_price; set => _rental_price = value; }
        internal List<Rental> Rentals { get => _rentals; set => _rentals = value; }

        public void addRental(Rental rent)
        {
            this._rentals.Add(rent);
        }

        public double getTotalRents()
        {
            double total = 0;
            this._rentals.ForEach(item => { total += item.calculate(); });
            return total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    class Port
    {
        private List<Mooring> _moorings = new List<Mooring>();
        private double _base_price;
        private string _name;

        public Port(string name, double base_price)
        {
            this._name = name;
            this._base_price = base_price;
        }

        public double Base_price { get => _base_price; set => _base_price = value; }
        public string Name { get => _name; set => _name = value; }
        internal List<Mooring> Moorings { get => _moorings; set => _moorings = value; }
    
        public void addMooring(Mooring mooring)
        {
            this._moorings.Add(mooring);
        }
        public double getTotalRents()
        {
            double total = 0;
            this._moorings.ForEach( item => { total += item.getTotalRents(); });
            return total;
        }
    }
}

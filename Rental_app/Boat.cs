using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    enum Color
    {
        Red,
        Blue,
        Black
    }
    abstract class Boat
    {
        private string _plate;
        private Color _color;
        private double _length;
        private string _year;

        
        public Boat(string plate, Color color, double length, string year)
        {
            this._plate     = plate;
            this._color     = color;
            this._length    = length;
            this._year      = year;
        }

        public string Plate { get => _plate; set => _plate = value; }
        public double Length { get => _length; set => _length = value; }
        public string Year { get => _year; set => _year = value; }
        internal Color Color { get => _color; set => _color = value; }

        public virtual double base_module()
        {
            return 10 * this._length;
        }
        public abstract double module();
    }
}

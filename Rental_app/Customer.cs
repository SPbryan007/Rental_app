using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    class Customer
    {
        private string _fullname;
        private string _ci;
        public Customer(string fullname, string ci)
        {
            this._fullname = fullname;
            this._ci = ci;
        }

        public string Fullname { get => _fullname; set => _fullname = value; }
        public string Ci { get => _ci; set => _ci = value; }
    }
}

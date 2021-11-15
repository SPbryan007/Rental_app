using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    class Business
    {
        private List<Port> _ports = new List<Port>();
        private string _nit;
        private string _name;
        public Business(string nit, string name)
        {
            _nit = nit;
            _name = name;
        }

        public string Nit { get => _nit; set => _nit = value; }
        public string Name { get => _name; set => _name = value; }
        internal List<Port> Ports { get => _ports; set => _ports = value; }
    
        public void addPort(Port port)
        {
            this._ports.Add(port);
        }
    }
}

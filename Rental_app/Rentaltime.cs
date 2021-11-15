using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_app
{
    class Rentaltime
    {
        private DateTime _start_date, _end_date;
        public Rentaltime(DateTime start_date, DateTime end_date)
        {
            if (start_date > end_date)
                throw new Exception("Dates not valid");
            this._start_date = start_date;
            this._end_date = end_date;
        }

        public DateTime Start_date { get => _start_date; set => _start_date = value; }
        public DateTime End_date { get => _end_date; set => _end_date = value; }
    
        public int getTotalDays()
        {
            return (this._end_date - this._start_date).Days + 1;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Rental_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Business b1 = new Business("11001215", "GlobalPorts srl");
            Port port1 = new Port("Singapur Port", 12);

            Mooring moo1 = new Mooring("Left", port1.Base_price);
            Mooring moo2 = new Mooring("right", port1.Base_price);

            port1.addMooring(moo1);
            port1.addMooring(moo2);

            //Port port2 = new Port("Iquique Port", 12);

            //b1.addPort(port1);
            //b1.addPort(port2);

            Customer customer = new Customer("John wick", "3528412");
            Boat boat = new Sailboat("XSDD4522",Color.Black, 15.8,"1995", 4);
            Rental rent = new Rental(port1.Base_price, boat, customer, new DateTime(2021, 11, 10), new DateTime(2021, 11, 15));

            Customer customer2 = new Customer("Juan Perez", "5492151");
            Boat boat2 = new Sport("XSDD4522", Color.Blue, 8, "2005", 800);
            Rental rent2 = new Rental(port1.Base_price, boat2, customer2, new DateTime(2021, 11, 16), new DateTime(2021, 11, 30));

            moo1.addRental(rent);
            moo1.addRental(rent2);

            Console.WriteLine(
                $"Alquiler 1: \n" +
                $"Fecha inicio : {rent.Rentaltime.Start_date}\n" +
                $"Precio de alquiler: {rent.calculate()} $us \n" +
                $"Matricula :  { rent.Boat.Plate }  \n" +
                $"Color: {rent.Boat.Color }\n" +
                $"Eslora: {rent.Boat.Length }\n" +
                $"Cliente : { rent.Customer.Fullname }"
            );

            Console.WriteLine(
                $"Alquiler 2: \n" +
                $"Fecha inicio : {rent2.Rentaltime.Start_date}\n" +
                $"Precio de alquiler: {rent2.calculate()} $us \n" +
                $"Color: {rent2.Boat.Color }\n" +
                $"Eslora: {rent2.Boat.Length }\n" +
                $"Matricula :  { rent2.Boat.Plate }  \n" +
                $"Cliente : { rent2.Customer.Fullname }"
            );

            Console.WriteLine($"\n total ganancias : {port1.getTotalRents()}");
            List<Rental> port_rents = new List<Rental>();
            port1.Moorings.ForEach(i =>
            {
                foreach (var item in i.Rentals)
                {
                    port_rents.Add(item);
                }
            });

            Filter<Rental> rf = new Filter<Rental>();
            foreach (var r in rf.FilterBy(port_rents, new RentalPriceHigherThan(30000) ))
            {
                Console.WriteLine($"\n price : {r.calculate()}");
            }

            foreach (var r in rf.FilterBy(moo1.Rentals,
                new AndSpecification<Rental>(
                    new RentalTimeOlderThan(new DateTime(2021, 11, 5)),
                    new RentalTimeNewerThan(new DateTime(2021, 11, 14)))
             ))
            {
                Console.WriteLine($"\n" +
                    $"Fecha inicio: {r.Rentaltime.Start_date} \n" +
                     $"Alquiler 2: \n" +
                     $"Precio de alquiler: {r.calculate()} $us \n" +
                     $"Matricula :  { r.Boat.Plate }  \n" +
                     $"Cliente : { r.Customer.Fullname }");
            }

            Console.WriteLine("\n Search Rental Filter results\n");

            foreach (var r in rf.FilterBy(moo1.Rentals,
                new AndSpecification<Rental>(
                    new RentalTimeNewerThan(new DateTime(2021, 11, 14)),
                    new RentalPriceHigherThan(10000)
                )
             ))
            {
                Console.WriteLine(
                     $"\nFecha inicio : {r.Rentaltime.Start_date} \n" +
                     $"Precio de alquiler: {r.calculate()} $us \n" +
                     $"Matricula :  { r.Boat.Plate }  \n" +
                     $"Cliente : { r.Customer.Fullname }");
            }



            Console.WriteLine("\n Search Boat Filter results\n");
            List<Boat> boats = new List<Boat>();
            moo1.Rentals.ForEach(i => { boats.Add(i.Boat); });

            Filter<Boat> bf = new Filter<Boat>();
            foreach (var b in bf.FilterBy(boats,new BoatLenghtEqualsTo(8)))
            {
                Console.WriteLine(
                     $"\nEslora : {b.Length} \n" +
                     $"Matricula: {b.Plate} $us \n" +
                     $"Color :  { b.Color }  \n");
            }
        }
    }
}

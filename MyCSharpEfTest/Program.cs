using System;
using Microsoft.EntityFrameworkCore;

namespace com.mynamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new sampledbContext())
            {
                //Add a new entrie to the database
                db.Employees.Add(new Employees { Firstname = "Daenerys", Lastname = "Targaryen", Birthdate = DateTime.Parse("01/01/2000") });
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                //Read entire Employees table including its addressess 
                var Employees = db.Employees.Include(x => x.Addresses);

                Console.WriteLine("\nAll employees in database:\n");
                foreach (var employee in Employees)
                {
                    Console.WriteLine($"{employee.Idemployees} - {employee.Firstname} {employee.Lastname}: {employee.Birthdate}");

                    foreach (var address in employee.Addresses)
                    {
                        Console.WriteLine($"\t{address.Idaddresses} - {address.Number} - {address.Street} - {address.City} - {address.State} - {address.Country}");
                    }
                }
            }
        }
    }
}

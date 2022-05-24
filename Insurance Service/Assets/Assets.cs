using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Service.Assets
{
    public class Assets
    {
        public static int Price = 2000;
        public static int maxPrice = 100000;
        public static int procent = 1;
        public class Client
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }
            public DateTime BirthDay { get; set; }
            public string Number { get; set; }
            public string City { get; set; }
            public string Passport { get; set; }
            public string Login { get; set; }

        }
        public class CarClient
        {
            public int id { get; set; }
            public string StateNumber { get; set; }
            public string VIN { get; set; }
            public Client Client { get; set; }
            public string Color { get; set; }
            public Car car { get; set; }
 
        }
        public class Car
        {
            public int id { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
        }
        
    }
    
}

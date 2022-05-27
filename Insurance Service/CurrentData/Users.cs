using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Service.CurrentData
{
    public class Users
    {
        public Users(int id, string name, string lastname, string fullname, string birthday, string number, string city, string passport, string password, string login, int role)
        {
            Id = id;
            Name = name;
            LastName = lastname;
            FullName = fullname;
            BirthDay = birthday;
            Number = number;
            City = city;
            Passport = passport;
            Password = password;
            Login = login;
            Usrerole = role;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Number { get; set; }
        public string BirthDay { get; set; }
        public string City { get; set; }
        public string Passport { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public int Usrerole { get; set; }

    }
}

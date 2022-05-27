using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Service.CurrentData
{
    public class Users
    {
        public Users(int id, string name, string lastname, string number, int role)
        {
            Id = id;
            Name = name;
            LastName = lastname;
            Number = number;
            Usrerole = role;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public int Usrerole { get; set; }

    }
}

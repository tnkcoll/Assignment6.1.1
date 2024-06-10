using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6._1._1.Controls.Classes
{
    internal class House
    {
        public int Number { get; set; }
        public string? Address { get; set; }
        public string? Type { get; set; }


        public House(int number, string? address, string? type)
        {
            Number = number;
            Address = address;
            Type = type;
        }
    }
}

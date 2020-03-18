using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Room
    {
        public int Number { get; set; }
        public int Capacity { get; set;  } // number of beds, either 4,6,8,12 or 16
        public bool Type { get; set; } // student = false, teacher = true

        public Room(int number, int capacity, bool type) //wederom een constructor hier
        {
            this.Number = number;
            this.Capacity = capacity;
            this.Type = type;
        }

        public string RoomToString()
        {
            if (Type == false)
            {
                return $"Kamer {Number} met {Capacity} slaapplaatsen is bedoeld voor studenten";
            }
            else if (Type == true)
            {
                return $"Kamer {Number} met {Capacity} slaapplaatsen is bedoeld voor docenten";
            }

            return $"Roomnumber: {Number} with a total capacity of: {Capacity} is to be occupied by: {Type}";
        }

    }
}

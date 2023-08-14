using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    public class Move
    {
        private int Id { get; set; }
        private String Name { get; set; }
        private String Description { get; set; }
        private float SweatRate { get; set; }

        public Move(int id, string name, string description, int sweatRate)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.SweatRate = sweatRate;
        }

        public override string? ToString()
        {
            return Id + ": " + Name;
        }

        public string? ToStringWhole()
        {
            return Id + ": " + Name + "sweat rate:" + SweatRate + "\n" + Description;
        }
    }
}

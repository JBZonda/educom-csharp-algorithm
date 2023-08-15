namespace BornToMove.DAL
{
    public class Move
    {
        public int Id { get; init; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int SweatRate { get; set; }

        public Move(int id, string name, string description, int sweatRate)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.SweatRate = sweatRate;
        }

        public Move() {
            this.Id = 0;
            this.Name = "";
            this.Description = "";
            this.SweatRate = 0;
        }

        public override string? ToString()
        {
            return Id + ": " + Name + "         sweat rate:" + SweatRate;
        }

        public string? ToStringWhole()
        {
            return Id + ": " + Name + "         sweat rate:" + SweatRate + "\n" + Description;
        }
    }
}

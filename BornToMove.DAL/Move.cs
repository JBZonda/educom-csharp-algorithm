using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BornToMove.DAL
{
    public class Move
    {
        public int Id { get; init; }
        public String Name { get; set; }
        public String Description { get; set; }
        virtual public ICollection<MoveRating> Ratings { get; set; }

        public Move(int id, string name, string description, int sweatRate)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Ratings = new List<MoveRating>();
        }

        public Move() {
            this.Id = 0;
            this.Name = "";
            this.Description = "";
        }

        public double getAvgRating()
        {
            return Math.Round(Ratings.Select(r => r.Rating).Average(x => x), 2);
        }

        public double getAvgVote()
        {
            return Math.Round((double)Ratings.Select(r => r.Vote).Average(x => x), 2);

        }

        public override string? ToString()
        {
            return Id + ": " + Name + "         sweat rate:" + getAvgRating() + "  rating: " + getAvgVote();
        }

        public string? ToStringWhole()
        {
            return Id + ": " + Name + "         sweat rate:" + getAvgRating() + "  rating: "+ getAvgVote()  +"\n" + Description;
        }
    }
}

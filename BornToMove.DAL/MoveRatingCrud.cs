using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class MoveRatingCrud
    {
        private MoveContext context;
       

        public MoveRatingCrud(MoveContext context)
        {
            this.context = context;
        }

        public MoveRating create(MoveRating rating)
        {
            context.MoveRating.Add(rating);
            context.SaveChanges();
            return rating;
        }

        public void delete(MoveRating rating)
        {
            context.MoveRating.Remove(rating);
            context.SaveChanges();
        }
        public void update(MoveRating rating)
        {
            context.MoveRating.Update(rating);
            context.SaveChanges();
        }
    }
}

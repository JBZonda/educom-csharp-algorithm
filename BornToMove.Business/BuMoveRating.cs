using BornToMove.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.Business
{
    public class BuMoveRating
    {
        MoveRatingCrud crud;
 

        public BuMoveRating(MoveContext context)
        {
            this.crud = new MoveRatingCrud(context);
        }

        public MoveRating saveRating(MoveRating rating)
        {
            crud.create(rating);
            return rating;
        }

    }
}

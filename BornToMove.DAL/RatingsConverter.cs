using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class RatingsConverter : IComparer<MoveRating>
    {
        public int Compare(MoveRating? x, MoveRating? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            if (x.Vote == null && y.Vote == null) return 0;
            if (x.Vote == null) return -1;
            if (y.Vote == null) return 1;
            return Comparer<double>.Default.Compare((double)y.Vote, (double)(x.Vote));
        }
    }
}

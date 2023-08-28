using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class MoveCrud
    {
        private MoveContext context = new MoveContext();

        public Move create(Move move)
        {
            context.Move.Add(move);
            context.SaveChanges();
            return move;
        }

        public void delete(Move move) { 
            context.Move.Remove(move);
            context.SaveChanges();
        }
        public void update(Move move) {
            context.Move.Update(move); 
            context.SaveChanges();    
        }

        public Move? readMovesById(int id) {
            return context.Move.Find(id);
        
        }

        public Move? readMovesByName(String name)
        {
            return (Move?) context.Move.Where(b => b.Name == name);

        }

        public List<Move> readAllMoves() { 
            return context.Move.ToList();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BornToMove.DAL;
namespace BornToMove
{
    public class BuMove
    {

        MoveCrud moveCrud = new MoveCrud();

        public void WriteSugestions()
        {
            List<Move> moves = moveCrud.readAllMoves();
            var random = new Random();
            Console.WriteLine(moves[random.Next(moves.Count)].ToStringWhole());
        }

        public void WriteList() {

            List<Move> moves = moveCrud.readAllMoves();
            
            foreach (Move move in moves)
            {
                Console.WriteLine(move.ToString());
            }
            
        }

        public void WriteMoveById(int id)
        {
            Move selectedMove = moveCrud.readMovesById(id);
            Console.WriteLine(selectedMove.ToStringWhole());
        }
        public Move? getMoveByName(String name)
        {  
            return moveCrud.readMovesByName(name);
        }

        public void SaveMove(Move move){
            moveCrud.create(move);
        }

    }
}

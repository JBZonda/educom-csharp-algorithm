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

        MoveCrud moveCrud;

        public BuMove (MoveContext context)
        {
            this.moveCrud = new MoveCrud(context);
        }

        public Move WriteSugestions()
        {
            List<Move> moves = moveCrud.readAllMoves();
            var random = new Random();
            Move pickedMove = moves[random.Next(moves.Count)];
            Console.WriteLine(pickedMove.ToStringWhole());
            return pickedMove;
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

        public Move SaveMove(Move move){
            return moveCrud.create(move);
        }

        public bool dataExists()
        {
            return moveCrud.readAllMoves().Count() != 0;
        }

        public Move? getMoveById(int id)
        {
            return moveCrud.readMovesById(id);
        }
    }
}

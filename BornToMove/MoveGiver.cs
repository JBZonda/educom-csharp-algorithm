using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class MoveGiver
    {

        DatabaseConect database = new DatabaseConect();

        public void WriteSugestions()
        {
            List<Move> moves = database.OpenSqlWithComand("SELECT * FROM Move;");
            var random = new Random();
            Console.WriteLine(moves[random.Next(moves.Count)].ToStringWhole());
        }

        public void WriteList() {

            List<Move> moves = database.OpenSqlWithComand("SELECT * FROM Move;");
            
            foreach (Move move in moves)
            {
                Console.WriteLine(move.ToString());
            }
            Console.WriteLine("Geef het nummer van uw gekozen beweging:");
            int chosenMoveId = Convert.ToInt32(Console.ReadLine());
            if (chosenMoveId > 0)
            {
                moves[chosenMoveId].ToStringWhole();
            }
            else
            {
                // make new
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BornToMove.DAL;
namespace BornToMove
{
    internal class MoveGiver
    {

        DatabaseConect database = new DatabaseConect();

        public void WriteSugestions()
        {
            List<Move> moves = database.GetMoveWithSqlComand("SELECT * FROM Move;");
            var random = new Random();
            Console.WriteLine(moves[random.Next(moves.Count)].ToStringWhole());
        }

        public void WriteList() {

            List<Move> moves = database.GetMoveWithSqlComand("SELECT * FROM Move;");
            
            foreach (Move move in moves)
            {
                Console.WriteLine(move.ToString());
            }
            
        }

        public void WriteMoveById(int id)
        {
            List<Move> selectedMove = database.GetMoveWithSqlComand("SELECT * FROM Move WHERE id = '" + id + "';");
            Console.WriteLine(selectedMove[0].ToStringWhole());
        }
        public Move? getMoveByName(String name)
        {
            List<Move> selectedMove = database.GetMoveWithSqlComand("SELECT * FROM Move WHERE name = '" + name + "';");
            return selectedMove.Count == 0 ? null : selectedMove[0];
        }

        public void SaveMove(Move move){

            database.SaveWithSqlComand("INSERT  INTO Move(name,description,sweatRate) VALUES ('" +
                move.Name + "','" + move.Description + "','" + move.SweatRate +  "');");

        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    internal class DatabaseConect
    {
        public List<Move> OpenSqlWithComand(String sql)
        {
            string connectionString = GetConnectionString();
            List<Move> moves = new List<Move>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
    
                connection.Open();
                
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {     
                    Move newMove = new Move((int)dataReader.GetValue(0) , (String) dataReader.GetValue(1),
                        (String) dataReader.GetValue(2), (int) dataReader.GetValue(3));
                    moves.Add(newMove);
                }            
            }
            return moves;

        }

        static private string GetConnectionString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BornToMove;"
                + "Integrated Security=true;";
        }





    }
}

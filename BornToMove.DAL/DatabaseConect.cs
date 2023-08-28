using BornToMove.DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove
{
    public class DatabaseConect
    {
        public List<Move> GetMoveWithSqlComand(String sql)
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

        public void SaveWithSqlComand(String sql)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
        }


        static private string GetConnectionString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BornToMove;"
                + "Integrated Security=true;";
        }





    }
}

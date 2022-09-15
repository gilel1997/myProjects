using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace ChassForm.Objects
{
    public class DBHender
    {
        public List<Peace> GetPeaces(int num)
        {
            string query;
            List<Peace> peaces = new List<Peace>();
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=chess;UID=root;PASSWORD=12345;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            if(num == 0)
            {
                query = "SELECT * FROM chess.savethestate;";
            }
            else if (num <= 3)
            {
                query = "SELECT * FROM chess.opening" + num + ";";
            }
            else if(num >= 4 && num <= 6)
            {
                query = "SELECT * FROM chess.ending" + num + ";";
            }
            else
            {
                query = "DELETE FROM chess.savethestate where id = + " + num + ";";
            }
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader["location_x"] != null && reader["location_y"] != null)
                {
                    Peace peace = new Peace();
                    peace.Id = (int)reader["id"];
                    peace.name = (string)reader["name_of_peace"];
                    peace.locationX = (int)reader["location_x"];
                    peace.locationY = (int)reader["location_y"];
                    peace.color = (string)reader["color"];
                    peace.picture = (string)reader["picture"];
                    peace.picture = peace.picture.Replace(@"\\", @"\");
                    peaces.Add(peace);
                }
                else
                {
                    Peace peace = new Peace();
                    peace.Id = (int)reader["id"];
                    peace.name = (string)reader["name_of_peace"];
                    peace.locationX = -1;
                    peace.locationY = -1;
                    peace.color = (string)reader["color"];
                    peace.picture = (string)reader["picture"];
                    peace.picture = peace.picture.Replace(@"\\", @"\");

                    peaces.Add(peace);
                }
            }
            return peaces;
        }
    }
}

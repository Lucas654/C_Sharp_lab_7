using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_lab_7
{
    class connect
    {
        string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucaa\\source\\repos\\C_Sharp_lab_7\\C_Sharp_lab_7\\students.mdf;Integrated Security=True";

        public void Add(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine(number);
            }
            
        }
       
    }
}

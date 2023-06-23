using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_lab_7
{
    public partial class addLink : Form
    {
        Dictionary<string, int> students = new Dictionary<string, int>();
        Dictionary<string, int> groups = new Dictionary<string, int>();
        public addLink()
        {
            InitializeComponent();
        }

        private void addLink_Load(object sender, EventArgs e)
        {
            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucaa\\source\\repos\\C_Sharp_lab_7\\C_Sharp_lab_7\\students.mdf;Integrated Security=True";

            string student = ("SELECT Id,FirstName,SecondName FROM student");
            string group = ("SELECT Id,Name FROM \"group\"");



            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(student, connection);
                var result = command.ExecuteReader();

                while (result.Read())
                {
                    students.Add(result.GetString(1) + " " + result.GetString(2), result.GetInt32(0));
                }
                result.Close();
                command = new SqlCommand(group, connection);
                result = command.ExecuteReader();
                while (result.Read())
                {
                    groups.Add(result.GetString(1), result.GetInt32(0));
                }
                result.Close();
            }

            foreach (var t in students)
            {
                comboBox1.Items.Add(t.Key);
            }

            foreach (var s in groups)
            {
                comboBox2.Items.Add(s.Key);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            students.TryGetValue(comboBox1.SelectedItem.ToString(), out int IdS);
            groups.TryGetValue(comboBox2.SelectedItem.ToString(), out int IdG);

            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucaa\\source\\repos\\C_Sharp_lab_7\\C_Sharp_lab_7\\students.mdf;Integrated Security=True";

            if (comboBox1.SelectedIndex>-1 && comboBox2.SelectedIndex>-1)
            {
                string sqlExpression = ($"UPDATE student SET group_Id = '{IdG}' WHERE Id='{IdS}'");

                using (SqlConnection connection = new SqlConnection(connectionsString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine(number);
                   

                }
                this.Close();
            }


            
        }
    }
}

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
    public partial class updateForm : Form
    {
        Dictionary<string, int> students = new Dictionary<string, int>();
        Dictionary<string, int> groups = new Dictionary<string, int>();
        public updateForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateS(textBox2.Text,textBox1.Text);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void updateForm_Load(object sender, EventArgs e)
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
                    int id = result.GetInt32(0);
                    string FN = result.GetString(1);
                    string SN = result.GetString(2);


                    students.Add(FN + " " + SN, id);


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

            foreach (var s in students)
            {
                comboBox1.Items.Add(s.Key);
            }
            foreach (var g in groups)
            {
                comboBox2.Items.Add(g.Key);
            }
        }


        public void UpdateS(string FirstName, string SecondName)
        {
            string sqlExpression = "";
            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucaa\\source\\repos\\C_Sharp_lab_7\\C_Sharp_lab_7\\students.mdf;Integrated Security=True";
            students.TryGetValue(comboBox1.SelectedItem.ToString(), out int id);
            if (FirstName == "" && SecondName == "" && comboBox1.SelectedIndex > -1)
            {
                MessageBox.Show("Incorrect data");
            }
            else if (FirstName == "" && SecondName != "" && comboBox1.SelectedIndex > -1)
            {

                sqlExpression = ($"UPDATE student SET SecondName = '{SecondName}' WHERE Id='{id}'");
            }
            else if (FirstName != "" && SecondName == "" && comboBox1.SelectedIndex > -1)
            {
                sqlExpression = ($"UPDATE student SET FirstName = '{FirstName}' WHERE Id='{id}'");
            }
            else
            {
                sqlExpression = ($"UPDATE student SET FirstName = '{FirstName}', SecondName = '{SecondName}' WHERE Id='{id}'");
            }

            if (sqlExpression != "")
                using (SqlConnection connection = new SqlConnection(connectionsString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine(number);
                    this.Close();
                }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlExpression = "";
            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucaa\\source\\repos\\C_Sharp_lab_7\\C_Sharp_lab_7\\students.mdf;Integrated Security=True";
            groups.TryGetValue(comboBox2.SelectedItem.ToString(), out int id);

            if (textBox3.Text == "" && comboBox2.SelectedIndex>-1)
                MessageBox.Show("Incorrect data");
            else
                sqlExpression = $"UPDATE \"group\" SET Name='{textBox3.Text}' WHERE Id = '{id}'";

            if (sqlExpression != "")
                using (SqlConnection connection = new SqlConnection(connectionsString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    Console.WriteLine(number);
                    this.Close();
                }
        }
    }
}

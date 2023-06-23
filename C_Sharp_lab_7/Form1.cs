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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addStudent addStudent = new addStudent();
            addStudent.ShowDialog();
            View();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            View();
        }

        public void View()
        {
            
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            string connectionsString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lucaa\\source\\repos\\C_Sharp_lab_7\\C_Sharp_lab_7\\students.mdf;Integrated Security=True";

            string sqlExpression = "SELECT FirstName,SecondName,Name FROM student JOIN \"group\" ON student.group_Id=\"group\".Id";
            string group = "SELECT Name,Course,Speciality FROM \"group\"";
            string student = "SELECT FirstName,SecondName,birthday FROM student";

            using (SqlConnection connection = new SqlConnection(connectionsString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                var res = command.ExecuteReader();
                List<string[]> data = new List<string[]>();
                while (res.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = res[0].ToString();
                    data[data.Count - 1][1] = res[1].ToString();
                    data[data.Count - 1][2] = res[2].ToString();


                }
                res.Close();
                
                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
                data.Clear();
                command = new SqlCommand(group, connection);
                res = command.ExecuteReader();
                while (res.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = res[0].ToString();
                    data[data.Count - 1][1] = res[1].ToString();
                    data[data.Count - 1][2] = res[2].ToString();
                }
                res.Close();
                
                foreach (string[] s in data)
                    dataGridView2.Rows.Add(s);
                data.Clear();
                command = new SqlCommand(student, connection);
                res = command.ExecuteReader();
                while (res.Read())
                {
                    data.Add(new string[3]);

                    data[data.Count - 1][0] = res[0].ToString();
                    data[data.Count - 1][1] = res[1].ToString();
                    data[data.Count - 1][2] = res[2].ToString();
                }
                res.Close();
                connection.Close();
                foreach (string[] s in data)
                    dataGridView3.Rows.Add(s);
                data.Clear();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addGroup addGroup = new addGroup();
            addGroup.ShowDialog();
            View();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addLink addLink = new addLink();
            addLink.ShowDialog();
            View();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateForm updateForm = new updateForm();
            updateForm.ShowDialog();
            View();
        }
    }
}

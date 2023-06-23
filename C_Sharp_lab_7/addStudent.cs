using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_lab_7
{
    public partial class addStudent : Form
    {
        connect Connect = new connect();
        public addStudent()
        {
            InitializeComponent();
           
        }

        private void addStudent_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            for (int i = 1; i <= 31; i++)
                comboBox1.Items.Add(i);
            for (int i = 1; i <= 12; i++)
                comboBox2.Items.Add(i);
            for (int i = 1980; i <= 2008; i++)
                comboBox3.Items.Add(i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && comboBox1.SelectedIndex > -1 && comboBox2.SelectedIndex > -1 && comboBox3.SelectedIndex > -1)
            {
                /*                DateTime birthday = new DateTime(int.Parse(comboBox3.SelectedItem.ToString()), int.Parse(comboBox2.SelectedItem.ToString()), int.Parse(comboBox1.SelectedItem.ToString()));
                */
                string birthday = comboBox2.SelectedItem.ToString()+"."+ comboBox1.SelectedItem.ToString()+"."+ comboBox3.SelectedItem.ToString();
                string query = $"INSERT INTO student (FirstName,SecondName,birthday) VALUES ('{textBox1.Text}','{textBox2.Text}','{birthday}')";
                Connect.Add(query);
                this.Close();
            }
            else
                MessageBox.Show("Некорректні дані");
        }
    }
}

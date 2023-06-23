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
    public partial class addGroup : Form
    {
        connect Connect = new connect();
        public addGroup()
        {
            InitializeComponent();
        }

        private void addGroup_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 1; i <=4; i++)
                comboBox1.Items.Add(i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && comboBox1.SelectedIndex > -1)
            {
                string query = $"INSERT INTO \"group\" (Name,Course,Speciality) VALUES ('{textBox1.Text}','{comboBox1.SelectedItem.ToString()}','{textBox2.Text}')";
                Connect.Add(query);
                this.Close();

            }
            else
                MessageBox.Show("Некорректі дані");

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace room_reserve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            String query = "SELECT * FROM `user` WHERE `username` = @usn AND `password` =@pass";
            command.CommandText = query;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPass.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            //if username and password exists
            if (table.Rows.Count > 0)
            {
                //show main form
                this.Hide();
                Form2 mForm = new Form2();
                mForm.Show();
            }
            else
            {
                if (textBoxUsername.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your username to Login","Empty Username",MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (textBoxPass.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your password", "Empty passwordmin", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else 
                {
                    MessageBox.Show("this username or password Does not exist", "Wrong Data", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

        }
    }
}

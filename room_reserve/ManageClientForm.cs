using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace room_reserve
{
    public partial class ManageClientForm : Form
    {

        Client client = new Client();

        public ManageClientForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxFirstname.Text = "";
            textBoxLastName.Text = "";
            textBoxCountry.Text = "";
            textBoxPhone.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastName.Text;
            String phone = textBoxPhone.Text;
            String country = textBoxCountry.Text;

            if (fname.Trim().Equals("")||lname.Trim().Equals("")||phone.Trim().Equals(""))
            {
                MessageBox.Show("fill all the required fields", "empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                Boolean insertClient = client.insertClient(fname, lname, phone, country);

                if (insertClient)
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("new client inserted sucessfully", "add client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error - client was not inserted", "add client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }


private void ManageClientForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClients();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id;
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastName.Text;
            String phone = textBoxPhone.Text;
            String country = textBoxCountry.Text;


            try
            { id = Convert.ToInt32(textBoxID.Text);


                if (fname.Trim().Equals("") || lname.Trim().Equals("") || phone.Trim().Equals(""))
                {
                    MessageBox.Show("fill all the required fields", "empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    Boolean insertClient = client.editClient(id, fname, lname, phone, country);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = client.getClients();
                        MessageBox.Show("new client updated sucessfully", "edit client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error - client was not updated", "edit client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }


        //selected client data
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFirstname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLastName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxCountry.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }



        //remove button

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);

                if (client.removeClient(id))
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Client deleted", "delete client", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    button4.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error - client was not deleted", "edit client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}

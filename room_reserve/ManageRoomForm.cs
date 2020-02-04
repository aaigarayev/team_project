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
    public partial class ManageRoomForm : Form
    {
        public ManageRoomForm()
        {
            InitializeComponent();
        }

        Room room = new Room();
        private void ManageRoomForm_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";
            comboBoxRoomType.ValueMember = "category_id";


            dataGridView1.DataSource = room.getRooms();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(textBoxID.Text);
            int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            string phone = textBoxPhone.Text;
            if(room.insertRoom(number, type, phone, "yes"))
            {
                MessageBox.Show("Room added", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Room not added", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dataGridView1.DataSource = room.getRooms();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            String phone = textBoxPhone.Text;
            string free = "";

            try
            {
                int number = Convert.ToInt32(textBoxID.Text);
                if (radioButton1.Checked)
                {
                    free = "Yes";
                }
                else if (radioButton2.Checked)
                {
                    free = "No";
                }

                if (room.editRoom(number, type, phone, free))
                {
                    MessageBox.Show("Room data updated", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Room data not updated", "Edit Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                dataGridView1.DataSource = room.getRooms();
            }
            catch (Exception ex)
            {

            }


            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            comboBoxRoomType.SelectedIndex = 0;
            textBoxPhone.Text = "";
            radioButton1.Checked = true;

        }


        //display selected data
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBoxRoomType.SelectedValue =  dataGridView1.CurrentRow.Cells[1].Value;
            textBoxPhone.Text =  dataGridView1.CurrentRow.Cells[2].Value.ToString();

            string free = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            if (free.Equals("Yes"))
            {
                radioButton1.Checked=true;
            }
            else if (free.Equals("No"))
            {
                radioButton2.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(textBoxID.Text);

            if (room.removeRoom(number))
            {
                MessageBox.Show("room was deleted", "remove room", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("room was not deleted", "remove room", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridView1.DataSource = room.getRooms();
        }
    }
}

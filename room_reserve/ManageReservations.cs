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
    public partial class ManageReservations : Form
    {
        public ManageReservations()
        {
            InitializeComponent();
        }

        Room room = new Room();

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxClientID.Text = "";
            textBoxReservID.Text = "";
            //comboBoxRoomType.SelectedValue = 0;
            dateIN.Value = DateTime.Now;
            dateOut.Value = DateTime.Now;


        }

        private void ManageReservations_Load(object sender, EventArgs e)
        {
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";
            comboBoxRoomType.ValueMember = "category_id";



        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace room_reserve
{
    class Reservation
    {


        Connect conn = new Connect();

        public DataTable getAllReserv()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `reservations`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }


        public bool addReserv(int number, int clientId, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `reservation`(`roomNumber`, `clientid`, `DateIn`, `DateOut`) VALUES (@rnm,@cid,@din,@dout)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            // command.Parameters.Add("INSERT INTO `client`(`first_name`, `last_name`, `phone`, `country`) VALUES (@fnm, @lnm, @phn, @cnt)");
            //@rnm, @cid, @din, @dout
            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateOut;
            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }

            else
            {
                conn.closeConnection();
                return false;
            }

        }

        public bool editReserv(int reservId, int number, int clientId, DateTime dateIn, DateTime dateOut)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE `reservation` SET `roomNumber`=@rnm,`clientid`=@cid,`DateIn`=@din,`DateOut`=@dout WHERE `reservId`=@rvid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            // command.Parameters.Add("INSERT INTO `client`(`first_name`, `last_name`, `phone`, `country`) VALUES (@fnm, @lnm, @phn, @cnt)");

            command.Parameters.Add("@rvid", MySqlDbType.Int32).Value = reservId;
            command.Parameters.Add("@rnm", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = clientId;
            command.Parameters.Add("@din", MySqlDbType.Date).Value = dateIn;
            command.Parameters.Add("@dout", MySqlDbType.Date).Value = dateOut;
            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }

            else
            {
                conn.closeConnection();
                return false;
            }

        }

        public bool removeReserv(int rsv_id)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE FROM `reservations` WHERE `reservId`=@rvid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@rvid", MySqlDbType.Int32).Value = rsv_id;
            conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }

            else
            {
                conn.closeConnection();
                return false;
            }
        }


    }
}

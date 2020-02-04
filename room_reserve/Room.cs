using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace room_reserve
{
    class Room
    {

        Connect conn = new Connect();

        public DataTable roomTypeList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `room_category`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }


        //new room

        public bool insertRoom(int number, int type, String phone, String free)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `rooms`(`number`, `roomType`, `phone`, `free`) VALUES (@num, @tp, @phn, @fr)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            // command.Parameters.Add("INSERT INTO `client`(`first_name`, `last_name`, `phone`, `country`) VALUES (@fnm, @lnm, @phn, @cnt)");
            //@num, @tp, @phn, @fr
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;
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


        //get list of rooms

        public DataTable getRooms()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `rooms`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table;
        }


        //edit room
        public bool editRoom(int number, int type, String phone, String free)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE `rooms` SET `roomType`=@tp,`phone`=@phn,`free`=@fr WHERE `number`=@num";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            // command.Parameters.Add("INSERT INTO `client`(`first_name`, `last_name`, `phone`, `country`) VALUES (@fnm, @lnm, @phn, @cnt)");
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@tp", MySqlDbType.Int32).Value = type;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@fr", MySqlDbType.VarChar).Value = free;
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

        public bool removeRoom(int number)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE FROM `rooms` WHERE `number`=@num";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = number;
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

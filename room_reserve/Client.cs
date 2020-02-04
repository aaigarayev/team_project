using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace room_reserve
{


    //class to add client
    //edit client data remove  get all clients
    class Client
    {

        Connect conn = new Connect();
        //func to insert new client
        public bool insertClient( string fname, string lname, string phone, string country)
        {
            MySqlCommand command = new MySqlCommand();
            string insertQuery = "INSERT INTO `client`(`first_name`, `last_name`, `phone`, `country`) VALUES (@fnm, @lnm, @phn, @cnt)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            // command.Parameters.Add("INSERT INTO `client`(`first_name`, `last_name`, `phone`, `country`) VALUES (@fnm, @lnm, @phn, @cnt)");
            
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;
            conn.openConnection();

            if (command.ExecuteNonQuery()==1)
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



        //get all clients
        public DataTable getClients()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `client`", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);


            return table; 
        }

        //edit client info
        public bool editClient(int id, String fname, String lname, String phone, String country)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE `client` SET `first_name`=@fnm,`last_name`=@lnm,`phone`=@phn,`country`=@cnt WHERE `id`=@cid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            // command.Parameters.Add("INSERT INTO `client`(`first_name`, `last_name`, `phone`, `country`) VALUES (@fnm, @lnm, @phn, @cnt)");
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fnm", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@lnm", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@phn", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cnt", MySqlDbType.VarChar).Value = country;
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

        //feunction to delete client
        public bool removeClient(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE FROM `client` WHERE `id`=@cid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;
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

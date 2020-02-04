using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Infrastructure;
using MySql.Data.MySqlClient;



namespace room_reserve
{

    //connection between app and dataabase
    class Connect
    {

        private MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=hotel_db;");

        //function to return connection
        public MySqlConnection getConnection()
        {
            return connection;
        }


        //открыть коннекшн
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }


    }
}

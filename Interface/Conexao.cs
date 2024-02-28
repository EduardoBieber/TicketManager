using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace TicketManager
{
    internal class Conexao
    {
        string link = "SERVER=localhost; DATABASE=ticketmanager; UID=root; PWD=; PORT=; AllowZeroDateTime=True;";

        public MySqlConnection con = null;

        public void Conectar()
        {
            try
            {
                con = new MySqlConnection(link);
                con.Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void Desconectar()
        {
            try
            {
                con = new MySqlConnection(link);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}


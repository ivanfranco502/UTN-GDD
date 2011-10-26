using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace BoletoElectronicoDesktop
{


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string passwordSHA, query;
            SqlConnection con;
            SqlCommand com;

            passwordSHA = Encriptar.sha256("w32e");
            query = "UPDATE NTVC.USUARIO set PASSWORD = '" + passwordSHA + "' where USERNAME = 'admin'";
            con = Conexion.conectar();
            com = new SqlCommand(query, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login.FormLogin());
        }
    }

 
    public class Conexion
    {
        private static SqlConnection conexion;
        private static string connectionString = "Data Source=localhost\\SQLSERVER2005;Initial Catalog = GD2C2011; User Id=gd;Password=gd2011";

        public static SqlConnection conectar()
        {
            if (conexion == null)
            {
                conexion = new SqlConnection(connectionString);
            }
            return conexion;
        }
    }

    public class Encriptar
    {
        public static string sha256(string entrada)
        {
            SHA256 shaM = new SHA256Managed();
            Byte[] bytesEntrada = System.Text.Encoding.UTF8.GetBytes(entrada);
            Byte[] bytesEncriptados = shaM.ComputeHash(bytesEntrada);
            return BitConverter.ToString(bytesEncriptados);
        }
    }
}

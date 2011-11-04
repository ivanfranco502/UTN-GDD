using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal());
        }
    }

 
    public class Conexion
    {
        private static SqlConnection conexion;
        private static string connectionString = "Data Source=localhost\\SQLSERVER2005;Initial Catalog = GD2C2011; User Id=gd;Password=gd2011";

        public static SqlConnection conectar()
        {
            //asegura una conexión única a la base de datos
            if (conexion == null)
            {
                conexion = new SqlConnection(connectionString);
            }
            return conexion;
        }
    }

    public class Encriptar
    {
        //recibe la contraseña y la devuelve encriptada
        public static string sha256(string entrada)
        {
            SHA256 shaM = new SHA256Managed();
            Byte[] bytesEntrada = System.Text.Encoding.UTF8.GetBytes(entrada);
            Byte[] bytesEncriptados = shaM.ComputeHash(bytesEntrada);
            return BitConverter.ToString(bytesEncriptados);
        }
    }

    public class FuncionesUtiles
    {
        //dada una consulta y un data grid view, la ejecuta y rellena el mismo
        public static void llenarDataGridView(string query, DataGridView dgv)
        {
            SqlConnection con = Conexion.conectar();
            if (con.State.Equals(System.Data.ConnectionState.Closed))
            {
                con.Open();
            }
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dgv.DataSource = dt;
            con.Close();
        }

        //averigua si el textbox contiene un valor numerico decimal positivo
        public static bool esDecimal(TextBox text)
        {
            decimal salida;
            if (decimal.TryParse(text.Text, out salida))
            {
                if (salida >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //averigua si el textbox contiene un valor numerico
        public static bool esNumerico(TextBox text)
        {
            uint salida;
            if(uint.TryParse(text.Text, out salida))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //analiza si los text boxes son numericos
        public static bool sonNumericos(List<TextBox> boxes)
        {
            bool resultado = true;
            foreach (TextBox box in boxes)
            {
                if (!esNumerico(box))
                {
                    resultado = false;
                }
            }
            return resultado;
        }

        public static bool sonNumericosOVacios(List<TextBox> boxes)
        {
            bool resultado = true;
            foreach (TextBox box in boxes)
            {
                if (!esNumerico(box) && !estaVacio(box))
                {
                    resultado = true;
                }
            }
            return resultado;
        }



        //averigua si el textbox esta vacio o hay contenido
        public static bool estaVacio(TextBox text)
        {
            if (text.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //dada una lista de text box, devuelve si al menos uno esta vacio
        public static bool estanVacios(List<TextBox> boxes)
        {
            bool resultado = false;
            foreach (TextBox box in boxes)
            {
                if (box.Text == "")
                {
                    resultado = true;
                }
            }
            return resultado;
        }

        //llena los tipos de documento posibles
        public static void llenarTipoDoc(ComboBox cb)
        {
            cb.Items.Insert(0, "DNI");
            cb.Items.Insert(1, "LE");
            cb.Items.Insert(2, "LC");
        }

        public static string obtenerTipoDoc(int indice)
        {
            switch (indice)
            {
                case 0:
                    return "DNI";
                case 1:
                    return "LE";
                case 2:
                    return "LC";
                default:
                    return "NTVC";
            }
        }


    }

}

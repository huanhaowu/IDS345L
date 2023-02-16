using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransacciones
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\msi\\OneDrive - INTEC\\INTEC\\Trimestre 7\\Desarrollo de software III\\Laboratorio\\AppTransacciones\\AppTransacciones\\DBTransaccionesmdf.mdf\";Integrated Security=True");
            connection.Open();
            SqlTransaction transaction = null;

            SqlCommand cmd = new SqlCommand($"(nombreSP)", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            transaction = connection.BeginTransaction(); //alguien tiene que recibirlo
            cmd.Transaction = transaction; //relaciono el cmd  con el transaction, para que el cmd sepa de donde sacar informacion

            transaction.Commit();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AplicaciónInfidelidades
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //EJERCICIO #1
            Producto nuevoProducto = new Producto();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("                      REGISTRO DE PRODUCTOS                ");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("");

            Console.WriteLine("Nombre del producto:");
            nuevoProducto.NombreProducto = Console.ReadLine();

            Console.WriteLine("Precio del producto:");
            nuevoProducto.Precio = int.Parse(Console.ReadLine());

            Console.WriteLine("Cantidad de productos");
            nuevoProducto.Cantidad = int.Parse(Console.ReadLine());

            Console.WriteLine("Descripcion del producto:");
            nuevoProducto.Descripcion = Console.ReadLine();

            Console.WriteLine($"\nNUEVO REGISTRO: \n NOMBRE:{nuevoProducto.NombreProducto} \n PRECIO: {nuevoProducto.Precio} \n CANTIDAD: {nuevoProducto.Cantidad} \n DESCRIPCION: {nuevoProducto.Descripcion} ");
            Console.ReadKey();

            Console.Clear();

            //EJERCICIO #2
            while (true)
            {
                Infidelidad nuevaInfidelidad = new Infidelidad();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("                  REGISTRO DE INFIDELIDADES                ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Nombres del afectado:");
                nuevaInfidelidad.NombresAfectado = Console.ReadLine();

                Console.WriteLine("Apellidos del afectado:");
                nuevaInfidelidad.ApellidosAfectado = Console.ReadLine();

                Console.WriteLine("Sexo del afectado:");
                nuevaInfidelidad.SexoAfectado = Console.ReadLine();

                Console.WriteLine("Nombres del infiel:");
                nuevaInfidelidad.NombresInfiel = Console.ReadLine();

                Console.WriteLine("Apellidos del infiel:");
                nuevaInfidelidad.ApellidosInfiel = Console.ReadLine();

                Console.WriteLine("Sexo del infiel:");
                nuevaInfidelidad.SexoInfiel = Console.ReadLine();

                Console.WriteLine("Fecha del evento:");
                nuevaInfidelidad.FechaEvento = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Estado de la pareja:");
                nuevaInfidelidad.EstadoPareja = Console.ReadLine();

                Console.WriteLine("¿Primera Vez?:");
                string respuesta = Console.ReadLine();
                if (respuesta == "si" || respuesta == "Si" || respuesta == "SI")
                {
                    nuevaInfidelidad.EsLaPrimeraVez = true;
                }
                else
                {
                    nuevaInfidelidad.EsLaPrimeraVez = false;
                }

                //Se conecta con la base de datos
                
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionLink"].ConnectionString);
                connection.Open();


                //Imprime el estado de la conexion
                Console.WriteLine(connection.State);

                SqlCommand cmd = new SqlCommand($"InsCliente", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure; //definir el tipo de comando
                cmd.Parameters.AddWithValue("@NombresAfectado", nuevaInfidelidad.NombresAfectado);
                cmd.Parameters.AddWithValue("@ApellidosAfectado", nuevaInfidelidad.ApellidosAfectado);
                cmd.Parameters.AddWithValue("@NombresInfiel", nuevaInfidelidad.NombresInfiel);
                cmd.Parameters.AddWithValue("@ApellidosInfiel", nuevaInfidelidad.ApellidosInfiel);
                cmd.Parameters.AddWithValue("@SexoAfectado", nuevaInfidelidad.SexoAfectado);
                cmd.Parameters.AddWithValue("@SexoInfiel", nuevaInfidelidad.SexoInfiel);
                cmd.Parameters.AddWithValue("@FechaEvento", nuevaInfidelidad.FechaEvento);
                cmd.Parameters.AddWithValue("@EstadoPareja", nuevaInfidelidad.EstadoPareja);
                cmd.Parameters.AddWithValue("@EsLaPrimeraVez", nuevaInfidelidad.EsLaPrimeraVez);
                cmd.ExecuteNonQuery();

            }

        }
    }
}

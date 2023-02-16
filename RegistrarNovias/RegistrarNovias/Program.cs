using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrarNovias
{
    internal class Program
    {
        static bool nuevaPersonaBool = true;
        static void Main(string[] args)
        {

            while (nuevaPersonaBool) //registrar nueva persona
            {
                Persona registroPersona = new Persona();

                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("                   REGISTRO DE PERSONA                     ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("Tipo Documento de la persona");
                registroPersona.TipoDocumento = Console.ReadLine();

                Console.WriteLine("Documento de la persona");
                registroPersona.Documento = Console.ReadLine();

                Console.WriteLine("Nombre de la persona: ");
                registroPersona.Nombres = Console.ReadLine();

                Console.WriteLine("Apellidos de la persona: ");
                registroPersona.Apellidos = Console.ReadLine();

                Console.WriteLine("Fecha de Nacimiento de la persona");
                registroPersona.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Sexo de la persona");
                registroPersona.Sexo = Console.ReadLine();

                Console.WriteLine("Estado de la persona");
                registroPersona.Estado = Console.ReadLine();

                Console.WriteLine("Nacionalida de la persona");
                registroPersona.Nacionalidad = Console.ReadLine();

                Console.WriteLine("Pais de origen de la persona");
                registroPersona.PaisOrigen = Console.ReadLine();

                Console.WriteLine("Cantidad de novias");
                registroPersona.Cantidad = int.Parse(Console.ReadLine());
                int cantidadNovias = registroPersona.Cantidad;

                while (cantidadNovias > 0) //registrar nueva pareja
                {
                    Relacion nuevaRelacion = new Relacion();
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine($"                   REGISTRO DE PAREJA {cantidadNovias}                      ");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("");

                    Console.WriteLine("Tipo Documento de la pareja");
                    nuevaRelacion.TipoDocumento = Console.ReadLine();

                    Console.WriteLine("Documento de la pareja");
                    nuevaRelacion.Documento = Console.ReadLine();

                    Console.WriteLine("Nombre de la pareja: ");
                    nuevaRelacion.Nombres = Console.ReadLine();

                    Console.WriteLine("Apellidos de la pareja: ");
                    nuevaRelacion.Apellidos = Console.ReadLine();

                    Console.WriteLine("Fecha de Nacimiento de la pareja");
                    nuevaRelacion.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Sexo de la pareja");
                    nuevaRelacion.Sexo = Console.ReadLine();

                    Console.WriteLine("Estado de la pareja");
                    nuevaRelacion.Estado = Console.ReadLine();

                    Console.WriteLine("Nacionalida de la pareja");
                    nuevaRelacion.Nacionalidad = Console.ReadLine();

                    Console.WriteLine("Pais de origen de la pareja");
                    nuevaRelacion.PaisOrigen = Console.ReadLine();

                    SqlConnection connection1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\msi\\OneDrive - INTEC\\INTEC\\Trimestre 7\\Desarrollo de software III\\Laboratorio\\RegistrarNovias\\RegistrarNovias\\Relacion.mdf\";Integrated Security=True");
                    connection1.Open();

                    SqlCommand cmd1 = new SqlCommand($"spRelacion", connection1);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@TipoDocumento", nuevaRelacion.TipoDocumento);
                    cmd1.Parameters.AddWithValue("@Documento", nuevaRelacion.Documento);
                    cmd1.Parameters.AddWithValue("@Nombres", nuevaRelacion.Nombres);
                    cmd1.Parameters.AddWithValue("@Apellidos", nuevaRelacion.Apellidos);
                    cmd1.Parameters.AddWithValue("@FechaNacimiento", nuevaRelacion.FechaNacimiento);
                    cmd1.Parameters.AddWithValue("@Sexo", nuevaRelacion.Sexo);
                    cmd1.Parameters.AddWithValue("@Estado", nuevaRelacion.Estado);
                    cmd1.Parameters.AddWithValue("@Nacionalidad", nuevaRelacion.Nacionalidad);
                    cmd1.Parameters.AddWithValue("@PaisOrigen", nuevaRelacion.PaisOrigen);
                    cmd1.Parameters.AddWithValue("@TipoDocumentoNovio", registroPersona.TipoDocumento);
                    cmd1.Parameters.AddWithValue("@DocumentoNovio", registroPersona.Documento);
                    cmd1.ExecuteNonQuery();

                    cantidadNovias--;
                }

                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\msi\\OneDrive - INTEC\\INTEC\\Trimestre 7\\Desarrollo de software III\\Laboratorio\\RegistrarNovias\\RegistrarNovias\\Persona.mdf\";Integrated Security=True");
                connection.Open();

                SqlCommand cmd = new SqlCommand($"spPersona", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TipoDocumento", registroPersona.TipoDocumento);
                cmd.Parameters.AddWithValue("@Documento", registroPersona.Documento);
                cmd.Parameters.AddWithValue("@Nombres", registroPersona.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", registroPersona.Apellidos);
                cmd.Parameters.AddWithValue("@FechaNacimiento", registroPersona.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Sexo", registroPersona.Sexo);
                cmd.Parameters.AddWithValue("@Estado", registroPersona.Estado);
                cmd.Parameters.AddWithValue("@Nacionalidad", registroPersona.Nacionalidad);
                cmd.Parameters.AddWithValue("@PaisOrigen", registroPersona.PaisOrigen);
                cmd.Parameters.AddWithValue("@Cantidad", registroPersona.Cantidad);
                cmd.ExecuteNonQuery();

                //Agregar una nueva persona
                Console.WriteLine("Desea ingresar una nueva persona? ");
                string nuevaPersonaRespuesta = Console.ReadLine();
                if (nuevaPersonaRespuesta == "si" || nuevaPersonaRespuesta == "Si" || nuevaPersonaRespuesta == "SI")
                {
                    nuevaPersonaBool = true;
                } else
                {
                    nuevaPersonaBool = false;
                }
            }

        }
    }
}

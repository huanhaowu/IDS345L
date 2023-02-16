using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\msi\\OneDrive - INTEC\\INTEC\\Trimestre 7\\Desarrollo de software III\\Laboratorio\\ConexionBD\\Practica1\\DB.mdf\";Integrated Security=True");
                connection.Open();
                SqlTransaction transaction = null;

                //Console.WriteLine(connection.State);

                Cliente cliente = new Cliente();
                #region
                /*
                cliente.ID = 1;
                cliente.Nombres = "Jose";
                cliente.Apellidos = "Perez";
                cliente.Estado = 0;
                cliente.FechaNacimiento = DateTime.Parse("1990-01-01");
                cliente.Comentario = "comentario";
                */
                #endregion

                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("                   REGISTRO DE CLIENTE                     ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("TipoDocumento:");
                cliente.TipoDocumento = Console.ReadLine();

                Console.WriteLine("Documento:");
                cliente.Documento = Console.ReadLine();

                SqlCommand cmd = new SqlCommand($"spGetClientes", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                cmd.Parameters.AddWithValue("@Documento", cliente.Documento);

                //Justo aquí tengo que hacer una lectura
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                { //Si existe, solamente hay que modificarlo para enseñarlo

                    Console.WriteLine("NOMBRE:" + dr["Nombres"].ToString());
                    cliente.Nombres = dr["Nombres"].ToString();

                    Console.WriteLine("APELLIDO:" + dr["Apellidos"].ToString());
                    cliente.Apellidos = dr["Apellidos"].ToString();

                    Console.WriteLine("ESTADO:" + dr["Estado"].ToString());
                    cliente.Estado = int.Parse(dr["Estado"].ToString());

                    Console.WriteLine("FECHA NACIMIENTO:" + dr["FechaNacimiento"].ToString());
                    cliente.FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());

                    Console.WriteLine("SEXO:" + dr["Sexo"].ToString());
                    cliente.Sexo = dr["Sexo"].ToString();

                    Console.WriteLine("COMENTARIO:" + dr["Comentario"].ToString());
                    cliente.Comentario = dr["Comentario"].ToString();
                }
                else { //Si no existe, pues se pide que se ingresen

                    Console.WriteLine("NOMBRE:");
                    cliente.Nombres = Console.ReadLine();

                    Console.WriteLine("APELLIDO:");
                    cliente.Apellidos = Console.ReadLine();

                    Console.WriteLine("ESTADO:");
                    cliente.Estado = int.Parse(Console.ReadLine());

                    Console.WriteLine("FECHA NACIMIENTO:");
                    cliente.FechaNacimiento = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("SEXO:");
                    cliente.Sexo = Console.ReadLine();

                    Console.WriteLine("COMENTARIO:");
                    cliente.Comentario = Console.ReadLine();
                }
                dr.Close();

               


                //--------------------------------------------------------------------------------------------------
                Movimiento movimiento = new Movimiento();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("                REGISTRO DE MOVIMIENTO                     ");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("");

                Console.WriteLine("MONTO:");
                cliente.Balance = decimal.Parse(Console.ReadLine());

                Console.WriteLine("DbCr:");
                movimiento.DbCr = (Console.ReadLine());

                Console.WriteLine("TipoTransaccion:");
                movimiento.TipoTransacccion = int.Parse(Console.ReadLine());

                Console.WriteLine("Descripcion:");
                movimiento.Descripcion = Console.ReadLine();

                //--------------------------------------------------------------------------------------------------
                #region
                /*
                Console.WriteLine($"NOMBRE:{cliente.Nombres} - APELLIDO:{cliente.Apellidos} - ESTADO:{cliente.Estado} - NACIMIENTO:{cliente.FechaNacimiento}");
                Console.ReadKey();
                */
                #endregion

                transaction = connection.BeginTransaction(); //alguien tiene que recibirlo
                cmd.Transaction = transaction; //relaciono el cmd  con el transaction, para que el cmd sepa de donde sacar informacion

                try
                {

                    //Se usa cuando ya se definio el comando y solamente hay que cambiar uno de los parametros, el del Sp
                    cmd.CommandText = "spUpsertCliente";

                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                    cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                    cmd.Parameters.AddWithValue("@Documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("@Comentario", cliente.Comentario);
                    cmd.Parameters.AddWithValue("@Balance", cliente.Balance);
                    cmd.Parameters.AddWithValue("@TipoTransaccion", movimiento.TipoTransacccion);


                    cmd.ExecuteNonQuery();

                    //Limpia los parametros
                    cmd.Parameters.Clear();
                    cmd.CommandText = "spMovimientos";
                    cmd.Parameters.AddWithValue("@TipoDocumento", cliente.TipoDocumento);
                    cmd.Parameters.AddWithValue("@Documento", cliente.Documento);
                    cmd.Parameters.AddWithValue("@TipoTransaccion", movimiento.TipoTransacccion);
                    cmd.Parameters.AddWithValue("@DbCr", movimiento.DbCr);
                    cmd.Parameters.AddWithValue("@Descripcion", movimiento.Descripcion);
                    cmd.Parameters.AddWithValue("@Monto", cliente.Balance);
                    cmd.ExecuteNonQuery(); 

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                    transaction.Rollback(); //devuelve lo que se ha hecho

                }
                
            }
        }
    }
}

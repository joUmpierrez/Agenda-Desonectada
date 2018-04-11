using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace UI
{
    class Program
    {
        private const String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BaseDeDatos-Agenda;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                #region Declara variablaes
                DataSet dataSet;
                SqlCommand select;
                SqlDataAdapter dataAdapter;
                SqlCommandBuilder commandBuilder;

                // Crea un DataSet
                dataSet = new DataSet();
                // Genera el select que depues se le pasara al adapter
                select = new SqlCommand("SELECT nombre, fechaCreacion FROM Agendas", connection);
                // Crea el adapter seguido del fill (metodo para refrescar el Dataset para que concuerdo con la Tabla en Base de Datos)
                dataAdapter = new SqlDataAdapter(select);
                dataAdapter.Fill(dataSet, "Agendas");
                // Genera automaticamente comandos para la tabla
                commandBuilder = new SqlCommandBuilder(dataAdapter);
                #endregion

                #region Comprueba las sentencias SQL generadas
                /*
                Console.WriteLine("UPDATE : ");
                Console.WriteLine("==================================================");
                Console.WriteLine(commandBuilder.GetUpdateCommand().CommandText);
                Console.WriteLine("         ");

                Console.WriteLine("INSERT : ");
                Console.WriteLine("==================================================");
                Console.WriteLine(commandBuilder.GetInsertCommand().CommandText);
                Console.WriteLine("         ");

                Console.WriteLine("DELETE : ");
                Console.WriteLine("==================================================");
                Console.WriteLine(commandBuilder.GetDeleteCommand().CommandText);
                Console.WriteLine("         ");
                Console.ReadKey();
                */
                #endregion

                #region Menu
                switch (switch_on)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                }
                #endregion


                #region Muestra la tabla "Agendas"
                for (int i = 1; i < dataSet.Tables["Agendas"].Rows.Count; i++)
                {
                    Console.WriteLine(i + " " + dataSet.Tables["Agendas"].Rows[i]["nombre"]);
                }
                #endregion

                #region Agregar una Fila
                DataTable Agendas = dataSet.Tables["Agendas"];
                DataRow row = Agendas.NewRow();
                row["nombre"] = Console.ReadLine();
                row["fechaCreacion"] = DateTime.Now.Date;
                Agendas.Rows.Add(row);
                dataAdapter.Update(dataSet, "Agendas");
                #endregion

                #region Modificar una Fila
                Console.WriteLine("");
                Console.WriteLine("Ingrese el numero de fila a editar");
                int selectedUpdate = int.Parse(Console.ReadLine());

                DataRowCollection rowCollectionUpdate = dataSet.Tables["Agendas"].Rows;
                DataRow selectedRowUpdate = rowCollectionUpdate[selectedUpdate];

                Console.WriteLine("Ingrese el nombre a colocar");

                selectedRowUpdate.BeginEdit();
                selectedRowUpdate["nombre"] = Console.ReadLine();
                selectedRowUpdate.EndEdit();

                dataAdapter.Update(dataSet, "Agendas");
                #endregion

                #region Borrar una Fila
                Console.WriteLine("");
                Console.WriteLine("Ingrese el numero de fila a borrar");
                int selectDelete = int.Parse(Console.ReadLine());

                DataRowCollection rowCollectionDelete = dataSet.Tables["Agendas"].Rows;
                DataRow selectedRowDelete = rowCollectionDelete[selectDelete];

                selectedRowDelete.Delete();
                dataAdapter.Update(dataSet, "Agendas");
                #endregion

                Console.ReadKey();
            }
        }
    }
}

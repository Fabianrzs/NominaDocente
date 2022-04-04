using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class DocenteContext
    {
        internal SqlConnection _connection;
        public DocenteContext()
        {
            _connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;" +
                "AttachDbFilename=C:\\Users\\WIN10\\Desktop\\NominaDocente\\Entity\\Database1.mdf;" +
                "Integrated Security=True;Trusted_Connection = True; MultipleActiveResultSets = True");
        }

        public void GuardarDocente(Docente docente)
        {
            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO DOCENTES (Identificacion, Nombres, TipoDocente, " +
                        "AreaDesempenio,Categoria,Salario,Nomina)" +
                        "Values (@Identificacion, @Nombres, @TipoDocente, " +
                        "@AreaDesempenio, @Categoria, @Salario, @Nomina )";
                    command.Parameters.Add("@Identificacion", SqlDbType.VarChar).Value = docente.Identificacion;
                    command.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = docente.Nombres;
                    command.Parameters.Add("@TipoDocente", SqlDbType.VarChar).Value = docente.TipoDocente;
                    command.Parameters.Add("@AreaDesempenio", SqlDbType.VarChar).Value = docente.AreaDesempenio;
                    command.Parameters.Add("@Categoria", SqlDbType.VarChar).Value = docente.Categoria;
                    command.Parameters.Add("@Salario", SqlDbType.Decimal).Value = docente.Salario;
                    command.Parameters.Add("@Nomina", SqlDbType.Decimal).Value = docente.Nomina;

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                _connection?.Close();
            }
        }

        public List<Docente> ConsultarDocentes()
        {
            List<Docente> docentes = new List<Docente>();

            try
            {
                _connection.Open();
                using (var command = _connection.CreateCommand())
                {

                    command.CommandText = "SELECT * FROM DOCENTES";

                    var dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Docente doncente = DataReaderMapToDocente(dataReader);
                            docentes.Add(doncente);
                        }
                    }
                }
            }
            finally
            {
                _connection.Close();
            }

            return docentes;    
        }

        private Docente DataReaderMapToDocente(SqlDataReader dataReader)
        {

            return (!dataReader.HasRows) ? null : new Docente()
            {
                Identificacion = (string)dataReader["Identificacion"],
                Nombres = (string)dataReader["Nombres"],
                TipoDocente = (string)dataReader["TipoDocente"],
                AreaDesempenio = (string)dataReader["AreaDesempenio"],
                Categoria = (string)dataReader["Categoria"],
                Salario = (decimal)dataReader["Salario"],
                Nomina = (decimal)dataReader["Nomina"],
            };
        }
    }
}

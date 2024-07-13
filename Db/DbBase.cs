using System.Data.SqlClient;

namespace WPF_Fancy_CRUD.Db
{
    /// <summary>
    /// Ésta es la clase general para base de datos. Todas las clases que vayan a ejecutar acciones sobre BD deberán heredar de ésta.
    /// </summary>
    public abstract class DbBase
    {
        string _connectionString = "Server=(Local); Database=Tienda; Integrated Security=true";
        protected SqlConnection Conexion()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

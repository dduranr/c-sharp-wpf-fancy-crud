using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.InteropServices.Marshalling;
using WPF_Fancy_CRUD.MVVM.Models;
using WPF_Fancy_CRUD.MVVM.Models.Interfaces;

namespace WPF_Fancy_CRUD.Db
{
    /// <summary>
    /// Esta clase contiene los métodos para ejecutar acciones sobre base de datos, todos relacionados con el modelo Usuario.
    /// </summary>
    public class DbUser : DbBase, IDbUser
    {

        /// <summary>
        /// Este método sirve para autenticar al usuario. Como parámetros se ponen usuario y contraseña. Dado que en la vista y modelo de vista la contraseña es tipo SecureString, entonces se usa la clase NetworkCredential ya que admite en el constructor una cadena tipo SecureString, y a partir de éste es posible obtener la contraseña en texto plano.
        /// </summary>
        /// <param name="credential"></param>
        /// <returns>Devuelve un booleano indicando si la autenticación fue exitosa o no.</returns>
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = Conexion())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User] WHERE usuario=@usuario AND contrasena=@contrasena";
                command.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@contrasena", SqlDbType.NVarChar).Value = credential.Password;
                validUser = (command.ExecuteScalar() == null) ? false : true;
            }
            return validUser;
        }

        /// <summary>
        /// Este método agrega un usuario
        /// </summary>
        /// <param name="userModel"></param>
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este método edita un usuario
        /// </summary>
        /// <param name="userModel"></param>
        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este método elimina un usuario
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este método obtiene un usuario por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este método obtiene un usuario por username
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Si tiene éxito devuelve un objeto tipo UserModel, de lo contrario devuelve null.</returns>
        public UserModel? GetByUsuario(string usuario)
        {
            UserModel? user = null;
            using (var connection = Conexion())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User] WHERE usuario=@usuario";
                command.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = usuario;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        //TODO: Armar helpers class, uno de ellos será un método que devuelva la misma cadena que se le pasa como parámetro, pero con la 1ra letra en mayúscula.
                        string rol = reader[10]?.ToString() ?? "No disponible";
                        string RolFormateado = char.ToUpper(rol[0]) + rol.Substring(1);

                        user = new UserModel()
                        {
                            Id = reader.GetInt32(0), // Use GetInt32 for integers
                            Usuario = reader[1]?.ToString() ?? "No disponible",
                            Contrasena = string.Empty,
                            Nombre = reader[3]?.ToString() ?? "No disponible",
                            Apellido1 = reader[4]?.ToString() ?? "No disponible",
                            Apellido2 = reader[5].ToString(),
                            Email = reader[6]?.ToString() ?? "No disponible",
                            Image = reader[7].ToString(),
                            Rol = RolFormateado,
                        };
                    }
                }
            }
            return user;
        }

        /// <summary>
        /// Este método obtiene todos los usuario
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}

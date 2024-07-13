using System.Data;
using System.Data.SqlClient;
using System.Net;
using WPF_Fancy_CRUD.MVVM.Models;
using WPF_Fancy_CRUD.MVVM.Models.Interfaces;

namespace WPF_Fancy_CRUD.Db
{
    /// <summary>
    /// Esta clase contiene los métodos para ejecutar acciones sobre base de datos, todos relacionados con el modelo Usuario.
    /// </summary>
    public class DbUser : DbBase, IDbUser
    {
        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este método implementa el método de validación de usuario para iniciar sesión.
        /// </summary>
        /// <param name="credential"></param>
        /// <returns>Devuelve un booleano indicando si la autenticación fue exitosa o no.</returns>
        /// <exception cref="NotImplementedException"></exception>
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

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Este método se encarga de recuperar de la base de datos el usuario coincidente con el nombre de usuario pasado como parámetro.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public UserModel GetByUsuario(string usuario)
        {
            UserModel user = null;
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
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Usuario = reader[1].ToString(),
                            Contrasena = string.Empty,
                            Nombre = reader[3].ToString(),
                            Apellido1 = reader[4].ToString(),
                            Apellido2 = reader[5].ToString(),
                            Email = reader[6].ToString(),
                            Image = reader[7].ToString(),
                        };
                    }
                }
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}

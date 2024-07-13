using System.Net;

namespace WPF_Fancy_CRUD.MVVM.Models.Interfaces
{
    /// <summary>
    /// En esta interfaz se declaran los métodos a implementar en la clase db.DbUser
    /// </summary>
    public interface IDbUser
    {
        /// <summary>
        /// Este método sirve para autenticar al usuario. Como parámetros se ponen usuario y contraseña. Dado que en la vista y modelo de vista la contraseña es tipo SecureString, entonces se usa la clase NetworkCredential ya que admite en el constructor una cadena tipo SecureString, y a partir de éste es posible obtener la contraseña en texto plano.
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsuario(string usuario);
        IEnumerable<UserModel> GetAll();
    }
}

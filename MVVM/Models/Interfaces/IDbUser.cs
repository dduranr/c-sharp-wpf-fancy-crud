using System.Net;

namespace WPF_Fancy_CRUD.MVVM.Models.Interfaces
{
    /// <summary>
    /// En esta interfaz se declaran los métodos a implementar en la clase db.DbUser. Los doc comments de cada uno de estos métodos no se ponen aqui sino en la clase que los implementa.
    /// </summary>
    public interface IDbUser
    {

        bool AuthenticateUser(NetworkCredential credential);

        void Add(UserModel userModel);

        void Edit(UserModel userModel);

        void Remove(int id);

        UserModel GetById(int id);

        UserModel? GetByUsuario(string usuario);

        IEnumerable<UserModel> GetAll();
    }
}

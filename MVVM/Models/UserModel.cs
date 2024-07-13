namespace WPF_Fancy_CRUD.MVVM.Models
{
    public class UserModel
    {
        // En la vista y modelo de vista la contraseña es tipo SecureString. Sin embargo, aquí en el modelo no tiene sentido usar tipo de datos SecureString ya que en algún momento será necesario convertirla en texto plano para realizar validaciones y/o guardarla en DB. Sólo recordar que debe cifrarse la contraseña inmediatamente después de ser creada.
        public string Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}

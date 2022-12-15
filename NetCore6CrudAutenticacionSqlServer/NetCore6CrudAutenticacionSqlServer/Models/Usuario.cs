namespace NetCore6CrudAutenticacionSqlServer.Models
{
    public class Usuario
    {
        public string idUsuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string rol { get; set; }

        public static List<Usuario> DB()
        {
            var list = new List<Usuario>()
            {
                new Usuario
                {
                    idUsuario = "1",
                    usuario = "marlon",
                    password = "1234",
                    rol = "administrador"
                },
                new Usuario
                {
                    idUsuario = "2",
                    usuario = "patricia",
                    password = "1234",
                    rol = "empleado"
                },
                new Usuario
                {
                    idUsuario = "3",
                    usuario = "lucas",
                    password = "1234",
                    rol = "asesor"
                },
                new Usuario
                {
                    idUsuario = "4",
                    usuario = "juan",
                    password = "1234",
                    rol = "empleado"
                },

            };
            return list;
        }
    }
}

using System.Security.Claims;

namespace NetCore6CrudAutenticacionSqlServer.Models
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public static dynamic validarToken(ClaimsIdentity identity)
        {
            try
            {
                if(identity.Claims.Count() == 0) // validar si llega el token
                {
                    return new
                    {
                        success = false,
                        message = "verificar token",
                        result = ""
                    };
                }

                // si identity si trae informacion
                // verificamos por medio del id en el token a quien eprtenece el token

                var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;  // sacamos el id del claims del token
                
                // busco en la base de datos el usuario con el id del token
                Usuario usuario = Usuario.DB().FirstOrDefault(x => x.idUsuario == id);

                return new
                {
                    success = true,
                    message = " exito",
                    result = usuario
                };
            }
            catch (Exception)
            {
                return new
                {
                    success = false,
                    message = "catch: " + ex.Message,
                    result = ""
                };
            }
        }
    }
}

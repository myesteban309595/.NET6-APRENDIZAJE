using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NetCore6CrudAutenticacionSqlServer.Models;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NetCore6CrudAutenticacionSqlServer.Controllers
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    { 
      public IConfiguration _configuration;
      public UsuarioController(IConfiguration configuration)   // sabemos que es un constructor cuando tiene el mismo nombre de la clase
      {
        _configuration = configuration;
      }
        [HttpPost]
        [Route("login")]
        public dynamic IniciarSesion([FromBody] Object optData)
        {
            // en la variable data recibimos el usuario y contraseña
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());
            string user = data.usuario.ToString();
            string password = data.password.ToString();

            //aqui consultamos y validamos que ese usuario log exista en la base de datos
            Usuario usuario = Usuario.DB().Where(x => x.usuario == user && x.password == password).FirstOrDefault();

            // si no existe en la base de datos retorna
            if(usuario == null)
            {
                return new
                {
                    success = true,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }
            // llamamos del appsetting jwt; y convertimos a la clase con el modelo con Get<Jwt>()
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>(); // y asi se convierte en una clase y acceder a las propuedades del modelo jwt
            // en claims vamos a encapsular todo lo que va llevar nuestro token (correo, id, etc etc)
            var claims = new[]
            {
                // los tres primeros valores son de configuracion del token
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", usuario.idUsuario),
                new Claim("usuario", usuario.usuario),
            };

            // la contraseña se convierte e bytes y se encripta
            var key  = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            // creamos un inicio de sesion
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // SecurityAlgorithms.HmacSha256 algoritmo de seguridad

            var token = new JwtSecurityToken(
                 jwt.Issuer,
                 jwt.Audience,
                 claims,
                 expires: DateTime.Now.AddMinutes(4) // opcional
                );

            return new
            {
                success = true,
                message = "exitoso",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}

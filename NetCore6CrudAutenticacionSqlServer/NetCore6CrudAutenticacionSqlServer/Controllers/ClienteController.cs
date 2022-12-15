using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore6CrudAutenticacionSqlServer.Models;
using System.Security.Claims;

namespace NetCore6CrudAutenticacionSqlServer.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic ListarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    Id= 1,
                    nombre = "marlon",
                    edad = "19",
                    correo = "test@gmail.com"
                },
                new Cliente
                {
                    Id= 2,
                    nombre = "cristian",
                    edad = "30",
                    correo = "test2@gmail.com"
                },
            };

            return clientes;
        }

        [HttpGet]
        [Route("listarById")]
        public dynamic ListarClienteById(int _id)
        {
            return new Cliente
            {
                Id = _id,
                nombre = "marlon",
                edad = "19",
                correo = "test@gmail.com"
            };
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.Id = 3;
            return new
            {
                success = true,
                message = " cliente registrado",
                result = cliente
            };
        }

        [HttpDelete]
        [Route("eliminar")]
        [Authorize] // si o si enviar un token valido, asi evitamos ingresar al codigo y gastar recursos
        public dynamic eliminarCliente(Cliente cliente)
        {
            //var token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            // para validar que solo cierto usuario pueda eliminar

            var identity = HttpContext.User.Identity as ClaimsIdentity; // con este codigo obtenemos el token

            var rToken = Jwt.validarToken(identity);

            if(!rToken.success ) // si success es false
            {
                return rToken;
            }

            Usuario usuario = rToken.result;

            if(usuario.rol != "administrador")
            {
                return new
                {
                    success = false,
                    message = "No tienes permiso para eliminar este cliente",
                    result = cliente
                };
            }

            return new
            {
                success = true,
                message = " cliente eliminado",
                result = cliente
            };
        }
    }
}

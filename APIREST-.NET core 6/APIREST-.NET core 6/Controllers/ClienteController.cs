using Microsoft.AspNetCore.Mvc;
using APIREST_.NET_core_6.Models;
using System.Linq;

namespace APIREST_.NET_core_6.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]  /*Cliente/listar*/
        public dynamic listarCliente()
        {
            List<Cliente> clientes = new List<Cliente>
            {
              new Cliente
              {
                  id = "1",
                  correo = "google@gmail.com",
                  edad = "20",
                  nombre= " pepito perez"
              },
              new Cliente
              {
                  id= "2",
                  correo = "anagoogle@gmail.com",
                  edad= "32",
                  nombre = "ana pereira"
              }
            };

            return clientes;
        }

        [HttpGet]
        [Route("listarById")]  /*Cliente/listar*/
        public dynamic listarClienteById(string _id)
        {
            // obtenermos el cliente de la db

            return new Cliente
             {
                id = _id,
                correo = "anagoogle@gmail.com",
                edad = "32",
                nombre = "ana pereira"
             };
           
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente( Cliente cliente)
        {
            cliente.id = "3";
            return new
            {
                success = true,
                message = "cliente registrado",
                result = cliente
            };
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if (token != "marlon1234")
            {
                return new
                {
                    success = false,
                    message = "token incorrecto",
                    result = ""
                };
            }

            return new
            {
                success = true,
                message = "cliente eliminado",
                result = cliente
            };
        }
    };

}

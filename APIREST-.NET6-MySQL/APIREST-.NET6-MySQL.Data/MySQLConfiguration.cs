using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIREST_.NET6_MySQL.Data
{
    public class MySQLConfiguration
    {
        // este es un constructor en c# que va recibir una cadenade conexion y la va poner en la propiedad
        public MySQLConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs
{
    public class UpdateClientDTO
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public short Edad { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs.AdminitratorDTO
{
    public class UpdateClienteDTO
    {
        public int idAdmin { get; set; }
        public string username { get; set; }
        public string passwordHash { get; set; }
        public string correo { get; set; }
    }
}

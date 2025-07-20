using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs.LoginDTO
{
    public class LoginResponseDTO
    {
        public int IdCliente { get; set; }
        public string Correo { get; set; }
        public string Token { get; set; }
    }
}

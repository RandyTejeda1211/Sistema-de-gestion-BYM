using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs.LoginDTO
{
    public class LoginRequestDTO
    {
        public string Correo { set; get; }
        public string Password { set; get; }
    }
}

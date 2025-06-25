using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs.AdminitratorDTO
{
    public class AdminCreateDTO
    {
        public string username { get; set; }
        public string passwordHash { get; set; }
        public string correo { get; set; }
    }
}

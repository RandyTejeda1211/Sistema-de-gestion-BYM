using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Domain.Models
{
    public class UserCredentials
    {
        public int IdCliente { get; set; }
        public string Correo { get; set; }
        public string PasswordHash { get; set; }
    }
}

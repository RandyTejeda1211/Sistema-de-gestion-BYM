using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs.ServiceProvidedDTO
{
    public class ServiceProvidedCreateDTO
    {
        public string nombre { get; set; }
        public decimal precio  { get; set; }
        public string caracteristicas { get; set; }
    }
}

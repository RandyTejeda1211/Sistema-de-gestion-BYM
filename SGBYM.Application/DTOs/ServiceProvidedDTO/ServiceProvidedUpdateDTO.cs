using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs.ServiceProvidedDTO
{
    public class ServiceProvidedUpdateDTO
    {
        public int idServicio { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string caracteristicas { get; set; }
    }
}

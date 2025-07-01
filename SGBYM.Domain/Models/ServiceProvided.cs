using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Domain.Models
{
    public class ServiceProvided
    {
        public int idServicios { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string caracteristica { get; set; }
    }
}

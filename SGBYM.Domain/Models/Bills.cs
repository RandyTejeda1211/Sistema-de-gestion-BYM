using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Domain.Models
{
    public class Bills
    {
        public int idfacturas { get; set; }
        public string serial { get; set; }
        public DateTime fechaEmision { get; set; }
        public decimal montoTotal { get; set; }
        public string formaPago { get; set; }
        public bool statusPago { get; set; }
        public int idServicioRegistrado { get; set; }

        public ServicePRegistered ServicePRegistered { get; set; }

        
    }
}

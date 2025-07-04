using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs
{
    public class CiteBillCreateDTO
    {
        public DateTime fecha { get; set; }
        public int idCliente { get; set; }
        public bool estado { get; set; }
        public int idServicio { get; set; }


        public string serial { get; set; }
        public DateTime fechaEmision { get; set; }
        public decimal montoTotal { get; set; }
        public string formaPago { get; set; }
        public bool statusPago { get; set; }
        public int idServicioRegistrado { get; set; }
    }
}

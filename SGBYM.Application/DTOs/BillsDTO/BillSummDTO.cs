using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs.BillsDTO
{
    public class BillSummDTO
    {
        public string serial { get; set; }
        public DateTime fechaEmision { get; set; }
        public decimal montoTotal { get; set; }
        public string formaPago { get; set; }
        public bool statusPago { get; set; }
    }
}

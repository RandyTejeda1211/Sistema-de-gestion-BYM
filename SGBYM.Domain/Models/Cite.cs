using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Domain.Models
{
    public class Cite
    {
        public int idCita { get; set; }
        public DateTime fecha { get; set; }
        public int idCliente { get; set; }

        public  Client Client { get; set; }

        public bool estado { get; set; }
    }
}

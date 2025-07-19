using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Domain.Models
{
    public class ServicePRegistered
    {
        public int idServicioRegistrado { get; set; }
        public int idServicio { get; set; }
        public int idCita { get; set; }

        public ServiceProvided ServiceP{ get; set; }
        public Cite Cite{ get; set; }

        public ICollection<Bills> bills{ get; set; }
    }
}

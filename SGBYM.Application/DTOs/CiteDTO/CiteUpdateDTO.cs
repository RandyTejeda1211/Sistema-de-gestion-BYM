using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBYM.Application.DTOs.CiteDTO
{
    public class CiteUpdateDTO
    {
        public int idCita { get; init; }
        public DateTime fecha { get; set; }
        public bool estado { get; set; }
    }
}

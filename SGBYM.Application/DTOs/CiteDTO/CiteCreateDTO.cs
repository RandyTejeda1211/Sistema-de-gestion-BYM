using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Domain.Models;

namespace SGBYM.Application.DTOs.CiteDTO
{
    public class CiteCreateDTO
    {
        public DateTime fecha { get; set; }
        public int idCliente { get; set; }
        public bool estado { get; set; }
    }
}

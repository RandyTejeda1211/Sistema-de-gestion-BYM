using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs.CiteDTO;

namespace SGBYM.Application.Interfaces
{
    public interface ICiteService
    {
        Task CreateCite(CiteCreateDTO cite);
        Task<IEnumerable<CiteSummDTO>> GetAllCite();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs;
using SGBYM.Application.DTOs.BillsDTO;
using SGBYM.Application.DTOs.CiteDTO;

namespace SGBYM.Application.Interfaces
{
    public interface ICiteService
    {
        Task CreateCite(CiteBillCreateDTO citeBillCreateDTO);
        Task<IEnumerable<CiteSummDTO>> GetAllCite();
        Task UpdateCite(CiteUpdateDTO cite);
    }
}

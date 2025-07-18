﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs.CiteDTO;
using SGBYM.Application.Interfaces;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;

namespace SGBYM.Application.Services
{
    public class CiteService : ICiteService
    {
        private readonly ICiteRepository _citeRepository;
        public CiteService(ICiteRepository citeRepository)
        {
            _citeRepository = citeRepository;
        }
        public async Task CreateCite(CiteCreateDTO cite)
        {
            var cites = new Cite
            {
                fecha = cite.fecha,
                idCliente = cite.idCliente,
                estado = true,
            };
            await _citeRepository.CreateCita(cites);
        }

        public async Task<IEnumerable<CiteSummDTO>> GetAllCite()
        {
            var cites = await _citeRepository.GetAllCites();
            return cites.Select(c => new CiteSummDTO
            {
                fecha = c.fecha,
                idCliente = c.idCliente,
                estado = c.estado,
                NombreCliente = c.Client.Nombre
            });
            
        }

        
    }
}

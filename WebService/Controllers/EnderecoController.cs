﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api")]
    public class EnderecosController : ControllerBase
    {
        private readonly Context _context;

        public EnderecosController(Context context)
        {
            _context = context;
        }

        [HttpGet("Endereco/Enderecos")]
        public IEnumerable<ApiCep> GetAll()
        {
            List<ApiCep> enderecos = _context.ApiCep.ToList();
            return enderecos;
        }

        [HttpGet("Endereco/Enderecos/{cep}")]
        public IEnumerable<ApiCep> GetPorCep(string cep)
        {
            var endereco = _context.ApiCep.Where(s => s.Cep == cep);
            return endereco;
        }

        [HttpGet("Endereco/EnderecosPorEstado/{uf}")]
        public IEnumerable<ApiCep> GetPorEstado(string uf)
        {
            List<ApiCep> enderecos = _context.ApiCep.Where(s => s.Uf == uf).ToList();
            return enderecos;
        }
    }
}
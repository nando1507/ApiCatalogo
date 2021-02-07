using APICatalogo5._0.Context;
using APICatalogo5._0.Models;
using APICatalogo5._0.Repository;
using APICatalogo5._0.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo5._0.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        //private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger _looger;
        //private readonly IMapper _mapper;
        private readonly IUnitOfWork _context;

        public CategoriaController(IUnitOfWork context ,/*AppDbContext context, IMapper mapper,*/IConfiguration config,  ILogger<CategoriaController> logger)
        {
            _configuration = config;
            _context = context;
            //_mapper = mapper;
            _looger = logger;

        }

        [HttpGet("autor")]
        public string GetAutor()
        {
            var autor = _configuration["autor"];

            return $"Autor: {autor}";
        }

        [HttpGet("saudacao/{nome}")]
        public ActionResult<string> GetSaudacao([FromServices] IServico servico, string nome)
        {

            return servico.Saudacao(nome);
        }
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetProdutosCategorias()
        {
            _looger.LogInformation("=========GET api/Categorias/Produtos ==========");
            try
            {
                return _context.categoriaRepository.GetCategoriasProdutos().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter as Categorias");
                throw;
            }

        }
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                return _context.categoriaRepository.Get().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter a Categoria");
                throw;
            }

        }
        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            try
            {
                var categoria = _context.categoriaRepository.GetById(p => p.CategoriaId == id);
                _looger.LogInformation($"=========GET api/Categorias/ID = {id}  ==========");
                if (categoria == null)
                {
                    _looger.LogInformation($"=========GET api/Categorias/ID = {id} NOT FOUND ==========");
                    return NotFound($"A Categoria {id} não foi encontrada");
                }
                else
                {

                    return categoria;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter as Categorias");
                throw;
            }

        }
        [HttpPost]
        public ActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                _context.categoriaRepository.Add(categoria);
                _context.commit();
                return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar nova Categorias");
                throw;
            }

        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId)
                {
                    return BadRequest($"Nao Foi possivel atualizar a categoria de ID {id}");
                }
                _context.categoriaRepository.Update(categoria);
                _context.commit();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar a Categoria {id}");
                throw;
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            try
            {
                var categoria = _context.categoriaRepository.GetById(p => p.CategoriaId == id);

                if (categoria == null)
                {
                    return NotFound($"Erro ao localizar Categoria: {id}");
                }

                _context.categoriaRepository.Delete(categoria);
                _context.commit();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir Categoria: {id}");
                throw;
            }
        }
    }
}

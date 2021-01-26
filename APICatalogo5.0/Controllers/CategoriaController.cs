using APICatalogo5._0.Context;
using APICatalogo5._0.Models;
using APICatalogo5._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public CategoriaController(AppDbContext context, IConfiguration config)
        {
            _configuration = config;
            _context = context;
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
        public async Task<ActionResult<IEnumerable<Categoria>>> GetProdutosCategoriasAsync()
        {
            try
            {
                return await _context.Categorias.Include(X => X.Produtos).AsNoTracking().ToListAsync();
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
                return _context.Categorias.AsNoTracking().ToList();
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
                var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);
                if (categoria == null)
                {
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
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
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
                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
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
                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

                if (categoria == null)
                {
                    return NotFound($"Erro ao localizar Categoria: {id}");
                }

                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
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

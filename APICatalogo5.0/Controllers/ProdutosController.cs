using APICatalogo5._0.Context;
using APICatalogo5._0.Filter;
using APICatalogo5._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo5._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            try
            {
                return _context.Produtos.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter os Produtos");
                throw;
            }

        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
                if (produto == null)
                {
                    return NotFound($"O Produto {id} não foi encontrado");
                }
                else
                {
                    return produto;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao Obter o Produto");
                throw;
            }
          
        }

        [HttpPost]
        public ActionResult Post([FromBody] Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao adicionar nova Categorias");
                throw;
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            try
            {
                if (id != produto.ProdutoId)
                {
                    return BadRequest($"Nao Foi possivel atualizar o produto de ID {id}");
                }

                _context.Entry(produto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar o Produto {id}");
                throw;
            }
           
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {

            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

                if (produto == null)
                {
                    return NotFound($"Erro ao localizar Produto: {id}");
                }

                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir Produto: {id}");
                throw;
            }
           
        }
    }
}

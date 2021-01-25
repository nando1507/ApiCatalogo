using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo5._0.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage ="O nome é obrigatório")]
        [StringLength(80, ErrorMessage = "O nome deve ter entre 5 e 80 Caracteres", MinimumLength = 5)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }
        [Required]
        [Range(1,10000, ErrorMessage = "o preço deve estar entre {1} e {2}" )]
        public decimal Preco { get; set; }
        [Required]
        [MaxLength(500)]
        public string ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaID { get; set; }
    }
}

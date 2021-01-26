using APICatalogo5._0.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo5._0.Models
{
    [Table("Produto")]
    public class Produto : IValidatableObject
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(80, ErrorMessage = "O nome deve ter entre 5 e 80 Caracteres", MinimumLength = 5)]
        [PrimeiraLetraMaiuscula]
        public string Nome { get; set; }
        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "o preço deve estar entre {1} e {2}")]
        public decimal Preco { get; set; }
        [Required]
        [MaxLength(500)]
        public string ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var primeriaLetra = this.Nome[0].ToString();
            if (primeriaLetra != primeriaLetra.ToUpper())
            {
                yield return new ValidationResult("A Primeria letra do nome do produto deve ser maiuscula", new[] { nameof(this.Nome) });
            }

            if (this.Estoque <= 0)
            {
                yield return new ValidationResult("o tamanho do estoque deve ser maior que zero", new[] { nameof(this.Estoque) });
            }
        }
    }
}

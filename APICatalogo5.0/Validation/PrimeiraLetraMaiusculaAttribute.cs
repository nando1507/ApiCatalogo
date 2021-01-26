using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo5._0.Validation
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(null == value || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            
            var primeriaLetra = value.ToString()[0].ToString();
            if(primeriaLetra != primeriaLetra.ToUpper())
            {
                return new ValidationResult("A Primeria letra do nome do produto deve ser maiuscula");
            }


            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo5._0.Services
{
    public class Servico : IServico
    {
        public string Saudacao(string nome)
        {
            DateTime dt = DateTime.Now;


            return $"Bem-Vindo, {nome} {dt:dd}/{dt:MM}/{dt:yyyy} as {dt:HH}:{dt:mm}:{dt:ss}";
        }
    }
}

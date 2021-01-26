using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo5._0.Filter
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _looger;
        public ApiLoggingFilter(ILogger<ApiLoggingFilter> looger)
        {
            _looger = looger; 
        }


        //Metodo executa antes da action
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _looger.LogInformation($"=> Executando -> OnActionExecuting");
            _looger.LogInformation($"=> #########################################");
            _looger.LogInformation($"=> {DateTime.Now.ToLongTimeString()}");
            _looger.LogInformation($"=> ModelStare : {context.ModelState.IsValid}");
            _looger.LogInformation($"=> ##########################################");
            _looger.LogTrace("Erro",context);
        }

        //Metodo executa Depois da action
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _looger.LogInformation($"=> Executando -> OnActionExecuted");
            _looger.LogInformation($"=> Executando -> OnActionExecuted");
            _looger.LogInformation($"=> #########################################");
            _looger.LogInformation($"=> {DateTime.Now.ToLongTimeString()}");
            _looger.LogInformation($"=> ModelStare : {context.ModelState.IsValid}");
            _looger.LogInformation($"=> ##########################################");
            _looger.LogTrace("Erro", context);
        }

    }
}

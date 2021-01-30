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
        private readonly ILogger<ApiLoggingFilter> _logger;
        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }

        DateTime[] dt = new DateTime[2];


        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("########## Executando -> OnActionExecuting");
            _logger.LogInformation("##########################################");
            _logger.LogInformation($"Horario:{DateTime.Now.ToLongTimeString()}");
            dt[0] = DateTime.Now;
            _logger.LogInformation($" ModelState: {context.ModelState.IsValid}");
            _logger.LogInformation("##########################################");
           
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("########### Executando -> OnActionExecuted");
            _logger.LogInformation("##########################################");
            _logger.LogInformation($"Horario: {DateTime.Now.ToLongTimeString()}");
            dt[1] = DateTime.Now;            
            _logger.LogInformation($"tempo de execução{dt[1].Subtract(dt[0])}");
            _logger.LogInformation($" ModelState: {context.ModelState.IsValid}");
            _logger.LogInformation("##########################################");
        }

    
    }
}

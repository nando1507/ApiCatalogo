using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo5._0.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message{ get; set; }
        public string Trace { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}

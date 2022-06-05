using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiValidationErrorsResponse : ApiResponse
    {
        public ApiValidationErrorsResponse() : base(400)
        {
        }
        public IEnumerable<String> Errors { get; set; }
    }
}
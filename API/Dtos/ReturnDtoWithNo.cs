using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ReturnDtoWithNo<T>
    {
        public int ItemNo { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
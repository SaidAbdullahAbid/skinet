using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        Product()
        {
            Name = "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Store
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }  
}

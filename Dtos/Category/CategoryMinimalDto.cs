using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Category
{
    public class CategoryMinimalDto
    {
        public int ID { get; set; }
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Category
{
    public class AddNewCategoryDto
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
    }
}
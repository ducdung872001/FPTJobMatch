﻿﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTJobMatch.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }        
	}
}

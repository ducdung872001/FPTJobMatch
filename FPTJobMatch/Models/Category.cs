﻿﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTJobMatch.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Job>? Jobs { get; set; }
	}
}

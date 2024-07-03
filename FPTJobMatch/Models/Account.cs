﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using FPTJobMatch.Models;

namespace FPTJobMatch.Models
{
    public class Account
    {
        public string UserId {  get; set; }
        public string FullName { get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

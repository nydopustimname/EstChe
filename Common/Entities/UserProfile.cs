﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public string Password { }

        public virtual User User { get; set; }
    }
}
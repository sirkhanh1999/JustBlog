﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? AboutMe { get; set; }
    }
}
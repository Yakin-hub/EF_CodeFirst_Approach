﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF_CodeFirst_Approach.Models
{
    public class StudentContext : DbContext
    {
     public DbSet<Student> Students { get; set; }
    }
}
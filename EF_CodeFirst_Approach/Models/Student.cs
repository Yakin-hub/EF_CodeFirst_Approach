using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EF_CodeFirst_Approach.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }  
        public string Gender { get; set; }  
        public int Age { get; set; } = 0;
    }
}
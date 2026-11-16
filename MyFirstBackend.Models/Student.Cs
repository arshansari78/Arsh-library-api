using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyFirstBackend.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(30)")]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(10)")]

        public string PhoneNo { get; set; }
        [Column(TypeName = "NVARCHAR(200)")]

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyFirstBackend.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(30)")]

        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(30)")]

        public String Author { get; set; }
        [Column(TypeName = "NVARCHAR(100)")]

        public string Publication { get; set; }

        public string? Category { get; set; }


    }
}

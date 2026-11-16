using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyFirstBackend.ViewModels
{
    public class BookVm
    {
        public int Id { get; set; }
        

        public string Name { get; set; }

       
        public string Author { get; set; }
        

        public string Publication { get; set; }


        public string? Category { get; set; }
    }
}

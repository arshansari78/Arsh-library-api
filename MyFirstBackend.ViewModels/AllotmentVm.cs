using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MyFirstBackend.Models;
using MyFirstBackend.ViewModels;

namespace MyFirstBackend.ViewModels
{
    public  class AllotmentVm
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public StudentVm? Student { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public BookVm? Book { get; set; }
        public string? Note { get; set; }
        public DateTime OnDate { get; set; }
    }
}

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OOPASU.Api.Data
{
    [Table("Lesson")]
    public class Lesson
    {
        [Required] public int Id { get; set; }
        
        [Required] public string Title { get; set; }
        
        public decimal Description { get; set; }
        
        [Required] public DateTime CreatedAt { get; set; }
        
        public int TimeToComplete { get; set; }
        
        [DefaultValue(false)]
        public bool IsVisible { get; set; }
    }
}
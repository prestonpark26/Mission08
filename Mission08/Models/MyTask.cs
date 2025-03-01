using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mission08.Models;

public class MyTask
{
    [Key]
    [Required]
    public int TaskId { get; set; }
    
    [Required(ErrorMessage = "Task name is required")]
    public string TaskName { get; set; }
    
    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }
    
    public Category? Category { get; set; }
    
    [Display(Name = "Event Date")]
    [DataType(DataType.Date)]
    [RegularExpression(@"\d{4}-\d{2}-\d{2}", ErrorMessage = "The date format must be YYYY-MM-DD.")]
    public DateTime?  DueDate { get; set; }
  
    [Required(ErrorMessage = "Quadrant is required")]
    public int Quadrant { get; set; }
  
    [Required(ErrorMessage = "Completed is required")]
    public bool Completed { get; set; }
}
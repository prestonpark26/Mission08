using System.ComponentModel.DataAnnotations;

namespace Mission08.Models
{
    public class Category
    {
        //this is the category class to connect to the categories table in the database
            [Key]
            public int CategoryId { get; set; }

            [Required]
            public string CategoryName { get; set; }
    }
}


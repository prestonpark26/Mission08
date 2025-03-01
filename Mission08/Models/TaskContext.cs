
using Microsoft.EntityFrameworkCore;
namespace Mission08.Models;

public class TaskContext : DbContext
{
    //task context constructor
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) 
    {
    }

    //tables for task and categories
    public DbSet<MyTask> MyTasks { get; set; }
    
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Home"},
            new Category { CategoryId = 2, CategoryName = "School"},
            new Category { CategoryId = 3, CategoryName = "Work"},
            new Category { CategoryId = 4, CategoryName = "Church"}
        );
    }
    
    
}

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
    
}
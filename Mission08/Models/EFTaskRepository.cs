namespace Mission08.Models;

public class EfTaskRepository : ITaskRepository
{
    private TaskContext _context;
    
    public EfTaskRepository(TaskContext temp)
    {
        _context = temp;
    }

    public IQueryable<MyTask> Tasks => _context.MyTasks.AsQueryable();
    public List<Category> Categories => _context.Categories.ToList();

    public void AddTask(MyTask task)
    {
        _context.Add(task);
        _context.SaveChanges();
        
    }
    public void Update(MyTask task)
    {
        _context.Update(task); // Entity Framework will track changes
        _context.SaveChanges(); // Save the changes to the database
    }

    // Method to save changes to the database
    public void SaveChanges()
    {
        _context.SaveChanges(); // Ensure changes are saved
    }
    
}
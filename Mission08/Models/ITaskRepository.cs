namespace Mission08.Models;

public interface ITaskRepository
{
    IQueryable<MyTask> MyTasks{ get; }
    List<Category> Categories { get; }
    public void AddTask(MyTask newTask); 
    public void Update(MyTask updatedTask);
    void SaveChanges(); 
    public void DeleteTask(MyTask task);
}
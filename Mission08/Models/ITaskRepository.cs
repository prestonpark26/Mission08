namespace Mission08.Models;

public interface ITaskRepository
{
    List<MyTask> Tasks { get; }
    List<Category> Categories { get; }
    public void AddTask(MyTask newTask); 
    public void Update(MyTask updatedTask);
    void SaveChanges(); 
}
namespace A2_Req_ToDo.Models
{
    public class Task
    {
        public required int TaskID { get; set; }  // Required TaskID (Unique identifier for each task)
        public required string TaskName { get; set; }  // Required TaskName (The name/description of the task)
        public required DateTime DueDate { get; set; }  // Required DueDate (The date the task is due)
        
        public string? Tag { get; set; }  // Nullable Tag (Optional categorization or label for the task)
        public string? PriorityLevel { get; set; }  // Nullable PriorityLevel (Priority level of the task: low, medium, high, etc.)
    }
}

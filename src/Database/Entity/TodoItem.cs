using System.ComponentModel.DataAnnotations;

namespace Database.Entity;

public class TodoItem
{
    [Key]
    public int Id { get; set; } // Primary Key
    public string Title { get; set; } = string.Empty; // 제목
    public bool IsCompleted { get; set; } = false; // 완료 여부
    public DateTime? DueDate { get; set; } // 마감일 (null 가능)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // 생성 날짜
}
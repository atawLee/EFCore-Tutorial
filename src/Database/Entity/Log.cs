using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entity;

public abstract class Log
{
    [Key]
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    
    [MaxLength(1000)]
    public string Message { get; set; } = string.Empty;
}

public class SystemLog : Log
{
    [MaxLength(50)]
    public string LogLevel { get; set; } = "Info";  // 예: "Info", "Warning", "Critical"
}

public class ErrorLog : Log
{
    [MaxLength(1000)]
    public string ExceptionMessage { get; set; } = string.Empty;
    [MaxLength(1000)]
    public string StackTrace { get; set; } = string.Empty;
}


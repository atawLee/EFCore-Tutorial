using System.ComponentModel.DataAnnotations;

namespace Database.Entity;

public abstract class DocumentBase
{
    [Key]
    public int Id { get; set; }
    [MaxLength(255)]
    public string Title { get; set; }
    [MaxLength(20)]
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class GeneralDocumentBase : DocumentBase
{
    [MaxLength(255)]
    public string Content { get; set; }
}

public class ContractDocumentBase : DocumentBase
{
    [MaxLength(255)]
    public string ContractorName { get; set; }
    public DateTime ExpirationDate { get; set; }
}

public class TechnicalDocumentBase : DocumentBase
{
    [MaxLength(255)]
    public string TechnologyUsed { get; set; }
    public int Version { get; set; }
}
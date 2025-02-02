namespace Database.Entity;

public class DocumentBase
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class GeneralDocumentBase : DocumentBase
{
    public string Content { get; set; }
}

public class ContractDocumentBase : DocumentBase
{
    public string ContractorName { get; set; }
    public DateTime ExpirationDate { get; set; }
}

public class TechnicalDocumentBase : DocumentBase
{
    public string TechnologyUsed { get; set; }
    public string Version { get; set; }
}
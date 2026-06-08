using Microsoft.AspNetCore.Http;

public class ContractDto
{
    public int Id { get; set; }

    public int ClientId { get; set; }
    public string? ClientName { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string? Status { get; set; }
    public string? ServiceLevel { get; set; }

    // ✅ FOR UPLOAD (THIS IS WHAT YOU WERE MISSING)
    public IFormFile? AgreementFile { get; set; }

    // ✅ FOR DISPLAY (FROM API)
    public string? AgreementFilePath { get; set; }

    public IFormFile File { get; set; }
}
namespace GLMS.Shared.DTOs
{
    public class ServiceRequestDto
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal USDAmount { get; set; }

        public decimal ZARAmount { get; set; }

        public string ServiceType { get; set; } = string.Empty;
    }
}
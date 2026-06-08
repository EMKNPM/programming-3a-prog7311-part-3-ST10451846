using System.ComponentModel.DataAnnotations;

namespace GLMS.API.Models
{
    public class ServiceRequest
    {
        public int Id { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        public string Description { get; set; }

        public decimal USDAmount { get; set; }

        public decimal ZARAmount { get; set; }

        public string Status { get; set; } = "Pending";

        public string ServiceType { get; set; } = string.Empty;
    }
}

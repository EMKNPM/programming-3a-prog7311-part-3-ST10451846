using GLMS.API.Models;

namespace GLMS.API.Factories
{
    public class ServiceRequestFactory
    {
        public static ServiceRequest CreateRequest(string type)
        {
            switch (type)
            {
                case "Shipping":
                    return new ServiceRequest
                    {
                        ServiceType = "Shipping"
                    };

                case "Delivery":
                    return new ServiceRequest
                    {
                        ServiceType = "Delivery"
                    };

                case "Maintenance":
                    return new ServiceRequest
                    {
                        ServiceType = "Maintenance"
                    };

                default:
                    throw new ArgumentException("Invalid request type");
            }
        }
    }
}
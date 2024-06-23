using System.ComponentModel.DataAnnotations;

namespace HealthCheck.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class CustomHttpStatusAttribute:System.Attribute
    {
        [Required]
        public Type Resources { get; set; }
        public string Status { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int StatusCode { get; set; }
    }
}

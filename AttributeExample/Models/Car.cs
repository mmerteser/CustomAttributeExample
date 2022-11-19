using System.Security.Principal;

namespace AttributeExample.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = null!;
        public string BrandName { get; set; } = null!;
    }
}

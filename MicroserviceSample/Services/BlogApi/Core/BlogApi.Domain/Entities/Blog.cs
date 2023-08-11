using BlogApi.Domain.Contracts;
using System.Xml.Linq;

namespace BlogApi.Domain.Entities
{
    public class Blog : BaseEntity, IMustHaveTenant
    {
        public Blog() { }
        public Blog(string name, string description, int rate)
        {
            Name = name;
            Description = description;
            Rate = rate;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Rate { get; private set; }
        public string TenantId { get; set; }
    }
}

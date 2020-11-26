using System.ComponentModel.DataAnnotations.Schema;

namespace custom5
{
    [Table("Roles")]
    public class CustomRole : Role<CustomUser>
    {
        public int CustomField { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace custom5
{
    [Table("Users")]
    public class CustomUser : User<CustomTest, CustomRole>
    {
        public string Region { get; set; }
    }
}

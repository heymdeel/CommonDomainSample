using System.ComponentModel.DataAnnotations.Schema;

namespace custom5
{
    [Table("Tests")]
    public class CustomTest : Test<CustomUser>
    {

    }
}

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace RunGroopWebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}

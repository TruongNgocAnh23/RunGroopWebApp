using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunGroopWebApp.Models
{
    public class ArtilesImage
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        [ForeignKey("Artiles")]
        public int? ArtilesId { get; set; }
        public Artiles? Artiles { get; set; }
    }
}

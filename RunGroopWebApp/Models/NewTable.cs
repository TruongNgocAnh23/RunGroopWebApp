using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace RunGroopWebApp.Models
{
    public class NewTable
    {
        [Key]
        public int Id { get; set; }
        public string TableName { get; set; }
    }
}

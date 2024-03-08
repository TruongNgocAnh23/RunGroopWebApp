using RunGroopWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunGroopWebApp.ViewModels
{
    public class CreateArtilesViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFileCollection? Images { get; set; }
        public int? CategoryId { get; set; }
    }
}

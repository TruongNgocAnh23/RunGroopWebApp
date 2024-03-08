using RunGroopWebApp.Models;

namespace RunGroopWebApp.ViewModels
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string Thumbnail { get; set; }

    }
}

namespace RunGroopWebApp.ViewModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
    }
}

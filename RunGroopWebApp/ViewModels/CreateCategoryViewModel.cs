namespace RunGroopWebApp.ViewModels
{
    public class CreateCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public IFormFile Image { get; set; }
    }
}

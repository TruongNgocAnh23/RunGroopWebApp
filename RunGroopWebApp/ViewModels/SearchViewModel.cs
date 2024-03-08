namespace RunGroopWebApp.ViewModels
{
    public class SearchViewModel
    {
        public int? SearchTerm { get; set; }
        public IEnumerable<Item>? Results { get; set; }
    }
}

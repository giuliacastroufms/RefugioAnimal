namespace RefugioAnimal.Models.DTOs
{
    public class PagedAndSortedResultRequestDto
    {
        public string? Sorting { get; set; }
        public int SkipCount { get; set; }
        public int MaxResultCount { get; set; }
    }
}

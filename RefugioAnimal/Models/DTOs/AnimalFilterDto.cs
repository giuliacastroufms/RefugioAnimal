using RefugioAnimal.Models.Enums;

namespace RefugioAnimal.Models.DTOs
{
    public class AnimalFilterDto : PagedAndSortedResultRequestDto
    {
        public AdoptionStatus? AdoptionStatus { get; set; }
    }
}

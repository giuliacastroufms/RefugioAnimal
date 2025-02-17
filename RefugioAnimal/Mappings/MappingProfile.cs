using AutoMapper;
using RefugioAnimal.Models.DTOs;
using RefugioAnimal.Models.Entities;
using RefugioAnimal.Models.Enums;

namespace RefugioAnimal.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Animal, AnimalDto>()
                .ForMember(dest => dest.Specie, opt => opt.MapFrom(src => src.Species.ToString()))
                .ForMember(dest => dest.AdoptionStatus, opt => opt.MapFrom(src => src.AdoptionStatus.ToString()))
                .ForMember(dest => dest.BreedDescription, opt => opt.MapFrom(src => src.Breed != null ? src.Breed.Description : null))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos.Select(p => p.Photo).ToList()));

            CreateMap<CreateAnimalDto, Animal>()
                .ForMember(dest => dest.Species, opt => opt.MapFrom(src => Enum.Parse<Species>(src.Specie)))
                .ForMember(dest => dest.AdoptionStatus, opt => opt.MapFrom(src => AdoptionStatus.Available));

            CreateMap<UpdateAnimalDto, Animal>()
                .ForMember(dest => dest.Species, opt => opt.MapFrom(src => Enum.Parse<Species>(src.Specie)))
                .ForMember(dest => dest.AdoptionStatus, opt => opt.MapFrom(src => Enum.Parse<AdoptionStatus>(src.AdoptionStatus)));

            CreateMap<Adoption, AdoptionDto>();
        }
    }
}

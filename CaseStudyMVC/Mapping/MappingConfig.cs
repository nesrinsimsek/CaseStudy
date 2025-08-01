using AutoMapper;
using CaseStudyMVC.Dtos;

namespace CaseStudyMVC.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<TodoItemDto, TodoItemUpdateDto>().ReverseMap();

        }
    }
}

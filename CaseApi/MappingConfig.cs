using AutoMapper;
using CaseApi.Dtos;
using CaseDataAccess.Entities.Concrete;

namespace CaseApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<TodoItem, TodoItemCreateDto>().ReverseMap();
            CreateMap<TodoItem, TodoItemDto>().ReverseMap();
            CreateMap<TodoItem, TodoItemUpdateDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}

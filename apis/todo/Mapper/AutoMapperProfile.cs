using Application.Models;
using AutoMapper;
using Domain.Models;

namespace todo.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Todo, TodoRequest>().ReverseMap();
            CreateMap<Todo, TodoResponse>().ReverseMap();
        }
    }
}
using AutoMapper;
using ProjectX.Template.Application.Features.Categories.Commands.CreateCateogry;
using ProjectX.Template.Application.Features.Categories.Commands.UpdateCategory;
using ProjectX.Template.Application.Features.Categories.Queries.GetCategoriesList;
using ProjectX.Template.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using ProjectX.Template.Application.Features.Events.Commands.CreateEvent;
using ProjectX.Template.Application.Features.Events.Commands.UpdateEvent;
using ProjectX.Template.Application.Features.Events.Queries.GetEventDetail;
using ProjectX.Template.Application.Features.Events.Queries.GetEventsList;
using ProjectX.Template.Application.Features.Orders.Commands.CreateOrder;
using ProjectX.Template.Application.Features.Orders.Queries.GetOrdersForMonth;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Application.Profiles {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();

            CreateMap<Event, CreateEventDto>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, OrdersForMonthDto>();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
        }
    }
}

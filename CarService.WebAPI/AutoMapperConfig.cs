using AutoMapper;
using CarService.Model.Entities;
using CarService.Service.DTOs.OpenOrderReportDTOs;

namespace CarService.WebAPI
{
    public class AutoMapperConfig
    {
      

        public static void Initialize()
        {            

            Mapper.Initialize((config) =>
            {
                config.CreateMap<Avail, AvailDetailsOpenOrderReportDTO>()
                .ForMember(dest => dest.AvailType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.LaborPrice, opt => opt.MapFrom(src => src.Duration * 30))
                .ForMember(dest => dest.CarInfo, opt => opt.MapFrom(src => src.Car.Mark + " " + src.Car.Model + " " + src.Car.RegistrationNumber));
            });
            

        
        }
    }
}
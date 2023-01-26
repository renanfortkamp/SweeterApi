using AutoMapper;
using Sweeter.Models.Dto;
using Sweeter.Models.Entities;

namespace Sweeter.Models.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Sweet, SweetAllDto>().AfterMap((src, dest) =>
            {
                dest.DataPostagem = src.DataPostagem.ToString("dd/MM/yyyy HH:mm:ss");
            });

        }
    }
}

using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();

            CreateMap<AppUserRegisterDTO, AppUser>();
            CreateMap<AppUser,AppUserRegisterDTO>();

            CreateMap<AppUserLoginDTO, AppUser>();
            CreateMap<AppUser,AppUserLoginDTO>();
      

            CreateMap<AnnouncementListDto, Announcement>();
            CreateMap<Announcement, AnnouncementListDto>();

            CreateMap<AnnouncementUpdateDto, Announcement>();
            CreateMap<Announcement, AnnouncementUpdateDto>();

       
        }
    }
}

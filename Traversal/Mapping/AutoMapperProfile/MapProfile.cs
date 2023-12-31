﻿using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.CityDTOs;
using DTOLayer.DTOs.ContactUsDTOs;
using EntityLayer.Concrete;

namespace Traversal.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Announcement,AddAnnouncementDto>().ReverseMap();

            CreateMap<AddCityDto, Destination>().ReverseMap();
            CreateMap<AppUserRegisterDto, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();
            CreateMap<AnnouncementListDto, Announcement>().ReverseMap();
            CreateMap<AddAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<UpdateAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();

            
        }
    }
}

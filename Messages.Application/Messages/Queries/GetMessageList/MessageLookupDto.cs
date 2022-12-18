using Messages.Application.Common.Mappings;
using Messages.Domain;
using AutoMapper;
using System;

namespace Messages.Application.Messages.Queries.GetMessageList
{
    public class MessageLookupDto : IMapWith<Message>
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditTime { get; set; }
        public string UploadUrl { get; set; }





        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, MessageLookupDto>()
                .ForMember(mDto => mDto.Title,
                    opt => opt.MapFrom(m => m.Title))
                .ForMember(mDto => mDto.Text,
                    opt => opt.MapFrom(m => m.Text))
                .ForMember(mDto => mDto.CreationDate,
                    opt => opt.MapFrom(m => m.CreationDate))
                .ForMember(mDto => mDto.EditTime,
                    opt => opt.MapFrom(m => m.EditTime))
                .ForMember(mDto => mDto.UploadUrl,
                    opt => opt.MapFrom(m => m.UploadUrl));
        }
    }
}

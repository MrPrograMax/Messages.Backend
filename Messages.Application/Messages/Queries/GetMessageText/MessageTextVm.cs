using Messages.Application.Common.Mappings;
using System;
using Messages.Domain;
using AutoMapper;

namespace Messages.Application.Messages.Queries.GetMessageText
{
    public class MessageTextVm : IMapWith<Message>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool DeleteAfterUpload { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, MessageTextVm>()
                .ForMember(mVm => mVm.Id,
                    opt => opt.MapFrom(m => m.Id))
                .ForMember(mVm => mVm.Title,
                    opt => opt.MapFrom(m => m.Title))
                .ForMember(mVm => mVm.Text,
                    opt => opt.MapFrom(m => m.Text))
                .ForMember(mVm => mVm.DeleteAfterUpload,
                    opt => opt.MapFrom(m => m.DeleteAfterUpload))
                .ForMember(mVm => mVm.CreationDate,
                    opt => opt.MapFrom(m => m.CreationDate))
                .ForMember(mVm => mVm.EditTime,
                    opt => opt.MapFrom(m => m.EditTime));
        }
    }
}

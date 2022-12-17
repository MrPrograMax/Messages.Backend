using AutoMapper;
using Messages.Application.Common.Mappings;
using Messages.Application.Messages.Commands.CreateMessage;
using Messages.Application.Messages.Commands.UpdateMessage;
using System;

namespace Messages.WebApi.Models
{
    public class UpdateMessageDto : IMapWith<UpdateMessageDto>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool DeleteAfterUpload { get; set; }
        public void Mapping(Profile profile) 
        {
            profile.CreateMap<UpdateMessageDto, UpdateMessageCommand>()
                .ForMember(mCommand => mCommand.Id,
                    opt => opt.MapFrom(mDto => mDto.Id))
                .ForMember(mCommand => mCommand.Title,
                    opt => opt.MapFrom(mDto => mDto.Title))
                .ForMember(mCommand => mCommand.Text,
                    opt => opt.MapFrom(mDto => mDto.Text))
                .ForMember(mCommand => mCommand.DeleteAfterUpload,
                    opt => opt.MapFrom(mDto => mDto.DeleteAfterUpload));
        }
    }
}

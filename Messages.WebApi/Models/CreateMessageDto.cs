using AutoMapper;
using Messages.Application.Common.Mappings;
using Messages.Application.Messages.Commands.CreateMessage;
using System.ComponentModel.DataAnnotations;

namespace Messages.WebApi.Models
{
    public class CreateMessageDto : IMapWith<CreateMessageCommand>
    {
        [Required]
        public string Title { get; set; }

        public string Text { get; set; }
        public bool DeleteAfterUpload { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<CreateMessageDto, CreateMessageCommand>()
                .ForMember(mCommand => mCommand.Title,
                    opt => opt.MapFrom(mDto => mDto.Title))
                .ForMember(mCommand => mCommand.Text,
                    opt => opt.MapFrom(mDto => mDto.Text))
                .ForMember(mCommand => mCommand.DeleteAfterUpload,
                    opt => opt.MapFrom(mDto => mDto.DeleteAfterUpload));
        }
    }
}

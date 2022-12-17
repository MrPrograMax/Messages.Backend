using AutoMapper;
using System.IO.Compression;

namespace Messages.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());

    }
}

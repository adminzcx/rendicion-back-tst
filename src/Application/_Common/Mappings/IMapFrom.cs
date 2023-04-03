

namespace Prome.Viaticos.Server.Application._Common.Mappings
{
    using AutoMapper;
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}

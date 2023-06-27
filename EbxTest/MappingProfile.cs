using AutoMapper;
using EbxTest.Models;
using EbxTest.Models.External.GitHub;

namespace EbxTest;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Commit, Contributor>()
            .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Committer.Name))
            .ForMember(c => c.Email, opt => opt.MapFrom(src => src.Committer.Email))
            .ForMember(c => c.CommitDate, opt => opt.MapFrom(src => src.Committer.Date))
            .ForMember(c => c.CommitMessage, opt => opt.MapFrom(src => src.Message));
    }
}
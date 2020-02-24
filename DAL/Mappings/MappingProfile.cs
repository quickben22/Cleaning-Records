using AutoMapper;

using System;
using System.Collections.Generic;
using System.Text;

namespace CleaningRecords.DAL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CleaningRecords.DAL.Models.OldModels.Client, CleaningRecords.DAL.Models.Client>();
            CreateMap<CleaningRecords.DAL.Models.OldModels.Cleaner, CleaningRecords.DAL.Models.Cleaner>();
            CreateMap<CleaningRecords.DAL.Models.OldModels.Team, CleaningRecords.DAL.Models.Team>();
            CreateMap<CleaningRecords.DAL.Models.OldModels.Service, CleaningRecords.DAL.Models.Service>();

            CreateMap<CleaningRecords.DAL.Models.OldModels.CleanerTeam, CleaningRecords.DAL.Models.CleanerTeam>()
                   .ForMember(dest => dest.Cleaner, opts => opts.Ignore());

            CreateMap<CleaningRecords.DAL.Models.OldModels.CleaningJob, CleaningRecords.DAL.Models.CleaningJob>()
                .ForMember(dest => dest.Client, opts => opts.Ignore())
                  .ForMember(dest => dest.Team, opts => opts.Ignore())
                    .ForMember(dest => dest.Cleaner, opts => opts.Ignore())
                          .ForMember(dest => dest.RepeatJob, opts => opts.Ignore())
                                 .ForMember(dest => dest.Service, opts => opts.Ignore());
                  

            CreateMap<CleaningRecords.DAL.Models.OldModels.RepeatJob, CleaningRecords.DAL.Models.RepeatJob>();

        }
    }
}

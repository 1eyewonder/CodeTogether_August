using System;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
using WeatherApp.Dtos;

namespace WeatherApp.MappingProfiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<JObject, Location>()
                .DisableCtorValidation()
                .ForMember(nameof(Location.Distance),
                    x => x.MapFrom(j => j["distance"]))
                .ForMember(nameof(Location.Latitude),
                    x => x.MapFrom(j => float.Parse(
                        j["latt_long"]
                            .ToString()
                            .Split(',', StringSplitOptions.TrimEntries)
                            .First())
                    ))
                .ForMember(nameof(Location.Longitude),
                    x => x.MapFrom(j => float.Parse(
                        j["latt_long"]
                            .ToString()
                            .Split(',', StringSplitOptions.TrimEntries)
                            .Last())
                    ))
                .ForMember(nameof(Location.Name),
                    x => x.MapFrom(j => j["title"]))
                .ForMember(nameof(Location.Type),
                    x => x.MapFrom(j => j["location_type"]))
                .ForMember(nameof(Location.Id),
                    x => x.MapFrom(j => j["woeid"]));
        }
    }
}
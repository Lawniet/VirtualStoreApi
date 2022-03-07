using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualStoreApi.Mapper
{
    public static class MapperGenerator
    {
        public static IMapper GenerateMapper()
        {
            MapperConfiguration mapperConfig = new(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            return mapper;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PasswordHandler.Models;

namespace PasswordHandler.Utils
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Store, Resource>();
        }
    }

}

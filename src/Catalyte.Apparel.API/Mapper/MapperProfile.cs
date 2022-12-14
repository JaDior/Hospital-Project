using AutoMapper;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs;
using Catalyte.Apparel.DTOs.Encounters;
using Catalyte.Apparel.DTOs.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyte.Apparel.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();

            CreateMap<Encounter, EncounterDTO>().ReverseMap();
        }

    }
}

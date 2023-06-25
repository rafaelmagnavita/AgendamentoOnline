using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AgendamentoOnline.Models;

namespace AgendamentoOnline.App_Start
{
    public class MapperRoutes : Profile
    {
        public MapperRoutes()
        {
            CreateMap<User, Patient>();
            CreateMap<User, Doctor>();
            CreateMap<User, Attendant>();
            CreateMap<User, AdminUser>();
            // Adicione mais mapeamentos aqui, se necessário
        }
    }
}
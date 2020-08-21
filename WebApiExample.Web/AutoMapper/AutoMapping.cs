using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApiExample.Web.Models;
using WebApiExample.Web.ViewModels;

namespace WebApiExample.Web.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
        }
    }
}

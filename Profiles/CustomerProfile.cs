using AutoMapper;
using LibApp.Dtos;
using LibApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Profiles
{
<<<<<<< Updated upstream
    public class CustomerProfile : Profile
=======
    public class CustomerProfile : Profile 
>>>>>>> Stashed changes
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
        }
    }
}

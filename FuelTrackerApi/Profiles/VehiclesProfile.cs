using AutoMapper;
using FuelTrackerApi.Models.Domain;
using FuelTrackerApi.Models.ViewModels;

namespace FuelTrackerApi.Profiles
{
    public class VehiclesProfile : Profile
    {
        public VehiclesProfile()
        {
            //Source -> Target
            CreateMap<Vehicle, VehicleViewModel>();
            CreateMap<FuelTransaction, FuelTransactionViewModel>();
        }
    }
}
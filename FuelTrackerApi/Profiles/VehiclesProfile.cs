using AutoMapper;
using FuelTrackerApi.Models.Api.Requests;
using FuelTrackerApi.Models.Domain;
using FuelTrackerApi.Models.ViewModels;

namespace FuelTrackerApi.Profiles
{
    public class VehiclesProfile : Profile
    {
        public VehiclesProfile()
        {
            //Source -> Target
            CreateMap<Vehicle, VehicleViewModel>().ReverseMap();
            CreateMap<Vehicle, CreateEditVehicleRequest>().ReverseMap();
            CreateMap<FuelTransaction, FuelTransactionViewModel>().ReverseMap();
            CreateMap<FuelTransaction, CreateEditFuelTransactionRequest>().ReverseMap();
        }
    }
}
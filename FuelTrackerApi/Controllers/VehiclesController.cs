using AutoMapper;
using FuelTrackerApi.Models.Api.Requests;
using FuelTrackerApi.Models.Domain;
using FuelTrackerApi.Models.ViewModels;
using FuelTrackerApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FuelTrackerApi.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _service;
        private readonly IMapper _mapper;

        public VehiclesController(VehicleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/vehicles
        [HttpGet]
        public ActionResult<IEnumerable<VehicleViewModel>> GetAllVehicles()
        {
            IEnumerable<Vehicle> vehicleItems = _service.GetAllVehicles();

            return Ok(_mapper.Map<IEnumerable<VehicleViewModel>>(vehicleItems));
        }

        //GET api/vehicles/{id}
        [HttpGet("{id}", Name = "GetVehicleById")]
        public ActionResult<VehicleViewModel> GetVehicleById(int id)
        {
            Vehicle VehicleItem = _service.GetVehicleById(id);
            if (VehicleItem != null)
                return Ok(_mapper.Map<VehicleViewModel>(VehicleItem));

            return NotFound();
        }

        //POST api/vehicles
        [HttpPost]
        public ActionResult<VehicleViewModel> CreateVehicle(CreateEditVehicleRequest request)
        {
            Vehicle newVehicle = _mapper.Map<Vehicle>(request);
            _service.CreateVehicle(newVehicle);

            var vehicleViewModel = _mapper.Map<VehicleViewModel>(newVehicle);

            return CreatedAtRoute(nameof(GetVehicleById), new { Id = vehicleViewModel.Id }, vehicleViewModel);
        }

        //POST api/vehicles/{id}
        [HttpPost("{id}")]
        public ActionResult UpdateVehicle(int id, CreateEditVehicleRequest request)
        {
            Vehicle vehicle = _service.GetVehicleById(id);
            if (vehicle == null)
                return NotFound();

            if (request.Id != null && request.Id != id)
                return ValidationProblem("The ID in the model doesn't match the ID the request was made on.");

            _service.UpdateVehicle(request, vehicle);
            return NoContent();
        }

        //DELETE api/vehicles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteVehicle(int id)
        {
            var vehicle = _service.GetVehicleById(id);
            if (vehicle == null)
                return NotFound();

            _service.DeleteVehicle(vehicle);

            return NoContent();
        }
    }
}
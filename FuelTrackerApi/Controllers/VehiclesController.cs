using AutoMapper;
using FuelTrackerApi.Data;
using FuelTrackerApi.Models.Domain;
using FuelTrackerApi.Models.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FuelTrackerApi.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleData _repository;
        private readonly IMapper _mapper;

        public VehiclesController(IVehicleData repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/Vehicles
        [HttpGet]
        public ActionResult<IEnumerable<VehicleViewModel>> GetAllCommmands()
        {
            IEnumerable<Vehicle> vehicleItems = _repository.GetAllVehicles();

            return Ok(_mapper.Map<IEnumerable<VehicleViewModel>>(vehicleItems));
        }

        //GET api/Vehicles/{id}
        [HttpGet("{id}", Name = "GetVehicleById")]
        public ActionResult<VehicleViewModel> GetVehicleById(int id)
        {
            Vehicle VehicleItem = _repository.GetVehicleById(id);
            if (VehicleItem != null)
            {
                return Ok(_mapper.Map<VehicleViewModel>(VehicleItem));
            }
            return NotFound();
        }

        //POST api/Vehicles
        [HttpPost]
        public ActionResult<VehicleViewModel> CreateVehicle(Vehicle vehicle)
        {
            Vehicle vehicleModel = _mapper.Map<Vehicle>(vehicle);
            _repository.CreateVehicle(vehicleModel);
            _repository.SaveChanges();

            var VehicleViewModel = _mapper.Map<VehicleViewModel>(vehicleModel);

            return CreatedAtRoute(nameof(GetVehicleById), new { Id = VehicleViewModel.VehicleId }, VehicleViewModel);
        }

        //PUT api/Vehicles/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateVehicle(int id, Vehicle vehicle)
        {
            Vehicle vehicleModelFromRepo = _repository.GetVehicleById(id);
            if (vehicleModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(vehicle, vehicleModelFromRepo);

            _repository.UpdateVehicle(id, vehicleModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/Vehicles/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialVehicleUpdate(int id, JsonPatchDocument<Vehicle> patchDoc)
        {
            var vehicleModelFromRepo = _repository.GetVehicleById(id);
            if (vehicleModelFromRepo == null)
            {
                return NotFound();
            }

            var VehicleToPatch = _mapper.Map<Vehicle>(vehicleModelFromRepo);
            patchDoc.ApplyTo(VehicleToPatch, ModelState);

            if (!TryValidateModel(VehicleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(VehicleToPatch, vehicleModelFromRepo);

            _repository.UpdateVehicle(id, vehicleModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/Vehicles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteVehicle(int id)
        {
            var vehicleModelFromRepo = _repository.GetVehicleById(id);
            if (vehicleModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteVehicle(vehicleModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
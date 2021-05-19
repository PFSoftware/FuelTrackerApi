using AutoMapper;
using FuelTrackerApi.Data;
using FuelTrackerApi.Models.Domain;
using FuelTrackerApi.Models.ViewModels;
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
            IEnumerable<Vehicle> VehicleItems = _repository.GetAllVehicles();

            return Ok(_mapper.Map<IEnumerable<VehicleViewModel>>(VehicleItems));
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

        ////POST api/Vehicles
        //[HttpPost]
        //public ActionResult<VehicleViewModel> CreateVehicle(VehicleCreateDto VehicleCreateDto)
        //{
        //    var VehicleModel = _mapper.Map<Vehicle>(VehicleCreateDto);
        //    _repository.CreateVehicle(VehicleModel);
        //    _repository.SaveChanges();

        //    var VehicleViewModel = _mapper.Map<VehicleViewModel>(VehicleModel);

        //    return CreatedAtRoute(nameof(GetVehicleById), new { Id = VehicleViewModel.Id }, VehicleViewModel);
        //}

        ////PUT api/Vehicles/{id}
        //[HttpPut("{id}")]
        //public ActionResult UpdateVehicle(int id, VehicleUpdateDto VehicleUpdateDto)
        //{
        //    var VehicleModelFromRepo = _repository.GetVehicleById(id);
        //    if (VehicleModelFromRepo == null)
        //    {
        //        return NotFound();
        //    }
        //    _mapper.Map(VehicleUpdateDto, VehicleModelFromRepo);

        //    _repository.UpdateVehicle(VehicleModelFromRepo);

        //    _repository.SaveChanges();

        //    return NoContent();
        //}

        ////PATCH api/Vehicles/{id}
        //[HttpPatch("{id}")]
        //public ActionResult PartialVehicleUpdate(int id, JsonPatchDocument<VehicleUpdateDto> patchDoc)
        //{
        //    var VehicleModelFromRepo = _repository.GetVehicleById(id);
        //    if (VehicleModelFromRepo == null)
        //    {
        //        return NotFound();
        //    }

        //    var VehicleToPatch = _mapper.Map<VehicleUpdateDto>(VehicleModelFromRepo);
        //    patchDoc.ApplyTo(VehicleToPatch, ModelState);

        //    if (!TryValidateModel(VehicleToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    _mapper.Map(VehicleToPatch, VehicleModelFromRepo);

        //    _repository.UpdateVehicle(VehicleModelFromRepo);

        //    _repository.SaveChanges();

        //    return NoContent();
        //}

        //DELETE api/Vehicles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteVehicle(int id)
        {
            var VehicleModelFromRepo = _repository.GetVehicleById(id);
            if (VehicleModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteVehicle(VehicleModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
using AutoMapper;
using FuelTrackerApi.Data;
using FuelTrackerApi.Models.Api.Requests;
using FuelTrackerApi.Models.Domain;
using FuelTrackerApi.Models.ViewModels;
using FuelTrackerApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FuelTrackerApi.Controllers
{
    [Route("api/fueltransactions")]
    [ApiController]
    public class FuelTransactionsController : ControllerBase
    {
        private readonly FuelTransactionService _service;
        private readonly IMapper _mapper;

        public FuelTransactionsController(FuelTransactionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/fueltransactions
        [HttpGet]
        public ActionResult<IEnumerable<FuelTransactionViewModel>> GetAllCommmands()
        {
            IEnumerable<FuelTransaction> fuelTransactionItems = _service.GetAllFuelTransactions();

            return Ok(_mapper.Map<IEnumerable<FuelTransactionViewModel>>(fuelTransactionItems));
        }

        //GET api/fueltransactions/{id}
        [HttpGet("{id}", Name = "GetFuelTransactionById")]
        public ActionResult<FuelTransactionViewModel> GetFuelTransactionById(int id)
        {
            FuelTransaction fuelTransactionItem = _service.GetFuelTransactionById(id);
            if (fuelTransactionItem != null)
            {
                return Ok(_mapper.Map<FuelTransactionViewModel>(fuelTransactionItem));
            }
            return NotFound();
        }

        //POST api/fueltransactions
        [HttpPost]
        public ActionResult<FuelTransactionViewModel> CreateFuelTransaction(CreateEditFuelTransactionRequest request)
        {
            FuelTransaction newFuelTransaction = _mapper.Map<FuelTransaction>(request);
            _service.CreateFuelTransaction(newFuelTransaction);

            var fuelTransactionViewModel = _mapper.Map<FuelTransactionViewModel>(newFuelTransaction);

            return CreatedAtRoute(nameof(GetFuelTransactionById), new { Id = fuelTransactionViewModel.Id }, fuelTransactionViewModel);
        }

        //PUT api/fueltransactions/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFuelTransaction(int id, FuelTransaction fuelTransaction)
        {
            FuelTransaction fuelTransactionModelFromRepo = _service.GetFuelTransactionById(id);
            if (fuelTransactionModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(fuelTransaction, fuelTransactionModelFromRepo);

            _service.UpdateFuelTransaction(id, fuelTransactionModelFromRepo);

            return NoContent();
        }

        //PATCH api/fueltransactions/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialFuelTransactionUpdate(int id, JsonPatchDocument<FuelTransaction> patchDoc)
        {
            FuelTransaction fuelTransactionModelFromRepo = _service.GetFuelTransactionById(id);
            if (fuelTransactionModelFromRepo == null)
            {
                return NotFound();
            }

            FuelTransaction fuelTransactionToPatch = _mapper.Map<FuelTransaction>(fuelTransactionModelFromRepo);
            patchDoc.ApplyTo(fuelTransactionToPatch, ModelState);

            if (!TryValidateModel(fuelTransactionToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(fuelTransactionToPatch, fuelTransactionModelFromRepo);

            _service.UpdateFuelTransaction(id, fuelTransactionModelFromRepo);

            return NoContent();
        }

        //DELETE api/fueltransactions/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFuelTransaction(int id)
        {
            FuelTransaction fuelTransactionModelFromRepo = _service.GetFuelTransactionById(id);
            if (fuelTransactionModelFromRepo == null)
            {
                return NotFound();
            }
            _service.DeleteFuelTransaction(fuelTransactionModelFromRepo);
            return NoContent();
        }
    }
}